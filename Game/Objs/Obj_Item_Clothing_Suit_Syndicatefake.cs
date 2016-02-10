// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Syndicatefake : Obj_Item_Clothing_Suit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "space_suit_syndicate";
			this.v_allowed = new ByTable(new object [] { typeof(Obj_Item_Device_Flashlight), typeof(Obj_Item_Weapon_Tank_EmergencyOxygen), typeof(Obj_Item_Weapon_Tank_EmergencyNitrogen), typeof(Obj_Item_Toy) });
			this.body_parts_covered = 2046;
			this.icon_state = "syndicate";
		}

		public Obj_Item_Clothing_Suit_Syndicatefake ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}