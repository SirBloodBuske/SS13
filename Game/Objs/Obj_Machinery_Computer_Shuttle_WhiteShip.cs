// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Shuttle_WhiteShip : Obj_Machinery_Computer_Shuttle {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.circuit = typeof(Obj_Item_Weapon_Circuitboard_WhiteShip);
			this.shuttleId = "whiteship";
			this.possible_destinations = "whiteship_away;whiteship_home;whiteship_z4";
		}

		public Obj_Machinery_Computer_Shuttle_WhiteShip ( dynamic location = null, dynamic C = null ) : base( (object)(location), (object)(C) ) {
			
		}

	}

}