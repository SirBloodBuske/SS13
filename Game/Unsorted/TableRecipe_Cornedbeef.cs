// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Cornedbeef : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Corned beef";
			this.reqs = new ByTable()
				.Set( typeof(Reagent_Consumable_Sodiumchloride), 5 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Steak), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Cabbage), 2 )
			;
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cornedbeef);
			this.category = "Food";
		}

	}

}