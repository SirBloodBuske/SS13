// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Disposalpipe_Broken : Obj_Structure_Disposalpipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "pipe-b";
		}

		// Function from file: disposal.dm
		public Obj_Structure_Disposalpipe_Broken ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.update();
			return;
		}

		// Function from file: disposal.dm
		public override void welded(  ) {
			GlobalFuncs.qdel( this );
			return;
		}

	}

}