// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Fancy_FoodBox_SliderBox_Slippery : Obj_Item_Weapon_Storage_Fancy_FoodBox_SliderBox {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_type = "slippery slider";
			this.slider_type = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Slider_Slippery);
			this.storage_slots = 2;
		}

		public Obj_Item_Weapon_Storage_Fancy_FoodBox_SliderBox_Slippery ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}