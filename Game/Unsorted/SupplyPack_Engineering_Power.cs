// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Engineering_Power : SupplyPack_Engineering {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Powercell Crate";
			this.cost = 10;
			this.contains = new ByTable(new object [] { typeof(Obj_Item_Weapon_StockParts_Cell_High), typeof(Obj_Item_Weapon_StockParts_Cell_High), typeof(Obj_Item_Weapon_StockParts_Cell_High) });
			this.crate_name = "electrical maintenance crate";
		}

	}

}