// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Spur_Polarstar : Obj_Item_Projectile_Spur {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage = 20;
		}

		public Obj_Item_Projectile_Spur_Polarstar ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: bullets.dm
		public override bool OnFired(  ) {
			Obj_Item_Weapon_Gun_Energy_Polarstar quote = null;

			base.OnFired();
			quote = this.shot_from;

			if ( !( quote != null ) || !( quote is Obj_Item_Weapon_Gun_Energy_Polarstar ) ) {
				return false;
			}

			switch ((int)( quote.firelevel )) {
				case 4:
				case 3:
					this.icon_state = "spur_high";
					this.damage = 20;
					this.kill_count = 20;
					break;
				case 2:
					this.icon_state = "spur_medium";
					this.damage = 15;
					this.kill_count = 13;
					break;
				case 1:
				case 0:
					this.icon_state = "spur_low";
					this.damage = 10;
					this.kill_count = 7;
					break;
			}
			return false;
		}

	}

}