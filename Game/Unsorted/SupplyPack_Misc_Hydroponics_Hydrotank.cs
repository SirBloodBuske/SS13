// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Misc_Hydroponics_Hydrotank : SupplyPack_Misc_Hydroponics {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Hydroponics Backpack Crate";
			this.cost = 10;
			this.access = 35;
			this.contains = new ByTable(new object [] { typeof(Obj_Item_Weapon_Watertank) });
			this.crate_name = "hydroponics backpack crate";
			this.crate_type = typeof(Obj_Structure_Closet_Crate_Secure);
		}

	}

}