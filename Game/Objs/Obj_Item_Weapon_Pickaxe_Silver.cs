// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Pickaxe_Silver : Obj_Item_Weapon_Pickaxe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "spickaxe";
			this.digspeed = 30;
			this.origin_tech = "materials=3;engineering=2";
			this.icon_state = "spickaxe";
		}

		public Obj_Item_Weapon_Pickaxe_Silver ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}