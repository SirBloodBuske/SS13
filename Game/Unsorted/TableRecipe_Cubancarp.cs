// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Cubancarp : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cuban carp";
			this.reqs = new ByTable()
				.Set( typeof(Reagent_Consumable_Flour), 5 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Chili), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Carpmeat), 1 )
			;
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cubancarp);
			this.category = "Food";
		}

	}

}