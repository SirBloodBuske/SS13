// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoCasing_Caseless_Magspear : Obj_Item_AmmoCasing_Caseless {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.projectile_type = typeof(Obj_Item_Projectile_Bullet_Reusable_Magspear);
			this.caliber = "speargun";
			this.throwforce = 15;
			this.throw_speed = 3;
			this.icon_state = "magspear";
		}

		public Obj_Item_AmmoCasing_Caseless_Magspear ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}