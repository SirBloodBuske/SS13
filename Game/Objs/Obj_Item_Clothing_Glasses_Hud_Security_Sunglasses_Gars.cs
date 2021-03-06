// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Glasses_Hud_Security_Sunglasses_Gars : Obj_Item_Clothing_Glasses_Hud_Security_Sunglasses {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "garb";
			this.force = 10;
			this.throwforce = 10;
			this.throw_speed = 4;
			this.attack_verb = new ByTable(new object [] { "sliced" });
			this.hitsound = "sound/weapons/bladeslice.ogg";
			this.sharpness = 1;
			this.icon_state = "gars";
		}

		public Obj_Item_Clothing_Glasses_Hud_Security_Sunglasses_Gars ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}