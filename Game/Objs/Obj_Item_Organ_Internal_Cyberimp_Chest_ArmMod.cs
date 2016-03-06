// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Organ_Internal_Cyberimp_Chest_ArmMod : Obj_Item_Organ_Internal_Cyberimp_Chest {

		public Obj_Item_Weapon_Gun_Energy holder = null;
		public bool v_out = false;
		public bool overloaded = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.implant_color = "#007ACC";
			this.slot = "shoulders";
			this.origin_tech = "materials=5;biotech=4;powerstorage=4";
			this.organ_action_name = "Toggle Arm Mod";
		}

		public Obj_Item_Organ_Internal_Cyberimp_Chest_ArmMod ( dynamic M = null ) : base( (object)(M) ) {
			
		}

		// Function from file: augments_internal.dm
		public override double emp_act( int severity = 0 ) {
			
			if ( !Lang13.Bool( this.owner ) || this.overloaded ) {
				return 0;
			}

			if ( this.v_out ) {
				((Mob)this.owner).unEquip( this.holder, 1 );
				this.holder.loc = null;
				this.v_out = false;
				this.owner.WriteMsg( "<span class='warning'>" + this.holder + " forcibly retracts into your arm.</span>" );
			}
			((Ent_Static)this.owner).visible_message( "<span class='danger'>A loud bang comes from " + this.owner + "...</span>" );
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this.owner ), "sound/weapons/flashbang.ogg", 100, 1 );
			this.owner.WriteMsg( "<span class='warning'>You feel an explosion erupt inside you as your chest implant breaks. Is it hot in here?</span>" );
			((Mob_Living)this.owner).adjust_fire_stacks( 20 );
			this.owner.IgniteMob();
			((Ent_Dynamic)this.owner).say( "AUUUUUUUUUUUUUUUUUUGH!!" );
			((Mob_Living)this.owner).adjustFireLoss( 25 );
			this.overloaded = true;
			return 0;
		}

		// Function from file: augments_internal.dm
		public override void ui_action_click(  ) {
			
			if ( this.overloaded ) {
				this.owner.WriteMsg( "<span class='warning'>The implant doesn't respond. It seems to be broken...</span>" );
				return;
			}

			if ( this.holder == null ) {
				this.owner.WriteMsg( "<span class='warning'>You should not be attempting to use this implant, as it is a dummy item that should never appear. Please adminhelp and report this as an issue on github.</span>" );
				return;
			}

			if ( this.v_out ) {
				((Mob)this.owner).unEquip( this.holder, 1 );
				this.holder.loc = null;
				this.v_out = false;
				this.owner.WriteMsg( "<span class='notice'>You retract " + this.holder + ".</span>" );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this.owner ), "sound/mecha/mechmove03.ogg", 50, 1 );
			} else if ( ((Mob)this.owner).put_in_hands( this.holder ) ) {
				this.v_out = true;
				this.owner.WriteMsg( "<span class='notice'>You extend " + this.holder + "!</span>" );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this.owner ), "sound/mecha/mechmove03.ogg", 50, 1 );
			} else {
				this.holder.loc = null;
				this.owner.WriteMsg( "<span class='warning'>You can't extend " + this.holder + " if you can't use your hands!</span>" );
			}
			return;
		}

	}

}