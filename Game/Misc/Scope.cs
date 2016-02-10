// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Scope : Game_Data {

		public Scope parent = null;
		public Node_BlockDefinition block = null;
		public ByTable functions = null;
		public ByTable variables = null;

		// Function from file: Scope.dm
		public Scope ( Node_BlockDefinition B = null, Scope parent = null ) {
			this.block = B;
			this.parent = parent;
			this.variables = B.initial_variables.Copy();
			this.functions = B.functions.Copy();
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}