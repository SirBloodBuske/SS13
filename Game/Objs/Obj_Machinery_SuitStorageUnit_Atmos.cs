// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_SuitStorageUnit_Atmos : Obj_Machinery_SuitStorageUnit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.suit_type = typeof(Obj_Item_Clothing_Suit_Space_Hardsuit_Engine_Atmos);
			this.mask_type = typeof(Obj_Item_Clothing_Mask_Gas);
			this.storage_type = typeof(Obj_Item_Weapon_Watertank_Atmos);
		}

		public Obj_Machinery_SuitStorageUnit_Atmos ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}