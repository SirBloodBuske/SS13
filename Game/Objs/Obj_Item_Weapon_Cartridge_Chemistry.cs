// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Cartridge_Chemistry : Obj_Item_Weapon_Cartridge {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.access_reagent_scanner = true;
			this.icon_state = "cart-chem";
		}

		public Obj_Item_Weapon_Cartridge_Chemistry ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}