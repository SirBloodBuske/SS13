// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_FirealarmElectronics : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Fire alarm electronics";
			this.id = "firealarm_electronics";
			this.build_type = 4;
			this.materials = new ByTable().Set( "$metal", 50 ).Set( "$glass", 50 );
			this.build_path = typeof(Obj_Item_Weapon_Electronics_Firealarm);
			this.category = new ByTable(new object [] { "initial", "Electronics" });
		}

	}

}