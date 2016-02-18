// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_MechRepairDroid : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Module (Repair Droid Module)";
			this.desc = "Automated Repair Droid. BEEP BOOP";
			this.id = "mech_repair_droid";
			this.build_type = 16;
			this.req_tech = new ByTable().Set( "magnets", 3 ).Set( "programming", 3 ).Set( "engineering", 3 );
			this.build_path = typeof(Obj_Item_MechaParts_MechaEquipment_RepairDroid);
			this.materials = new ByTable().Set( "$metal", 10000 ).Set( "$glass", 5000 ).Set( "$gold", 1000 ).Set( "$silver", 2000 );
			this.construction_time = 100;
			this.category = new ByTable(new object [] { "Exosuit Equipment" });
		}

	}

}