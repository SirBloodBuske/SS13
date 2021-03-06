// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Mineral_UnloadingMachine : Obj_Machinery_Mineral {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.input_dir = 8;
			this.output_dir = 4;
			this.icon = "icons/obj/machines/mining_machines.dmi";
			this.icon_state = "unloader";
		}

		public Obj_Machinery_Mineral_UnloadingMachine ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: tgstation.dme
		public override int? process( dynamic seconds = null ) {
			Tile T = null;
			int limit = 0;
			Obj_Structure_OreBox B = null;
			Obj_Item_Weapon_Ore O = null;
			Obj_Item I = null;

			T = Map13.GetStep( this, this.input_dir );

			if ( T != null ) {
				
				foreach (dynamic _b in Lang13.Enumerate( T, typeof(Obj_Structure_OreBox) )) {
					B = _b;
					

					foreach (dynamic _a in Lang13.Enumerate( B, typeof(Obj_Item_Weapon_Ore) )) {
						O = _a;
						
						B.contents.Remove( O );
						this.unload_mineral( O );
						limit++;

						if ( limit >= 10 ) {
							return null;
						}
					}
				}

				foreach (dynamic _c in Lang13.Enumerate( T, typeof(Obj_Item) )) {
					I = _c;
					
					this.unload_mineral( I );
					limit++;

					if ( limit >= 10 ) {
						return null;
					}
				}
			}
			return null;
		}

	}

}