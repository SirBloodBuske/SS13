// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Zone_Asteroid_Artifactroom : Zone_Asteroid {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "cave";
		}

		// Function from file: Space Station 13 areas.dm
		public Zone_Asteroid_Artifactroom ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.SetDynamicLighting();
			return;
		}

	}

}