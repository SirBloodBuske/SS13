// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Thermomachine : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Machine Design (Freezer/Heater Board)";
			this.desc = "The circuit board for a freezer/heater.";
			this.id = "thermomachine";
			this.req_tech = new ByTable().Set( "programming", 3 ).Set( "plasmatech", 3 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_Thermomachine);
			this.category = new ByTable(new object [] { "Engineering Machinery" });
		}

	}

}