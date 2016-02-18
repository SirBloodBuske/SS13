// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_OdysseusRightArm : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Right Arm (\"Odysseus\")";
			this.id = "odysseus_right_arm";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Part_OdysseusRightArm);
			this.materials = new ByTable().Set( "$metal", 6000 );
			this.construction_time = 120;
			this.category = new ByTable(new object [] { "Odysseus" });
		}

	}

}