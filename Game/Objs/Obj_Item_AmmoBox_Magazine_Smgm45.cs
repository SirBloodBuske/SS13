// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoBox_Magazine_Smgm45 : Obj_Item_AmmoBox_Magazine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "combat=2";
			this.ammo_type = typeof(Obj_Item_AmmoCasing_C45);
			this.caliber = ".45";
			this.max_ammo = 20;
			this.icon_state = "c20r45-20";
		}

		public Obj_Item_AmmoBox_Magazine_Smgm45 ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: magazines.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			base.update_icon( (object)(new_state), (object)(new_icon), new_px, new_py );
			this.icon_state = "c20r45-" + Num13.Round( this.ammo_count(), 2 );
			return false;
		}

	}

}