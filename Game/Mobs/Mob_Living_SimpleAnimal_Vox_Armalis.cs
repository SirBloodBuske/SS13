// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Vox_Armalis : Mob_Living_SimpleAnimal_Vox {

		public dynamic armour = null;
		public dynamic amp = null;
		public int quills = 3;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.real_name = "serpentine alien";
			this.icon_living = "armalis";
			this.maxHealth = 500;
			this.health = 500;
			this.response_harm = "slashes at the";
			this.harm_intent_damage = 0;
			this.melee_damage_lower = 30;
			this.melee_damage_upper = 40;
			this.attacktext = "slammed its enormous claws into";
			this.speed = -1;
			this.environment_smash = 2;
			this.attack_sound = "sound/weapons/bladeslice.ogg";
			this.status_flags = 0;
			this.icon = "icons/mob/vox.dmi";
			this.icon_state = "armalis";
		}

		public Mob_Living_SimpleAnimal_Vox_Armalis ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: vox.dm
		public override void regenerate_icons(  ) {
			Image armour = null;
			Image amp = null;

			this.overlays = new ByTable();

			if ( Lang13.Bool( this.armour ) ) {
				armour = new Image( "icons/mob/vox.dmi", "armour" );
				this.speed = 1;
				this.overlays.Add( armour );
			}

			if ( Lang13.Bool( this.amp ) ) {
				amp = new Image( "icons/mob/vox.dmi", "amplifier" );
				this.overlays.Add( amp );
			}
			return;
		}

		// Function from file: vox.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic damage = null;
			dynamic M = null;
			dynamic M2 = null;
			dynamic M3 = null;

			((Mob)b).delayNextAttack( 8 );

			if ( Lang13.Bool( a.force ) ) {
				
				if ( Convert.ToDouble( a.force ) >= 25 ) {
					damage = a.force;

					if ( a.damtype == "halloss" ) {
						damage = 0;
					}
					this.health -= damage;

					foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, this ) )) {
						M = _a;
						

						if ( Lang13.Bool( M.client ) && !Lang13.Bool( M.blinded ) ) {
							M.show_message( "<span class='danger'>" + this + " has been attacked with the " + a + " by " + b + ". </span>" );
						}
					}
				} else {
					
					foreach (dynamic _b in Lang13.Enumerate( Map13.FetchViewers( null, this ) )) {
						M2 = _b;
						

						if ( Lang13.Bool( M2.client ) && !Lang13.Bool( M2.blinded ) ) {
							M2.show_message( "<span class='danger'>The " + a + " bounces harmlessly off of " + this + ". </span>" );
						}
					}
				}
			} else {
				GlobalFuncs.to_chat( Task13.User, "<span class='warning'>This weapon is ineffective, it does no damage.</span>" );

				foreach (dynamic _c in Lang13.Enumerate( Map13.FetchViewers( null, this ) )) {
					M3 = _c;
					

					if ( Lang13.Bool( M3.client ) && !Lang13.Bool( M3.blinded ) ) {
						M3.show_message( "<span class='warning'>" + b + " gently taps " + this + " with the " + a + ". </span>" );
					}
				}
			}
			return null;
		}

		// Function from file: vox.dm
		public override void Die( bool? gore = null ) {
			GlobalVars.living_mob_list.Remove( this );
			GlobalVars.dead_mob_list.Add( this );
			this.stat = 2;
			this.visible_message( "<span class='danger'><B>" + this + " shudders violently and explodes!</B>", "<span class='warning'>You feel your body rupture!</span></span>" );
			GlobalFuncs.explosion( GlobalFuncs.get_turf( this.loc ), -1, -1, 3, 5 );
			this.gib();
			return;
		}

		// Function from file: mind.dm
		public override void mind_initialize(  ) {
			base.mind_initialize();
			this.mind.assigned_role = "Armalis";
			this.mind.special_role = "Vox Raider";
			return;
		}

		// Function from file: vox.dm
		[Verb]
		[VerbInfo( name: "Shriek", desc: "Give voice to a psychic shriek.", group: "Alien" )]
		public void shriek(  ) {
			return;
		}

		// Function from file: vox.dm
		[Verb]
		[VerbInfo( name: "Commune with creature", desc: "Send a telepathic message to an unlucky recipient.", group: "Alien" )]
		public void message_mob(  ) {
			ByTable targets = null;
			dynamic target = null;
			dynamic text = null;
			dynamic M = null;
			Mob_Living_Carbon_Human H = null;

			targets = new ByTable();
			target = null;
			text = null;
			targets.Add( GlobalFuncs.getmobs() );
			target = Interface13.Input( "Select a creature!", "Speak to creature", null, null, targets, InputType.Null | InputType.Any );
			text = Interface13.Input( "What would you like to say?", "Speak to creature", null, null, null, InputType.Any );

			if ( !Lang13.Bool( target ) || !Lang13.Bool( text ) ) {
				return;
			}
			M = targets[target];

			if ( M is Mob_Dead_Observer || Convert.ToInt32( M.stat ) == 2 ) {
				GlobalFuncs.to_chat( this, "Not even the armalis can speak to the dead." );
				return;
			}
			GlobalFuncs.to_chat( M, "<span class='notice'>Like lead slabs crashing into the ocean, alien thoughts drop into your mind: " + text + "</span>" );

			if ( M is Mob_Living_Carbon_Human ) {
				H = M;

				if ( H.species.name == "Vox" ) {
					return;
				}
				GlobalFuncs.to_chat( H, "<span class='warning'>Your nose begins to bleed...</span>" );
				H.drip( 1 );
			}
			return;
		}

		// Function from file: vox.dm
		[Verb]
		[VerbInfo( name: "Fire quill", desc: "Fires a viciously pointed quill at a high speed.", group: "Alien" )]
		[VerbArg( 1, InputType.Mob, VerbArgFilter.InViewExcludeThis )]
		public void fire_quill( dynamic target = null ) {
			dynamic O = null;
			Obj_Item_Weapon_Arrow_Quill Q = null;

			
			if ( this.quills <= 0 ) {
				return;
			}
			GlobalFuncs.to_chat( this, "<span class='warning'>You launch a razor-sharp quill at " + target + "!</span>" );

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewersExcludeThis( null, null ) )) {
				O = _a;
				

				if ( Lang13.Bool( O.client ) && !Lang13.Bool( O.blinded ) ) {
					GlobalFuncs.to_chat( O, "<span class='warning'>" + this + " launches a razor-sharp quill at " + target + "!</span>" );
				}
			}
			Q = new Obj_Item_Weapon_Arrow_Quill( this.loc );
			Q.fingerprintslast = this.ckey;
			Q.throw_at( target, 10, 30 );
			this.quills--;
			Task13.Schedule( 100, (Task13.Closure)(() => {
				GlobalFuncs.to_chat( this, "<span class='warning'>You feel a fresh quill slide into place.</span>" );
				this.quills++;
				return;
			}));
			return;
		}

	}

}