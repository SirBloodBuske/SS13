// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Honker_Chassis : Design_Honker {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Structure (H.O.N.K. chassis)";
			this.desc = "Used to build a H.O.N.K. chassis.";
			this.id = "honker_chassis";
			this.req_tech = new ByTable().Set( "combat", 1 );
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Chassis_Honker);
			this.category = "HONK";
			this.materials = new ByTable().Set( "$iron", 20000 );
		}

	}

}