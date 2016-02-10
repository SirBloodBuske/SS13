// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_RustFuelCompressor : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Circuit Design (R-UST Mk. 7 fuel compressor)";
			this.desc = "Allows for the construction of circuit boards used to build a fuel compressor of the R-UST Mk. 7 fusion engine.";
			this.id = "rust_fuel_compressor";
			this.req_tech = new ByTable().Set( "materials", 6 ).Set( "plasmatech", 4 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 2000 ).Set( "sacid", 20 ).Set( "$plasma", 3000 ).Set( "$diamond", 1000 );
			this.build_path = "/obj/item/weapon/module/rust_fuel_compressor";
		}

	}

}