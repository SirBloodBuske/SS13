// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class MapGenerator_Ca_Caves : MapGenerator_Ca {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.b_rule = new ByTable(new object [] { 5, 6, 7, 8 });
			this.s_rule = new ByTable(new object [] { 4 });
			this.type_map = new ByTable(new object [] { typeof(Tile_Simulated_Floor_Plating_Asteroid_Basalt), typeof(Tile_Simulated_Mineral_Volcanic) });
			this.iterations = 5;
		}

	}

}