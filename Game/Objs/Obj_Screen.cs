// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Screen : Obj {

		public Obj_Item_Weapon master = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.unacidable = true;
			this.icon = "icons/mob/screen_gen.dmi";
			this.layer = 20;
		}

		public Obj_Screen ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: screen_objects.dm
		public override dynamic Destroy(  ) {
			this.master = null;
			return base.Destroy();
		}

	}

}