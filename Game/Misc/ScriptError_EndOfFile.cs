// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ScriptError_EndOfFile : ScriptError {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.message = "Unexpected end of file.";
		}

		public ScriptError_EndOfFile ( dynamic msg = null ) : base( (object)(msg) ) {
			
		}

	}

}