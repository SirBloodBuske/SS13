// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup_Vegetable : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bonus_reagents = new ByTable().Set( "nutriment", 1 ).Set( "vitamin", 4 );
			this.icon_state = "vegetablesoup";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup_Vegetable ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}