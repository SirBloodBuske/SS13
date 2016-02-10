// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Mask_Cigarette_Blunt : Obj_Item_Clothing_Mask_Cigarette {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.overlay_on = "bluntlit";
			this.type_butt = typeof(Obj_Item_Weapon_Cigbutt_Bluntbutt);
			this.item_state = "blunt";
			this.attack_verb = new ByTable(new object [] { "burnt", "singed", "blunted" });
			this.smoketime = 420;
			this.chem_volume = 50;
			this.icon_state = "blunt";
		}

		public Obj_Item_Clothing_Mask_Cigarette_Blunt ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}