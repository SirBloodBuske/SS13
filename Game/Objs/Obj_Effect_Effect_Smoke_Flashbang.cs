// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Effect_Smoke_Flashbang : Obj_Effect_Effect_Smoke {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.time_to_live = 10;
			this.icon_state = "sparks";
		}

		// Function from file: flashbang.dm
		public Obj_Effect_Effect_Smoke_Flashbang ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.set_light( 15 );
			return;
		}

	}

}