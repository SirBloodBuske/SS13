// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoCasing_A40mm : Obj_Item_AmmoCasing {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.caliber = "40mm";
			this.projectile_type = typeof(Obj_Item_Projectile_Bullet_A40mm);
			this.icon_state = "40mmHE";
		}

		public Obj_Item_AmmoCasing_A40mm ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}