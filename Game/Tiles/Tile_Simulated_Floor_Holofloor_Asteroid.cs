// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Floor_Holofloor_Asteroid : Tile_Simulated_Floor_Holofloor {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "asteroid0";
		}

		// Function from file: turfs.dm
		public Tile_Simulated_Floor_Holofloor_Asteroid ( dynamic loc = null ) : base( (object)(loc) ) {
			this.icon_state = "asteroid" + Rand13.Pick(new object [] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 });
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}