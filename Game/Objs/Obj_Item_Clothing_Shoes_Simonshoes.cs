// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Shoes_Simonshoes : Obj_Item_Clothing_Shoes {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "simonshoes";
			this.species_fit = new ByTable(new object [] { "Vox" });
			this.icon_state = "simonshoes";
		}

		public Obj_Item_Clothing_Shoes_Simonshoes ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}