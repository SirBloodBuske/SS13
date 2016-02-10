// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Vending_Coffee : Obj_Machinery_Vending {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.product_ads = "Have a drink!;Drink up!;It's good for you!;Would you like a hot joe?;I'd kill for some coffee!;The best beans in the galaxy.;Only the finest brew for you.;Mmmm. Nothing like a coffee.;I like coffee, don't you?;Coffee helps you work!;Try some tea.;We hope you like the best!;Try our new chocolate!;Admin conspiracies";
			this.icon_vend = "coffee-vend";
			this.vend_delay = 34;
			this.products = new ByTable()
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_Coffee), 25 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_Tea), 25 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_HChocolate), 25 )
			;
			this.contraband = new ByTable().Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_Ice), 10 );
			this.prices = new ByTable()
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_Coffee), 25 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_Tea), 25 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_HChocolate), 25 )
			;
			this.pack = typeof(Obj_Structure_Vendomatpack_Coffee);
			this.icon_state = "coffee";
		}

		public Obj_Machinery_Vending_Coffee ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}