// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Vodka_Badminka : Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Vodka {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.list_reagents = new ByTable().Set( "vodka", 100 );
			this.icon_state = "badminka";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Vodka_Badminka ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}