// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_GygaxArmor : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Armor (\"Gygax\")";
			this.id = "gygax_armor";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Part_GygaxArmor);
			this.materials = new ByTable().Set( "$metal", 25000 ).Set( "$diamond", 10000 );
			this.construction_time = 600;
			this.category = new ByTable(new object [] { "Gygax" });
		}

	}

}