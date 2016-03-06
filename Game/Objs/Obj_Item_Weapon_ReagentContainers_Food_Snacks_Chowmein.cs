// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Chowmein : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.trash = typeof(Obj_Item_Trash_Plate);
			this.bonus_reagents = new ByTable().Set( "nutriment", 3 ).Set( "vitamin", 4 );
			this.list_reagents = new ByTable().Set( "nutriment", 7 ).Set( "vitamin", 6 );
			this.icon = "icons/obj/food/pizzaspaghetti.dmi";
			this.icon_state = "chowmein";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Chowmein ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}