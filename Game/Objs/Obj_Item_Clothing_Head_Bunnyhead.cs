// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Bunnyhead : Obj_Item_Clothing_Head {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "bunnyhead";
			this.slowdown = -1;
			this.flags = 32768;
			this.flags_inv = 15;
			this.icon_state = "bunnyhead";
		}

		public Obj_Item_Clothing_Head_Bunnyhead ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}