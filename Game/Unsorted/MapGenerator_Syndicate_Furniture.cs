// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class MapGenerator_Syndicate_Furniture : MapGenerator_Syndicate {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.modules = new ByTable(new object [] { 
				typeof(MapGeneratorModule_BottomLayer_SyndieFloor), 
				typeof(MapGeneratorModule_Border_SyndieWalls), 
				typeof(MapGeneratorModule_SyndieFurniture), 
				typeof(MapGeneratorModule_BottomLayer_Repressurize)
			 });
		}

	}

}