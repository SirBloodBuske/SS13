// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Captunic : Obj_Item_Clothing_Suit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "bio_suit";
			this.body_parts_covered = 510;
			this.species_fit = new ByTable(new object [] { "Vox" });
			this.icon_state = "captunic";
		}

		public Obj_Item_Clothing_Suit_Captunic ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}