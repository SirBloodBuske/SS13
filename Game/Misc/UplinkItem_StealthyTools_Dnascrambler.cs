// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_StealthyTools_Dnascrambler : UplinkItem_StealthyTools {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "DNA Scrambler";
			this.desc = "A syringe with one injection that randomizes appearance and name upon use. A cheaper but less versatile alternative to an agent card and voice changer.";
			this.item = typeof(Obj_Item_Weapon_Dnascrambler);
			this.cost = 2;
		}

	}

}