// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Unsimulated_Mineral_Bohrum : Tile_Unsimulated_Mineral {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.mineral = new Mineral_Bohrum();
			this.icon_state = "rock_Bohrum";
		}

		public Tile_Unsimulated_Mineral_Bohrum ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}