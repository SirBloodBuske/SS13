// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Energy_Laser_Blaster : Obj_Item_Weapon_Gun_Energy_Laser {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.fire_sound = "sound/weapons/blaster-storm.ogg";
			this.icon_state = "blaster";
		}

		// Function from file: laser.dm
		public Obj_Item_Weapon_Gun_Energy_Laser_Blaster ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( Rand13.PercentChance( 50 ) ) {
				this.charge_cost = 0;
				this.projectile_type = typeof(Obj_Item_Projectile_Beam_Practice_Stormtrooper);
				this.desc = "Don't expect to hit anything with this.";
			}
			return;
		}

		// Function from file: laser.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			return null;
		}

	}

}