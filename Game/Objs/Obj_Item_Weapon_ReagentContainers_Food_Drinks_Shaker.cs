// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Drinks_Shaker : Obj_Item_Weapon_ReagentContainers_Food_Drinks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.amount_per_transfer_from_this = 10;
			this.volume = 100;
			this.icon_state = "shaker";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Drinks_Shaker ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}