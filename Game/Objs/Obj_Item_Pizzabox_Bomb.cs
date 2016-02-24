// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Pizzabox_Bomb : Obj_Item_Pizzabox {

		// Function from file: pizzabox.dm
		public Obj_Item_Pizzabox_Bomb ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic randompizza = null;

			randompizza = Rand13.PickFromTable( Lang13.GetTypes( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pizza) ) - typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pizza) );
			this.pizza = Lang13.Call( randompizza, this );
			this.bomb = new Obj_Item_Weapon_Bombcore_Pizza( this );
			this.wires = new Wires_Explosive_Pizza( this );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}