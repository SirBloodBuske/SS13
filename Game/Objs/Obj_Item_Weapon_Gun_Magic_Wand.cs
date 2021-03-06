// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Magic_Wand : Obj_Item_Weapon_Gun_Magic {

		public bool variable_charges = true;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.ammo_type = typeof(Obj_Item_AmmoCasing_Magic);
			this.item_state = "wand";
			this.w_class = 2;
			this.can_charge = false;
			this.max_charges = 100;
			this.icon_state = "nothingwand";
		}

		// Function from file: wand.dm
		public Obj_Item_Weapon_Gun_Magic_Wand ( dynamic loc = null ) : base( (object)(loc) ) {
			
			if ( Rand13.PercentChance( 75 ) && this.variable_charges ) {
				
				if ( Rand13.PercentChance( 33 ) ) {
					this.max_charges = GlobalFuncs.Ceiling( this.max_charges / 3 );
				} else {
					this.max_charges = GlobalFuncs.Ceiling( this.max_charges / 2 );
				}
			}
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: wand.dm
		public virtual void zap_self( dynamic user = null ) {
			((Ent_Static)user).visible_message( new Txt( "<span class='danger'>" ).item( user ).str( " zaps " ).himself_herself_itself_themself().str( " with " ).item( this ).str( ".</span>" ).ToString() );
			GlobalFuncs.playsound( user, this.fire_sound, 50, 1 );
			user.attack_log += new Txt( "[" ).item( GlobalFuncs.time_stamp() ).str( "] <b>" ).item( user ).str( "/" ).item( user.ckey ).str( "</b> zapped " ).himself_herself_itself_themself().str( " with a <b>" ).item( this ).str( "</b>" ).ToString();
			return;
		}

		// Function from file: wand.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			dynamic A = null;

			
			if ( !Lang13.Bool( this.charges ) ) {
				this.shoot_with_empty_chamber( user );
				return false;
			}

			if ( target == user ) {
				
				if ( this.no_den_usage ) {
					A = GlobalFuncs.get_area( user );

					if ( A is Zone_WizardStation ) {
						user.WriteMsg( "<span class='warning'>You know better than to violate the security of The Den, best wait until you leave to use " + this + ".<span>" );
						return false;
					} else {
						this.no_den_usage = false;
					}
				}
				this.zap_self( user );
			} else {
				base.afterattack( (object)(target), (object)(user), proximity_flag, click_parameters );
			}
			this.update_icon();
			return false;
		}

		// Function from file: wand.dm
		public override bool attack( dynamic M = null, dynamic user = null, bool? def_zone = null ) {
			
			if ( M == user ) {
				return false;
			}
			base.attack( (object)(M), (object)(user), def_zone );
			return false;
		}

		// Function from file: wand.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			this.icon_state = "" + Lang13.Initial( this, "icon_state" ) + ( Lang13.Bool( this.charges ) ? "" : "-drained" );
			return false;
		}

		// Function from file: wand.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );
			user.WriteMsg( new Txt( "Has " ).item( this.charges ).str( " charge" ).s().str( " remaining." ).ToString() );
			return 0;
		}

	}

}