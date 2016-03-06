// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_SecureCloset_Hop : Obj_Structure_Closet_SecureCloset {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_access = new ByTable(new object [] { 57 });
			this.icon_state = "hop";
		}

		// Function from file: security.dm
		public Obj_Structure_Closet_SecureCloset_Hop ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Clothing_Under_Rank_HeadOfPersonnel( this );
			new Obj_Item_Clothing_Head_Hopcap( this );
			new Obj_Item_Weapon_Cartridge_Hop( this );
			new Obj_Item_Device_Radio_Headset_Heads_Hop( this );
			new Obj_Item_Clothing_Shoes_Sneakers_Brown( this );
			new Obj_Item_Weapon_Storage_Box_Ids( this );
			new Obj_Item_Weapon_Storage_Box_Ids( this );
			new Obj_Item_Device_Megaphone_Command( this );
			new Obj_Item_Clothing_Suit_Armor_Vest( this );
			new Obj_Item_Device_Assembly_Flash_Handheld( this );
			new Obj_Item_Clothing_Glasses_Sunglasses( this );
			new Obj_Item_Weapon_MiningVoucher( this );
			new Obj_Item_Weapon_Restraints_Handcuffs_Cable_Zipties( this );
			new Obj_Item_Weapon_Gun_Energy_Gun( this );
			new Obj_Item_Clothing_Tie_Petcollar( this );
			return;
		}

	}

}