// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Power_Battery_Smes_Infinite : Obj_Machinery_Power_Battery_Smes {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.infinite_power = true;
			this.mech_flags = 1;
		}

		public Obj_Machinery_Power_Battery_Smes_Infinite ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}