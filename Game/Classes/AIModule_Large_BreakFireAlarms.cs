// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class AIModule_Large_BreakFireAlarms : AIModule_Large {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.module_name = "Thermal Sensor Override";
			this.mod_pick_name = "burnpigs";
			this.description = "Gives you the ability to override the thermal sensors on all fire alarms. This will remove their ability to scan for fire and thus their ability to alert. Anyone can check the fire alarm's interface and may be tipped off by its status.";
			this.one_time = true;
			this.cost = 25;
			this.power_type = typeof(Mob_Living_Silicon_Ai).GetMethod( "break_fire_alarms" );
		}

	}

}