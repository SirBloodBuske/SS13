// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ZASSetting_ConnectionTemperatureDelta : ZASSetting {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.value = 10;
			this.name = "Connections - Temperature Difference";
			this.desc = "The smallest temperature difference which will cause heat to travel through doors.";
			this.valtype = 1;
		}

	}

}