// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Recipe_Aesirsalad : Recipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.items = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Ambrosiavulgaris_Deus), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Ambrosiavulgaris_Deus), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Ambrosiavulgaris_Deus), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Goldapple)
			 });
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Aesirsalad);
			this.reagents_forbidden = new ByTable(new object [] { "synaptizine" });
		}

	}

}