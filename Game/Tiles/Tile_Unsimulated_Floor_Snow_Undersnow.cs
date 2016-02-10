// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Unsimulated_Floor_Snow_Undersnow : Tile_Unsimulated_Floor_Snow {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.canSmoothWith = "/turf/unsimulated/floor/snow/undersnow";
		}

		// Function from file: floor.dm
		public Tile_Unsimulated_Floor_Snow_Undersnow ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.snowballs = 0;
			return;
		}

		// Function from file: floor.dm
		public override int canBuildPlating( Obj_Item_Stack_Tile_Wood material = null ) {
			
			if ( this.x >= Game13.map_size_x - 7 || this.x <= 7 ) {
				return 0;
			} else if ( this.y >= ( Game13.map_size_y - 7 != 0 || this.y <= 7 ?1:0) ) {
				return 0;
			} else if ( Lang13.Bool( Lang13.FindIn( typeof(Obj_Structure_Lattice), this.contents ) ) ) {
				return 1;
			}
			return 0;
		}

		// Function from file: floor.dm
		public override bool canBuildLattice( Obj_Item_Stack material = null ) {
			
			if ( this.x >= Game13.map_size_x - 7 || this.x <= 7 ) {
				return false;
			} else if ( this.y >= ( Game13.map_size_y - 7 != 0 || this.y <= 7 ?1:0) ) {
				return false;
			} else if ( !Lang13.Bool( Lang13.FindIn( typeof(Obj_Structure_Lattice), this.contents ) ) ) {
				return true;
			}
			return false;
		}

		// Function from file: floor.dm
		public override dynamic canBuildCatwalk(  ) {
			return 0;
		}

		// Function from file: floor.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			int junction = 0;
			int dircount = 0;
			dynamic direction = null;

			base.update_icon( (object)(location), (object)(target) );
			junction = this.findSmoothingNeighbors();
			dircount = 0;

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.diagonal )) {
				direction = _a;
				

				if ( Map13.GetStep( this, Convert.ToInt32( direction ) ) is Tile_Unsimulated_Floor_Snow_Undersnow ) {
					
					if ( ( direction & junction ) == direction ) {
						this.overlays.Add( GlobalVars.dirtlayers["diag" + direction] );
						dircount += 1;
					}
				}
			}

			if ( dircount == 4 ) {
				this.overlays.Cut();
				this.icon_state = "snowpath-Full";
				this.overlays.Add( GlobalVars.snowlayers["1"] );
				this.overlays.Add( GlobalVars.snowlayers["2"] );
			} else if ( junction != 0 ) {
				this.overlays.Add( GlobalVars.dirtlayers["snow" + junction] );
			} else {
				this.overlays.Add( GlobalVars.dirtlayers["snow0"] );
			}
			return null;
		}

	}

}