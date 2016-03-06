// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Bullet_Sniper_Accelerator : Obj_Item_Projectile_Bullet_Sniper {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage = 5;
			this.breakthings = 0;
			this.icon_state = "gaussweak";
		}

		public Obj_Item_Projectile_Bullet_Sniper_Accelerator ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: sniper.dm
		public override void Range(  ) {
			base.Range();
			this.damage += 5;

			if ( this.damage > 40 ) {
				this.icon_state = "gaussstrong";
				this.breakthings = GlobalVars.TRUE;
			} else if ( this.damage > 25 ) {
				this.icon_state = "gauss";
			}
			return;
		}

	}

}