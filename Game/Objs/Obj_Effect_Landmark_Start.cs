// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Landmark_Start : Obj_Effect_Landmark {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "x";
		}

		// Function from file: landmarks.dm
		public Obj_Effect_Landmark_Start ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.tag = "start*" + this.name;
			this.invisibility = 101;
			return; // Warning! Attempt to return some other value!
		}

	}

}