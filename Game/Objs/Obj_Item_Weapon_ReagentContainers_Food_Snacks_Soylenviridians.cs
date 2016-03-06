// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soylenviridians : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.trash = typeof(Obj_Item_Trash_Waffles);
			this.bonus_reagents = new ByTable().Set( "vitamin", 1 );
			this.list_reagents = new ByTable().Set( "nutriment", 10 ).Set( "vitamin", 1 );
			this.filling_color = "#9ACD32";
			this.icon_state = "soylent_yellow";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Soylenviridians ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}