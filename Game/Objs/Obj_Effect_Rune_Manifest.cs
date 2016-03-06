// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Rune_Manifest : Obj_Effect_Rune {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.cultist_name = "Manifest Spirit";
			this.cultist_desc = "Manifests a spirit as a servant of the Geometer. The invoker must not move from atop the rune, and will take damage for each summoned spirit.";
			this.invocation = "Gal'h'rfikk harfrandid mud'gib!";
			this.icon_state = "6";
		}

		public Obj_Effect_Rune_Manifest ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: runes.dm
		public override void invoke( dynamic user = null ) {
			ByTable ghosts_on_rune = null;
			Mob_Dead_Observer O = null;
			dynamic ghost_to_spawn = null;
			Mob_Living_Carbon_Human new_human = null;
			Obj I = null;

			
			if ( !Lang13.Bool( GlobalFuncs.get_turf( this ).Contains( user ) ) ) {
				user.WriteMsg( "<span class='cultitalic'>You must be standing on " + this + "!</span>" );
				this.fail_invoke();
				GlobalFuncs.log_game( "Manifest rune failed - user not standing on rune" );
				return;
			}
			ghosts_on_rune = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_turf( this ), typeof(Mob_Dead_Observer) )) {
				O = _a;
				

				if ( O.client != null ) {
					ghosts_on_rune.Add( O );
				}
			}

			if ( !( ghosts_on_rune.len != 0 ) ) {
				user.WriteMsg( "<span class='cultitalic'>There are no spirits near " + this + "!</span>" );
				this.fail_invoke();
				GlobalFuncs.log_game( "Manifest rune failed - no nearby ghosts" );
				return;
			}
			ghost_to_spawn = Rand13.PickFromTable( ghosts_on_rune );
			new_human = new Mob_Living_Carbon_Human( GlobalFuncs.get_turf( this ) );
			new_human.real_name = ghost_to_spawn.real_name;
			new_human.alpha = 150;
			this.visible_message( "<span class='warning'>A cloud of red mist forms above " + this + ", and from within steps... a man.</span>" );
			user.WriteMsg( "<span class='cultitalic'>Your blood begins flowing into " + this + ". You must remain in place and conscious to maintain the forms of those summoned. This will hurt you slowly but surely...</span>" );
			new_human.key = ghost_to_spawn.key;
			((GameMode)GlobalVars.ticker.mode).add_cultist( new_human.mind );
			new_human.WriteMsg( "<span class='cultitalic'><b>You are a servant of the Geometer. You have been made semi-corporeal by the cult of Nar-Sie, and you are to serve them at all costs.</b></span>" );

			while (Lang13.Bool( GlobalFuncs.get_turf( this ).Contains( user ) )) {
				
				if ( Lang13.Bool( user.stat ) ) {
					break;
				}
				user.apply_damage( 1, "brute" );
				Task13.Sleep( 30 );
			}

			if ( new_human != null ) {
				new_human.visible_message( "<span class='warning'>" + new_human + " suddenly dissolves into bones and ashes.</span>", "<span class='cultlarge'>Your link to the world fades. Your form breaks apart.</span>" );

				foreach (dynamic _b in Lang13.Enumerate( new_human, typeof(Obj) )) {
					I = _b;
					
					new_human.unEquip( I );
				}
				new_human.dust();
			}
			return;
		}

	}

}