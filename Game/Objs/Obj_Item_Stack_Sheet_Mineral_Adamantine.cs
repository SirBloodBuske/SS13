// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack_Sheet_Mineral_Adamantine : Obj_Item_Stack_Sheet_Mineral {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.singular_name = "adamantine sheet";
			this.origin_tech = "materials=4";
			this.icon_state = "sheet-adamantine";
		}

		public Obj_Item_Stack_Sheet_Mineral_Adamantine ( dynamic loc = null, int? amount = null ) : base( (object)(loc), amount ) {
			
		}

	}

}