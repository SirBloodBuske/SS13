// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Smartfridge : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Machine Design (Smartfridge Board)";
			this.desc = "The circuit board for a smartfridge.";
			this.id = "smartfridge";
			this.req_tech = new ByTable().Set( "programming", 1 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_Smartfridge);
			this.category = new ByTable(new object [] { "Misc. Machinery" });
		}

	}

}