// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cheesewedge : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.filling_color = "#FFD700";
			this.list_reagents = new ByTable().Set( "nutriment", 3 ).Set( "vitamin", 1 );
			this.icon_state = "cheesewedge";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cheesewedge ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}