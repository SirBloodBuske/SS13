// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Screen_Buildmode_Quit : Obj_Screen_Buildmode {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.screen_loc = "NORTH,WEST+3";
			this.icon_state = "buildquit";
		}

		public Obj_Screen_Buildmode_Quit ( dynamic bd = null ) : base( (object)(bd) ) {
			
		}

		// Function from file: buildmode.dm
		public override bool Click( dynamic loc = null, string control = null, string _params = null ) {
			((Buildmode)this.bd).quit();
			return true;
		}

	}

}