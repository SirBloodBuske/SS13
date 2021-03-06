// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cubancarp : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.trash = typeof(Obj_Item_Trash_Plate);
			this.bonus_reagents = new ByTable().Set( "nutriment", 1 ).Set( "vitamin", 4 );
			this.bitesize = 3;
			this.filling_color = "#CD853F";
			this.list_reagents = new ByTable().Set( "nutriment", 6 ).Set( "capsaicin", 1 );
			this.icon_state = "cubancarp";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cubancarp ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}