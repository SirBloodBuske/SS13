// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoCasing_Energy_ChronoBeam : Obj_Item_AmmoCasing_Energy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.projectile_type = typeof(Obj_Item_Projectile_Energy_ChronoBeam);
			this.e_cost = 0;
			this.icon_state = "chronobolt";
		}

		public Obj_Item_AmmoCasing_Energy_ChronoBeam ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}