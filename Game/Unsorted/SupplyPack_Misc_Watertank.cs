// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Misc_Watertank : SupplyPack_Misc {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Water Tank Crate";
			this.cost = 8;
			this.contains = new ByTable(new object [] { typeof(Obj_Structure_ReagentDispensers_Watertank) });
			this.crate_name = "water tank crate";
			this.crate_type = typeof(Obj_Structure_Closet_Crate_Large);
		}

	}

}