// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_StockParts_MatterBin_Adv_Super : Obj_Item_Weapon_StockParts_MatterBin_Adv {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "materials=5";
			this.rating = 3;
			this.starting_materials = new ByTable().Set( "$plastic", 300 );
			this.icon_state = "super_matter_bin";
		}

		public Obj_Item_Weapon_StockParts_MatterBin_Adv_Super ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}