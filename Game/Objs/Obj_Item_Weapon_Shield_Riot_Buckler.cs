// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Shield_Riot_Buckler : Obj_Item_Weapon_Shield_Riot {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "buckler";
			this.materials = new ByTable();
			this.burn_state = 0;
			this.block_chance = 30;
			this.icon_state = "buckler";
		}

		public Obj_Item_Weapon_Shield_Riot_Buckler ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}