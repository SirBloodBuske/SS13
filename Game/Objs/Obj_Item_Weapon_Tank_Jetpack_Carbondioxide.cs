// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Tank_Jetpack_Carbondioxide : Obj_Item_Weapon_Tank_Jetpack {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "jetpack-black";
			this.distribute_pressure = 0;
			this.gas_type = "co2";
			this.icon_state = "jetpack-black";
		}

		public Obj_Item_Weapon_Tank_Jetpack_Carbondioxide ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}