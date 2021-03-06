// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_BluespaceCell : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Bluespace Power Cell";
			this.desc = "A power cell that holds 40000 units of energy.";
			this.id = "bluespace_cell";
			this.req_tech = new ByTable().Set( "powerstorage", 6 ).Set( "materials", 5 );
			this.reliability = 70;
			this.build_type = 18;
			this.materials = new ByTable().Set( "$metal", 800 ).Set( "$gold", 300 ).Set( "$silver", 300 ).Set( "$glass", 160 ).Set( "$diamond", 160 );
			this.construction_time = 100;
			this.build_path = typeof(Obj_Item_Weapon_StockParts_Cell_Bluespace);
			this.category = new ByTable(new object [] { "Misc", "Power Designs" });
		}

	}

}