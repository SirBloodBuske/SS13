// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Floor_Vault : Tile_Simulated_Floor {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.floor_tile = typeof(Obj_Item_Stack_Tile_Plasteel);
			this.icon_state = "rockvault";
		}

		public Tile_Simulated_Floor_Vault ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}