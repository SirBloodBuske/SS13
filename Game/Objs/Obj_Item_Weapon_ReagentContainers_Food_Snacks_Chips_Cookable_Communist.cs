// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Chips_Cookable_Communist : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Chips_Cookable {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "commie_chips";
			this.icon_state = "commie_chips";
		}

		// Function from file: snacks.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Chips_Cookable_Communist ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			((Reagents)this.reagents).add_reagent( "nutriment", 5 );
			((Reagents)this.reagents).add_reagent( "vodka", 5 );
			this.bitesize = 2;
			return;
		}

	}

}