// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Storage_Labcoat_Chemist : Obj_Item_Clothing_Suit_Storage_Labcoat {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.base_icon_state = "labcoat_chem";
			this.species_fit = new ByTable(new object [] { "Vox" });
		}

		public Obj_Item_Clothing_Suit_Storage_Labcoat_Chemist ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}