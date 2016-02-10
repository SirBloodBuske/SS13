// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPacks_Ballistic : SupplyPacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Ballistic gear crate";
			this.contains = new ByTable(new object [] { 
				typeof(Obj_Item_Clothing_Suit_Armor_Bulletproof), 
				typeof(Obj_Item_Clothing_Suit_Armor_Bulletproof), 
				typeof(Obj_Item_Weapon_Gun_Projectile_Shotgun_Pump_Combat), 
				typeof(Obj_Item_Weapon_Gun_Projectile_Shotgun_Pump_Combat)
			 });
			this.cost = 50;
			this.containertype = typeof(Obj_Structure_Closet_Crate_Secure);
			this.containername = "Ballistic gear crate";
			this.access = 3;
			this.group = "Security";
		}

	}

}