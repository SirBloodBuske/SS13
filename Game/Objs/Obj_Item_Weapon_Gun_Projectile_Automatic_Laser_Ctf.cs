// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Projectile_Automatic_Laser_Ctf : Obj_Item_Weapon_Gun_Projectile_Automatic_Laser {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.mag_type = typeof(Obj_Item_AmmoBox_Magazine_Recharge_Ctf);
			this.force = 50;
		}

		public Obj_Item_Weapon_Gun_Projectile_Automatic_Laser_Ctf ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}