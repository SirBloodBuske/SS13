// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Twohanded_Bostaff : Obj_Item_Weapon_Twohanded {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.force = 10;
			this.w_class = 4;
			this.slot_flags = 1024;
			this.force_unwielded = 10;
			this.force_wielded = 24;
			this.throwforce = 20;
			this.attack_verb = new ByTable(new object [] { "smashed", "slammed", "whacked", "thwacked" });
			this.block_chance = 50;
			this.icon_state = "bostaff0";
		}

		public Obj_Item_Weapon_Twohanded_Bostaff ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: martial.dm
		public override bool hit_reaction( Mob_Living_Carbon owner = null, string attack_text = null, int? final_block_chance = null, dynamic damage = null, int? attack_type = null ) {
			
			if ( this.wielded ) {
				return base.hit_reaction( owner, attack_text, final_block_chance, (object)(damage), attack_type );
			}
			return false;
		}

		// Function from file: martial.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			dynamic H = null;
			dynamic C = null;
			dynamic H2 = null;
			ByTable fluffmessages = null;
			double? total_health = null;

			this.add_fingerprint( user );

			if ( Lang13.Bool( user.disabilities.Contains( 256 ) ) && Rand13.PercentChance( 50 ) ) {
				user.WriteMsg( "<span class ='warning'>You club yourself over the head with " + this + ".</span>" );
				((Mob)user).Weaken( 3 );

				if ( user is Mob_Living_Carbon_Human ) {
					H = user;
					H.apply_damage( this.force * 2, "brute", "head" );
				} else {
					((Mob_Living)user).take_organ_damage( this.force * 2 );
				}
				return false;
			}

			if ( M is Mob_Living_Silicon_Robot ) {
				return base.attack( (object)(M), (object)(user), def_zone );
			}

			if ( !( M is Mob_Living ) ) {
				return base.attack( (object)(M), (object)(user), def_zone );
			}
			C = M;

			if ( Lang13.Bool( C.stat ) ) {
				user.WriteMsg( "<span class='warning'>It would be dishonorable to attack a foe while they cannot retaliate.</span>" );
				return false;
			}

			dynamic _a = user.a_intent; // Was a switch-case, sorry for the mess.
			if ( _a=="disarm" ) {
				
				if ( !this.wielded ) {
					return base.attack( (object)(M), (object)(user), def_zone );
				}

				if ( !( M is Mob_Living_Carbon_Human ) ) {
					return base.attack( (object)(M), (object)(user), def_zone );
				}
				H2 = M;
				fluffmessages = new ByTable(new object [] { 
					"" + user + " clubs " + H2 + " with " + this + "!", 
					"" + user + " smacks " + H2 + " with the butt of " + this + "!", 
					"" + user + " broadsides " + H2 + " with " + this + "!", 
					"" + user + " smashes " + H2 + "'s head with " + this + "!", 
					"" + user + " beats " + H2 + " with front of " + this + "!", 
					"" + user + " twirls and slams " + H2 + " with " + this + "!"
				 });
				((Ent_Static)H2).visible_message( "<span class='warning'>" + Rand13.PickFromTable( fluffmessages ) + "</span>", "<span class='userdanger'>" + Rand13.PickFromTable( fluffmessages ) + "</span>" );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( user ), "sound/effects/woodhit.ogg", 75, 1, -1 );
				((Mob_Living)H2).adjustStaminaLoss( Rand13.Int( 13, 20 ) );

				if ( Rand13.PercentChance( 10 ) ) {
					((Ent_Static)H2).visible_message( "<span class='warning'>" + H2 + " collapses!</span>", "<span class='userdanger'>Your legs give out!</span>" );
					((Mob)H2).Weaken( 4 );
				}

				if ( Lang13.Bool( H2.staminaloss ) && !( H2.sleeping != 0 ) ) {
					total_health = Lang13.DoubleNullable( H2.health - H2.staminaloss );

					if ( ( total_health ??0) <= ( GlobalVars.config.health_threshold_crit ??0) && !Lang13.Bool( H2.stat ) ) {
						((Ent_Static)H2).visible_message( "<span class='warning'>" + user + " delivers a heavy hit to " + H2 + "'s head, knocking them out cold!</span>", "<span class='userdanger'>" + user + " knocks you unconscious!</span>" );
						((Mob)H2).SetSleeping( 30 );
						((Mob_Living)H2).adjustBrainLoss( 25 );
					}
				}
				return false;
			} else {
				return base.attack( (object)(M), (object)(user), def_zone );
			}
			return base.attack( (object)(M), (object)(user), def_zone );
		}

		// Function from file: martial.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			this.icon_state = "bostaff" + this.wielded;
			return false;
		}

	}

}