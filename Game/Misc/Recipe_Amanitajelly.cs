// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Recipe_Amanitajelly : Recipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.reagents = new ByTable().Set( "water", 5 ).Set( "vodka", 5 );
			this.items = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom_Amanita), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom_Amanita), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Mushroom_Amanita)
			 });
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Amanitajelly);
		}

		// Function from file: recipes_microwave.dm
		public override dynamic make_food( Obj_Machinery_Microwave container = null ) {
			dynamic being_cooked = null;

			being_cooked = base.make_food( container );
			((Reagents)being_cooked.reagents).del_reagent( "amatoxin" );
			return being_cooked;
		}

	}

}