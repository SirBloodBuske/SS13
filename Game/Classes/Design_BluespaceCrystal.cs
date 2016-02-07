// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_BluespaceCrystal : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Artificial Bluespace Crystal";
			this.desc = "A small blue crystal with mystical properties.";
			this.id = "bluespace_crystal";
			this.req_tech = new ByTable().Set( "bluespace", 4 ).Set( "materials", 6 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$diamond", 1500 ).Set( "$plasma", 1500 );
			this.build_path = typeof(Obj_Item_Weapon_Ore_BluespaceCrystal_Artificial);
			this.category = new ByTable(new object [] { "Bluespace Designs" });
		}

	}

}