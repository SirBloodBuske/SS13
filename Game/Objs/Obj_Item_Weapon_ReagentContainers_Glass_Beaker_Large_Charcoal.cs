// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Large_Charcoal : Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Large {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.list_reagents = new ByTable().Set( "charcoal", 50 );
		}

		public Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Large_Charcoal ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}