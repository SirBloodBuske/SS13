// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Glasses_Meson_Gar : Obj_Item_Clothing_Glasses_Meson {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "garm";
			this.force = 10;
			this.throwforce = 10;
			this.throw_speed = 4;
			this.attack_verb = new ByTable(new object [] { "sliced" });
			this.hitsound = "sound/weapons/bladeslice.ogg";
			this.sharpness = 1;
			this.icon_state = "garm";
		}

		public Obj_Item_Clothing_Glasses_Meson_Gar ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}