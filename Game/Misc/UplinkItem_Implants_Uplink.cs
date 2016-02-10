// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_Implants_Uplink : UplinkItem_Implants {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Uplink Implant";
			this.desc = "An implant injected into the body, and later activated using a bodily gesture to open an uplink with 5 telecrystals. The ability for an agent to open an uplink after their posessions have been stripped from them makes this implant excellent for escaping confinement.";
			this.item = typeof(Obj_Item_Weapon_Storage_Box_SyndieKit_ImpUplink);
			this.cost = 10;
		}

	}

}