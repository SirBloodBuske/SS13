// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_MiningVoucher : Obj_Item_Weapon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 1;
			this.icon = "icons/obj/mining.dmi";
			this.icon_state = "mining_voucher";
		}

		public Obj_Item_Weapon_MiningVoucher ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}