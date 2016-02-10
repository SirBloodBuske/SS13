// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RuntimeError_UnknownInstruction : RuntimeError {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "UnknownInstructionError";
			this.message = "Unknown instruction type. This may be due to incompatible compiler and interpreter versions or a lack of implementation.";
		}

	}

}