// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Projectile_Revolver_Russian : Obj_Item_Weapon_Gun_Projectile_Revolver {

		public bool spun = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.mag_type = typeof(Obj_Item_AmmoBox_Magazine_Internal_Rus357);
		}

		// Function from file: revolver.dm
		public Obj_Item_Weapon_Gun_Projectile_Revolver_Russian ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.Spin();
			this.update_icon();
			return;
		}

		// Function from file: revolver.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			dynamic H = null;
			dynamic AC = null;
			dynamic affecting = null;
			string limb_name = null;

			
			if ( proximity_flag == true ) {
				
				if ( !user.contents.Contains( target ) && target is Mob ) {
					
					if ( user.a_intent == "harm" ) {
						return false;
					}
				}
			}

			if ( user is Mob_Living ) {
				
				if ( !this.can_trigger_gun( user ) ) {
					return false;
				}
			}

			if ( target != user ) {
				
				if ( target is Mob ) {
					user.WriteMsg( "<span class='warning'>A mechanism prevents you from shooting anyone but yourself!</span>" );
				}
				return false;
			}

			if ( user is Mob_Living_Carbon_Human ) {
				H = user;

				if ( !this.spun ) {
					user.WriteMsg( "<span class='warning'>You need to spin the revolver's chamber first!</span>" );
					return false;
				}
				this.spun = false;

				if ( Lang13.Bool( this.chambered ) ) {
					AC = this.chambered;

					if ( Lang13.Bool( AC.fire( user, user ) ) ) {
						GlobalFuncs.playsound( user, this.fire_sound, 50, 1 );
						affecting = ((Mob_Living_Carbon_Human)H).get_organ( GlobalFuncs.check_zone( user.zone_selected ) );
						limb_name = ((Obj_Item_Organ_Limb)affecting).getDisplayName();

						if ( affecting.name == "head" || affecting.name == "eyes" || affecting.name == "mouth" ) {
							user.apply_damage( 300, "brute", affecting );
							((Ent_Static)user).visible_message( new Txt( "<span class='danger'>" ).item( user.name ).str( " fires " ).item( this ).str( " at " ).his_her_its_their().str( " head!</span>" ).ToString(), "<span class='userdanger'>You fire " + this + " at your head!</span>", "<span class='italics'>You hear a gunshot!</span>" );
						} else {
							((Ent_Static)user).visible_message( new Txt( "<span class='danger'>" ).item( user.name ).str( " cowardly fires " ).item( this ).str( " at " ).his_her_its_their().str( " " ).item( limb_name ).str( "!</span>" ).ToString(), "<span class='userdanger'>You cowardly fire " + this + " at your " + limb_name + "!</span>", "<span class='italics'>You hear a gunshot!</span>" );
						}
						return false;
					}
				}
				((Ent_Static)user).visible_message( "<span class='danger'>*click*</span>" );
				GlobalFuncs.playsound( user, "sound/weapons/empty.ogg", 100, 1 );
			}
			return false;
		}

		// Function from file: revolver.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			int num_unloaded = 0;
			dynamic CB = null;

			
			if ( !this.spun && Lang13.Bool( this.can_shoot() ) ) {
				((Ent_Static)user).visible_message( "" + user + " spins the chamber of the revolver.", "<span class='notice'>You spin the revolver's chamber.</span>" );
				this.Spin();
			} else {
				num_unloaded = 0;

				while (this.get_ammo() > 0) {
					CB = null;
					CB = ((Obj_Item_AmmoBox)this.magazine).get_round();
					this.chambered = null;
					CB.loc = GlobalFuncs.get_turf( this.loc );
					CB.update_icon();
					num_unloaded++;
				}

				if ( num_unloaded != 0 ) {
					user.WriteMsg( new Txt( "<span class='notice'>You unload " ).item( num_unloaded ).str( " shell" ).s().str( " from " ).item( this ).str( ".</span>" ).ToString() );
				} else {
					user.WriteMsg( "<span class='notice'>" + this + " is empty.</span>" );
				}
			}
			return null;
		}

		// Function from file: revolver.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic num_loaded = null;

			num_loaded = base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( Lang13.Bool( num_loaded ) ) {
				((Ent_Static)user).visible_message( "" + user + " loads a single bullet into the revolver and spins the chamber.", "<span class='notice'>You load a single bullet into the chamber and spin it.</span>" );
			} else {
				((Ent_Static)user).visible_message( "" + user + " spins the chamber of the revolver.", "<span class='notice'>You spin the revolver's chamber.</span>" );
			}

			if ( this.get_ammo() > 0 ) {
				this.Spin();
			}
			this.update_icon();
			A.update_icon();
			return null;
		}

		// Function from file: revolver.dm
		public void Spin(  ) {
			double random = 0;

			this.chambered = null;
			random = Rand13.Int( 1, this.magazine.max_ammo ??0 );

			if ( random <= this.get_ammo( false, false ) ) {
				this.chamber_round();
			}
			this.spun = true;
			return;
		}

	}

}