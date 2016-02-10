// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ZASSetting_AirflowDelay : ZASSetting {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.value = 30;
			this.name = "Airflow Retrigger Delay";
			this.desc = "Time in deciseconds before things can be moved by airflow again.";
			this.valtype = 1;
		}

	}

}