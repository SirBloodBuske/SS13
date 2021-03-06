// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_StealthyTools_Syndigaloshes_Nuke : UplinkItem_StealthyTools_Syndigaloshes {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Tactical No-Slip Brown Shoes";
			this.desc = "These allow you to run on wet floors. They do not work on heavily lubricated surfaces, but the manufacturer guarantees they're somehow better than the normal ones.";
			this.cost = 4;
			this.include_modes = new ByTable(new object [] { typeof(GameMode_Nuclear) });
		}

	}

}