// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Whitedress : Obj_Item_Clothing_Suit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "w_suit";
			this.body_parts_covered = 126;
			this.flags_inv = 12;
			this.icon_state = "white_dress";
		}

		public Obj_Item_Clothing_Suit_Whitedress ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}