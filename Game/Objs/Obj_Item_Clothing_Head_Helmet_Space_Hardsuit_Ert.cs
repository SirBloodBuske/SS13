// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Space_Hardsuit_Ert : Obj_Item_Clothing_Head_Helmet_Space_Hardsuit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "hardsuit0-ert_commander";
			this.item_color = "ert_commander";
			this.armor = new ByTable().Set( "melee", 65 ).Set( "bullet", 50 ).Set( "laser", 50 ).Set( "energy", 50 ).Set( "bomb", 50 ).Set( "bio", 100 ).Set( "rad", 100 );
			this.strip_delay = 130;
			this.flags = 40963;
			this.brightness_on = 7;
			this.icon_state = "hardsuit0-ert_commander";
		}

		public Obj_Item_Clothing_Head_Helmet_Space_Hardsuit_Ert ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}