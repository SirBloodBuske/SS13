// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Radio_Headset_HeadsetRob : Obj_Item_Device_Radio_Headset {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.keyslot = new Obj_Item_Device_Encryptionkey_HeadsetRob();
			this.icon_state = "rob_headset";
		}

		public Obj_Item_Device_Radio_Headset_HeadsetRob ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}