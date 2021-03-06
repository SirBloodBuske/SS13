// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Misc_Costume : SupplyPack_Misc {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Standard Costume Crate";
			this.cost = 10;
			this.access = 46;
			this.contains = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Storage_Backpack_Clown), 
				typeof(Obj_Item_Clothing_Shoes_ClownShoes), 
				typeof(Obj_Item_Clothing_Mask_Gas_ClownHat), 
				typeof(Obj_Item_Clothing_Under_Rank_Clown), 
				typeof(Obj_Item_Weapon_Bikehorn), 
				typeof(Obj_Item_Clothing_Under_Rank_Mime), 
				typeof(Obj_Item_Clothing_Shoes_Sneakers_Black), 
				typeof(Obj_Item_Clothing_Gloves_Color_White), 
				typeof(Obj_Item_Clothing_Mask_Gas_Mime), 
				typeof(Obj_Item_Clothing_Head_Beret), 
				typeof(Obj_Item_Clothing_Suit_Suspenders), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Bottleofnothing), 
				typeof(Obj_Item_Weapon_Storage_Backpack_Mime)
			 });
			this.crate_name = "standard costume crate";
			this.crate_type = typeof(Obj_Structure_Closet_Crate_Secure);
		}

	}

}