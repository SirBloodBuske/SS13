// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Door_Airlock_Gold : Obj_Machinery_Door_Airlock {

		public string mineral = "gold";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.doortype = typeof(Obj_Structure_DoorAssembly_DoorAssemblyGold);
			this.icon = "icons/obj/doors/airlocks/station/gold.dmi";
		}

		public Obj_Machinery_Door_Airlock_Gold ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}