// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Dynamic_Light : Ent_Dynamic {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.blend_mode = 1;
			this.invisibility = 20;
			this.color = "#000";
			this.luminosity = 0;
			this.infra_luminosity = 1;
			this.anchored = 1;
			this.icon = "icons/effects/alphacolors.dmi";
			this.icon_state = "white";
			this.layer = 15;
		}

		public Dynamic_Light ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: lighting_system.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			return false;
		}

		// Function from file: lighting_system.dm
		public override dynamic Destroy(  ) {
			return 1;
		}

	}

}