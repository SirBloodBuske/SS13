// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_BorgUpgradeVtec : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cyborg Upgrade (VTEC Module)";
			this.id = "borg_upgrade_vtec";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_Borg_Upgrade_Vtec);
			this.req_tech = new ByTable().Set( "engineering", 4 ).Set( "materials", 5 );
			this.materials = new ByTable().Set( "$metal", 80000 ).Set( "$glass", 6000 ).Set( "$uranium", 5000 );
			this.construction_time = 120;
			this.category = new ByTable(new object [] { "Cyborg Upgrade Modules" });
		}

	}

}