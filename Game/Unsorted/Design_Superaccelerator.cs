// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Superaccelerator : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Super-Kinetic Accelerator";
			this.desc = "An upgraded version of the proto-kinetic accelerator, with superior damage, speed and range.";
			this.id = "superaccelerator";
			this.req_tech = new ByTable().Set( "materials", 5 ).Set( "powerstorage", 4 ).Set( "engineering", 4 ).Set( "magnets", 4 ).Set( "combat", 3 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 8000 ).Set( "$glass", 1500 ).Set( "$silver", 2000 ).Set( "$uranium", 2000 );
			this.build_path = typeof(Obj_Item_Weapon_Gun_Energy_KineticAccelerator_Super);
			this.category = new ByTable(new object [] { "Mining Designs" });
		}

	}

}