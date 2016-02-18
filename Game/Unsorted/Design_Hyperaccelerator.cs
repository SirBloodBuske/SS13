// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Hyperaccelerator : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Hyper-Kinetic Accelerator";
			this.desc = "An upgraded version of the proto-kinetic accelerator, with even more superior damage, speed and range.";
			this.id = "hyperaccelerator";
			this.req_tech = new ByTable().Set( "materials", 6 ).Set( "powerstorage", 6 ).Set( "engineering", 5 ).Set( "magnets", 6 ).Set( "combat", 4 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 8000 ).Set( "$glass", 1500 ).Set( "$silver", 2000 ).Set( "$gold", 2000 ).Set( "$diamond", 2000 );
			this.build_path = typeof(Obj_Item_Weapon_Gun_Energy_KineticAccelerator_Hyper);
			this.category = new ByTable(new object [] { "Mining Designs" });
		}

	}

}