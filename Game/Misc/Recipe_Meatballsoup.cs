// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Recipe_Meatballsoup : Recipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.reagents = new ByTable().Set( "water", 10 );
			this.items = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Faggot), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Carrot), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Potato)
			 });
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meatballsoup);
		}

	}

}