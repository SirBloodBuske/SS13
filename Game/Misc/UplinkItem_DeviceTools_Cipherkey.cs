// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_DeviceTools_Cipherkey : UplinkItem_DeviceTools {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Centcomm Encryption Key";
			this.desc = "A key, that when inserted into a radio headset, allows you to listen to and talk on all known radio channels.";
			this.item = typeof(Obj_Item_Device_Encryptionkey_Syndicate_Hacked);
			this.cost = 2;
		}

	}

}