// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Camera : Obj_Machinery_Computer {

		public Obj_Machinery_Computer_Camera ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: adv_camera.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			base.Destroy( (object)(brokenup) );
			GlobalVars.html_machines.Remove( this );
			return null;
		}

	}

}