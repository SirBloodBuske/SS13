// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Beam : Obj_Item_Projectile {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.pass_flags = 7;
			this.damage = 20;
			this.damage_type = "fire";
			this.hitsound = "sound/weapons/sear.ogg";
			this.flag = "laser";
			this.eyeblur = 2;
			this.icon_state = "laser";
		}

		public Obj_Item_Projectile_Beam ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}