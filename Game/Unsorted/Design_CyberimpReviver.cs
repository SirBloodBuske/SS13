// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_CyberimpReviver : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Reviver implant";
			this.desc = "This implant will attempt to revive you if you lose consciousness. For the faint of heart!";
			this.id = "ci-reviver";
			this.req_tech = new ByTable().Set( "materials", 6 ).Set( "programming", 4 ).Set( "biotech", 7 ).Set( "syndicate", 4 );
			this.build_type = 18;
			this.construction_time = 60;
			this.materials = new ByTable().Set( "$metal", 200 ).Set( "$glass", 200 ).Set( "$gold", 500 ).Set( "$uranium", 1000 ).Set( "$diamond", 2000 );
			this.build_path = typeof(Obj_Item_Organ_Internal_Cyberimp_Chest_Reviver);
			this.category = new ByTable(new object [] { "Misc", "Medical Designs" });
		}

	}

}