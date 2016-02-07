// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class AIModule_Large_UpgradeCameras : AIModule_Large {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.module_name = "Upgrade Camera Network";
			this.mod_pick_name = "upgradecam";
			this.description = "Install broad-spectrum scanning and electrical redundancy firmware to the camera network, enabling EMP-Proofing and light-amplified X-ray vision.";
			this.one_time = true;
			this.cost = 35;
			this.power_type = typeof(Mob_Living_Silicon_Ai).GetMethod( "upgrade_cameras" );
		}

	}

}