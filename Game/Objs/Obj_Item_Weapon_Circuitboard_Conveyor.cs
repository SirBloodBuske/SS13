// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_Conveyor : Obj_Item_Weapon_Circuitboard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = "/obj/machinery/conveyor";
			this.board_type = "machine";
			this.origin_tech = "engineering=2;programming=2";
			this.frame_desc = "Requires nothing.";
			this.req_components = new ByTable();
		}

		public Obj_Item_Weapon_Circuitboard_Conveyor ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}