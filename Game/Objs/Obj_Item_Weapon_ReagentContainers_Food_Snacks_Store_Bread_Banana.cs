// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store_Bread_Banana : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store_Bread {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.slice_path = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Breadslice_Banana);
			this.bonus_reagents = new ByTable().Set( "nutriment", 5 ).Set( "banana", 20 );
			this.list_reagents = new ByTable().Set( "nutriment", 20 ).Set( "banana", 20 );
			this.icon_state = "bananabread";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store_Bread_Banana ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}