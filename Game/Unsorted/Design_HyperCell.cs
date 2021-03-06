// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_HyperCell : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Hyper-Capacity Power Cell";
			this.desc = "A power cell that holds 30000 units of energy.";
			this.id = "hyper_cell";
			this.req_tech = new ByTable().Set( "powerstorage", 5 ).Set( "materials", 4 );
			this.reliability = 70;
			this.build_type = 18;
			this.materials = new ByTable().Set( "$metal", 400 ).Set( "$gold", 150 ).Set( "$silver", 150 ).Set( "$glass", 80 );
			this.construction_time = 100;
			this.build_path = typeof(Obj_Item_Weapon_StockParts_Cell_Hyper);
			this.category = new ByTable(new object [] { "Misc", "Power Designs" });
		}

	}

}