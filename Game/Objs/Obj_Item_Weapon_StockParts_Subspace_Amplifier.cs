// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_StockParts_Subspace_Amplifier : Obj_Item_Weapon_StockParts_Subspace {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "programming=2;magnets=2;materials=2;bluespace=1";
			this.materials = new ByTable().Set( "$metal", 30 ).Set( "$glass", 10 );
			this.icon_state = "subspace_amplifier";
		}

		public Obj_Item_Weapon_StockParts_Subspace_Amplifier ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}