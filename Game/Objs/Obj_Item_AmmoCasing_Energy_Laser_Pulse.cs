// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoCasing_Energy_Laser_Pulse : Obj_Item_AmmoCasing_Energy_Laser {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.projectile_type = typeof(Obj_Item_Projectile_Beam_Pulse);
			this.e_cost = 200;
			this.select_name = "DESTROY";
			this.fire_sound = "sound/weapons/pulse.ogg";
		}

		public Obj_Item_AmmoCasing_Energy_Laser_Pulse ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}