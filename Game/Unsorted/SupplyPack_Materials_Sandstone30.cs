// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Materials_Sandstone30 : SupplyPack_Materials {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "30 Sandstone Blocks";
			this.cost = 20;
			this.contains = new ByTable(new object [] { typeof(Obj_Item_Stack_Sheet_Mineral_Sandstone_Thirty) });
			this.crate_name = "sandstone blocks crate";
		}

	}

}