// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Unsimulated_Floor : Tile_Unsimulated {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/turf/snow.dmi";
			this.icon_state = "gravsnow_corner";
			this.dir = 1;
		}

		public Tile_Unsimulated_Floor ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: floor.dm
		public override void cultify(  ) {
			
			if ( this.icon_state != "cult" && this.icon_state != "cult-narsie" ) {
				this.name = "engraved floor";
				this.icon_state = "cult";
				this.turf_animation( "icons/effects/effects.dmi", "cultfloor", 0, 0, 3 );
			}
			return;
		}

		// Function from file: floor.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: floor.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {

			switch ((int?)(severity)) {
				case 1:
					new Obj_Effect_Decal_Cleanable_Soot( this );
					break;
				case 2:
					
					if ( Rand13.PercentChance( 65 ) ) {
						new Obj_Effect_Decal_Cleanable_Soot( this );
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 20 ) ) {
						new Obj_Effect_Decal_Cleanable_Soot( this );
					}
					return false;
					break;
			}
			return false;
		}

	}

}