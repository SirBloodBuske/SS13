// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Portal_Wormhole : Obj_Effect_Portal {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/objects.dmi";
			this.icon_state = "anom";
		}

		public Obj_Effect_Portal_Wormhole ( dynamic loc = null, dynamic target = null, Obj_Item_Weapon creator = null, int? lifespan = null ) : base( (object)(loc), (object)(target), creator, lifespan ) {
			
		}

		// Function from file: wormholes.dm
		public override void teleport( dynamic M = null ) {
			Ent_Static target = null;
			dynamic P = null;

			
			if ( M is Obj_Effect ) {
				return;
			}

			if ( Lang13.Bool( M.anchored ) && M is Obj_Mecha ) {
				return;
			}

			if ( M is Ent_Dynamic ) {
				
				if ( GlobalVars.portals.len != 0 ) {
					P = Rand13.PickFromTable( GlobalVars.portals );

					if ( Lang13.Bool( P ) && P.loc is Tile ) {
						target = P.loc;
					}
				}

				if ( !( target != null ) ) {
					return;
				}
				GlobalFuncs.do_teleport( M, target, 1, true, false, false );
			}
			return;
		}

		// Function from file: wormholes.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			this.teleport( user );
			return null;
		}

		// Function from file: wormholes.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			this.teleport( a );
			return null;
		}

	}

}