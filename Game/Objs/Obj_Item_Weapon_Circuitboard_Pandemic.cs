// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_Pandemic : Obj_Item_Weapon_Circuitboard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = typeof(Obj_Machinery_Computer_Pandemic);
			this.origin_tech = "programming=2;biotech=2";
		}

		public Obj_Item_Weapon_Circuitboard_Pandemic ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}