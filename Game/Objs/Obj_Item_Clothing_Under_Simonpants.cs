// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Under_Simonpants : Obj_Item_Clothing_Under {

		protected override void __FieldInit() {
			base.__FieldInit();

			this._color = "simonpants";
			this.item_state = "spants";
			this.species_fit = new ByTable(new object [] { "Vox" });
			this.icon_state = "spants";
		}

		public Obj_Item_Clothing_Under_Simonpants ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}