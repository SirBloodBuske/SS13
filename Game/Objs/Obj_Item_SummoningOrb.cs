// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_SummoningOrb : Obj_Item {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 1;
			this.icon = "icons/obj/cult.dmi";
			this.icon_state = "summoning_orb";
		}

		public Obj_Item_SummoningOrb ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: cult_items.dm
		public void place_down_large_shell( dynamic user = null ) {
			dynamic cult = null;
			Obj_Structure_Constructshell_Large A = null;

			
			if ( !( GlobalVars.ticker.mode.name == "cult" ) ) {
				user.WriteMsg( "<span class='notice'>You attempt to call out to the Geometer for Her shell, but you fail...</span>" );
				return;
			}
			cult = GlobalVars.ticker.mode;

			if ( cult.attempts_left <= 0 ) {
				user.WriteMsg( "<span class='cultlarge'>The Geometer is no longer interested in you.</span>" );
			}
			A = new Obj_Structure_Constructshell_Large( GlobalFuncs.get_turf( this ) );
			cult.large_shell_reference = A;
			return;
		}

		// Function from file: cult_items.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			dynamic T = null;
			dynamic cult = null;
			Obj_Structure_Constructshell_Large S = null;
			dynamic A = null;

			
			if ( !GlobalFuncs.iscultist( user ) ) {
				return base.attack_self( (object)(user), (object)(flag), emp );
			}

			if ( GlobalVars.ticker.mode.name != "cult" ) {
				return null;
			}
			T = GlobalFuncs.get_turf( user );

			if ( Lang13.Bool( T.z ) != true ) {
				user.WriteMsg( "<span class='cultlarge'>You shouldn't do this here. Go back.</span>" );
				return null;
			}
			cult = GlobalVars.ticker.mode;

			if ( !( cult.attempts_left != 0 ) ) {
				user.WriteMsg( "<span class='notice'>You attempt to call out to the Geometer, but there is no answer...</span>" );
				return null;
			}

			if ( cult.eldergod ) {
				user.WriteMsg( "<span class='cultlarge>The Geometer is already among us.</span>" );
				return null;
			}

			if ( cult.large_shell_reference != null ) {
				S = cult.large_shell_reference;

				if ( Lang13.Bool( S.anchored ) ) {
					A = GlobalFuncs.get_area( S );
					user.WriteMsg( "<span class='cult'>The Geometer has already started manifesting in " + Lang13.Initial( A, "name" ) + ". You can no longer move Her shell.</span>" );
					return null;
				}

				switch ((string)( Interface13.Alert( user, "The Geometer's shell has already been manifested. Do you wish to summon it to your location?", "Summoning Large Shell", "Yes", "No" ) )) {
					case "Yes":
						S.visible_message( "<span class='cultlarge'>The shell suddenly vanishes.</span>" );
						S.loc = user.loc;
						break;
				}
			} else {
				
				switch ((string)( Interface13.Alert( user, "Are you sure you wish to summon the large construct shell? " + cult.attempts_left + " attempts left!", "Summoning Large Shell", "Yes", "No" ) )) {
					case "Yes":
						cult.attempts_left--;
						this.place_down_large_shell( user );
						GlobalFuncs.qdel( this );
						break;
				}
			}
			return null;
		}

		// Function from file: cult_items.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			dynamic L = null;

			
			if ( !GlobalFuncs.iscultist( user ) ) {
				return base.afterattack( (object)(target), (object)(user), proximity_flag, click_parameters );
			}

			if ( proximity_flag == true && target is Mob_Living && GlobalFuncs.iscultist( target ) ) {
				L = target;

				if ( Convert.ToInt32( L.stat ) == 2 ) {
					user.WriteMsg( "<span class='cultlarge'>You shouldn't waste that.</span>" );
					return base.afterattack( (object)(target), (object)(user), proximity_flag, click_parameters );
				}
				target.WriteMsg( "<span class='cult'>You feel the Geometer's essence violating your insides.</span>" );
				target.WriteMsg( "<span class='cult'>It feels... </span><span class='cultitalic'>good.</span>" );
				target.reagents.add_reagent( "unholywater", 15 );
				GlobalFuncs.qdel( this );
			}
			base.afterattack( (object)(target), (object)(user), proximity_flag, click_parameters );
			return false;
		}

	}

}