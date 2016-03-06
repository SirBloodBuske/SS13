// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack_Tile_Wood : Obj_Item_Stack_Tile {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.singular_name = "wood floor tile";
			this.origin_tech = "biotech=1";
			this.turf_type = typeof(Tile_Simulated_Floor_Wood);
			this.burn_state = 0;
			this.icon_state = "tile-wood";
		}

		public Obj_Item_Stack_Tile_Wood ( dynamic loc = null, int? amount = null ) : base( (object)(loc), amount ) {
			
		}

	}

}