// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Fishfingers : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Fish fingers";
			this.reqs = new ByTable().Set( typeof(Reagent_Consumable_Flour), 5 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Bun), 1 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Carpmeat), 1 );
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Fishfingers);
			this.category = "Food";
		}

	}

}