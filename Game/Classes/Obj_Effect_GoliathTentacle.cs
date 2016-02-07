// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_GoliathTentacle : Obj_Effect {

		public bool latched = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/mob/animal.dmi";
			this.icon_state = "Goliath_tentacle";
		}

		// Function from file: mining_mobs.dm
		public Obj_Effect_GoliathTentacle ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic turftype = null;
			dynamic M = null;

			turftype = GlobalFuncs.get_turf( this );

			if ( turftype is Tile_Simulated_Mineral ) {
				M = turftype;
				((Tile_Simulated_Mineral)M).gets_drilled();
			}
			Task13.Schedule( 20, (Task13.Closure)(() => {
				this.Trip();
				return;
			}));
			return;
		}

		// Function from file: mining_mobs.dm
		public void Trip(  ) {
			Mob_Living M = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Mob_Living) )) {
				M = _a;
				
				this.visible_message( "<span class='danger'>The " + this.name + " grabs hold of " + M.name + "!</span>" );
				M.Stun( 5 );
				M.adjustBruteLoss( Rand13.Int( 10, 15 ) );
				this.latched = true;
			}

			if ( !this.latched ) {
				GlobalFuncs.qdel( this );
			} else {
				Task13.Schedule( 50, (Task13.Closure)(() => {
					GlobalFuncs.qdel( this );
					return;
				}));
			}
			return;
		}

	}

}