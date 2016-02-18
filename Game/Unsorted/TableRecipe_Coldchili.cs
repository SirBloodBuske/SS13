// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Coldchili : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cold chili";
			this.reqs = new ByTable()
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bowl), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Cutlet), 2 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Icepepper), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tomato), 1 )
			;
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup_Coldchili);
			this.category = "Food";
		}

	}

}