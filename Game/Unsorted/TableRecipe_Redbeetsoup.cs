// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Redbeetsoup : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Red beet soup";
			this.reqs = new ByTable()
				.Set( typeof(Reagent_Water), 10 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bowl), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Redbeet), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Cabbage), 1 )
			;
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup_Beet_Red);
			this.category = "Food";
		}

	}

}