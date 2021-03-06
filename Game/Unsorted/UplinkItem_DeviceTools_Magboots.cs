// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_DeviceTools_Magboots : UplinkItem_DeviceTools {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Blood-Red Magboots";
			this.desc = "A pair of magnetic boots with a Syndicate paintjob that assist with freer movement in space or on-station during gravitational generator failures. These reverse-engineered knockoffs of Nanotrasen's 'Advanced Magboots' slow you down in simulated-gravity environments much like the standard issue variety.";
			this.item = typeof(Obj_Item_Clothing_Shoes_Magboots_Syndie);
			this.cost = 3;
			this.include_modes = new ByTable(new object [] { typeof(GameMode_Nuclear) });
		}

	}

}