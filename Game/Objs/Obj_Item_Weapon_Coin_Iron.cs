// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Coin_Iron : Obj_Item_Weapon_Coin {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.credits = 0.01;
			this.melt_temperature = 1783.1500244140625;
			this.icon_state = "coin_iron";
		}

		public Obj_Item_Weapon_Coin_Iron ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}