// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Pizzabox_Margherita : Obj_Item_Pizzabox {

		// Function from file: snacks.dm
		public Obj_Item_Pizzabox_Margherita ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.pizza = new Obj_Item_Weapon_ReagentContainers_Food_Snacks_Sliceable_Pizza_Margherita( this );
			this.boxtag = "Margherita Deluxe";
			return;
		}

	}

}