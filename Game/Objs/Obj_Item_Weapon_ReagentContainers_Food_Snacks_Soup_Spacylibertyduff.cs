// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup_Spacylibertyduff : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bitesize = 3;
			this.bonus_reagents = new ByTable().Set( "nutriment", 1 ).Set( "vitamin", 5 );
			this.list_reagents = new ByTable().Set( "nutriment", 6 ).Set( "mushroomhallucinogen", 6 );
			this.icon_state = "spacylibertyduff";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soup_Spacylibertyduff ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}