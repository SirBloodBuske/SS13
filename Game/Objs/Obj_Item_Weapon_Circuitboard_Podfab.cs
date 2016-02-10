// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_Podfab : Obj_Item_Weapon_Circuitboard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = "/obj/machinery/r_n_d/fabricator/pod";
			this.board_type = "machine";
			this.origin_tech = "programming=3;engineering=3";
			this.frame_desc = "Requires 3 Matter Bins, 2 Manipulators, and 2 Micro-Lasers.";
			this.req_components = new ByTable().Set( "/obj/item/weapon/stock_parts/matter_bin", 3 ).Set( "/obj/item/weapon/stock_parts/manipulator", 2 ).Set( "/obj/item/weapon/stock_parts/micro_laser", 2 );
		}

		public Obj_Item_Weapon_Circuitboard_Podfab ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}