// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_Jobspecific_Clowngrenade : UplinkItem_Jobspecific {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "1 Banana Grenade";
			this.desc = "A grenade that explodes into HONK! brand banana peels that are genetically modified to be extra slippery and extrude caustic acid when stepped on";
			this.item = typeof(Obj_Item_Weapon_Grenade_ClownGrenade);
			this.cost = 4;
			this.job = new ByTable(new object [] { "Clown" });
		}

	}

}