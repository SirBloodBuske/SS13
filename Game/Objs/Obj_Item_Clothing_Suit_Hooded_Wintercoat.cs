// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Hooded_Wintercoat : Obj_Item_Clothing_Suit_Hooded {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "labcoat";
			this.body_parts_covered = 390;
			this.cold_protection = 390;
			this.min_cold_protection_temperature = 60;
			this.armor = new ByTable().Set( "melee", 0 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 0 ).Set( "bio", 10 ).Set( "rad", 0 );
			this.v_allowed = new ByTable(new object [] { 
				typeof(Obj_Item_Device_Flashlight), 
				typeof(Obj_Item_Weapon_Tank_Internals_EmergencyOxygen), 
				typeof(Obj_Item_Toy), 
				typeof(Obj_Item_Weapon_Storage_Fancy_Cigarettes), 
				typeof(Obj_Item_Weapon_Lighter)
			 });
			this.hooded = true;
			this.action_button_name = "Toggle Winter Hood";
			this.icon_state = "coatwinter";
		}

		public Obj_Item_Clothing_Suit_Hooded_Wintercoat ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}