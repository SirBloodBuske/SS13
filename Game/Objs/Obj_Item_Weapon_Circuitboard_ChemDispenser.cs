// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_ChemDispenser : Obj_Item_Weapon_Circuitboard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = "/obj/machinery/chem_dispenser";
			this.board_type = "machine";
			this.origin_tech = "programming=3;biotech=5;engineering=4";
			this.frame_desc = "Requires 2 manipulators, 2 scanning modules, 3 micro-lasers, and 1 console screen.";
			this.req_components = new ByTable()
				.Set( "/obj/item/weapon/stock_parts/scanning_module", 2 )
				.Set( "/obj/item/weapon/stock_parts/manipulator", 2 )
				.Set( "/obj/item/weapon/stock_parts/micro_laser", 3 )
				.Set( "/obj/item/weapon/stock_parts/console_screen", 1 )
			;
		}

		public Obj_Item_Weapon_Circuitboard_ChemDispenser ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}