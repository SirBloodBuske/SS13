// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Under_Lawyer_Blue : Obj_Item_Clothing_Under_Lawyer {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "lawyer_blue";
			this._color = "lawyer_blue";
			this.species_fit = new ByTable(new object [] { "Vox" });
			this.icon_state = "lawyer_blue";
		}

		public Obj_Item_Clothing_Under_Lawyer_Blue ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}