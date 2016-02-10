// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_ShieldCap : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Circuit Design (Experimental shield capacitor)";
			this.desc = "Allows for the construction of circuit boards used to build an experimental shielding capacitor.";
			this.id = "shield_cap";
			this.req_tech = new ByTable().Set( "magnets", 3 ).Set( "powerstorage", 4 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 2000 ).Set( "sacid", 20 ).Set( "$plasma", 10000 ).Set( "$diamond", 5000 ).Set( "$silver", 10000 );
			this.build_path = "/obj/machinery/shield_gen/external";
		}

	}

}