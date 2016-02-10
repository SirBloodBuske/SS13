// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Power_PortGen_Pacman_Mrs : Obj_Machinery_Power_PortGen_Pacman {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.sheet_path = typeof(Obj_Item_Stack_Sheet_Mineral_Diamond);
			this.power_gen = 40000;
			this.time_per_sheet = 80;
			this.board_path = "/obj/item/weapon/circuitboard/pacman/mrs";
			this.icon_state = "portgen2";
		}

		public Obj_Machinery_Power_PortGen_Pacman_Mrs ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: port_gen.dm
		public override void overheat(  ) {
			GlobalFuncs.explosion( this.loc, 4, 4, 4, -1 );
			return;
		}

	}

}