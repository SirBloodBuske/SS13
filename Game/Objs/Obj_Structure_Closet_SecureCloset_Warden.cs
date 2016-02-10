// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_SecureCloset_Warden : Obj_Structure_Closet_SecureCloset {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_access = new ByTable(new object [] { 3 });
			this.icon_closed = "wardensecure";
			this.icon_locked = "wardensecure1";
			this.icon_opened = "wardensecureopen";
			this.icon_broken = "wardensecurebroken";
			this.icon_off = "wardensecureoff";
			this.icon_state = "wardensecure1";
		}

		// Function from file: security.dm
		public Obj_Structure_Closet_SecureCloset_Warden ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Sleep( 2 );

			if ( Rand13.PercentChance( 50 ) ) {
				new Obj_Item_Weapon_Storage_Backpack_Security( this );
			} else {
				new Obj_Item_Weapon_Storage_Backpack_SatchelSec( this );
			}
			new Obj_Item_Clothing_Suit_Armor_Vest_Security( this );
			new Obj_Item_Clothing_Under_Rank_Warden( this );
			new Obj_Item_Clothing_Suit_Armor_Vest_Warden( this );
			new Obj_Item_Clothing_Head_Helmet_Warden( this );
			new Obj_Item_Device_Radio_Headset_HeadsetSec(  );
			new Obj_Item_Clothing_Glasses_Sunglasses_Sechud( this );
			new Obj_Item_Weapon_Storage_Box_Flashbangs( this );
			new Obj_Item_Weapon_Storage_Belt_Security( this );
			new Obj_Item_Weapon_ReagentContainers_Spray_Pepper( this );
			new Obj_Item_Weapon_Melee_Baton_Loaded( this );
			new Obj_Item_Weapon_Gun_Energy_Taser( this );
			new Obj_Item_Weapon_Storage_Box_Bolas( this );
			new Obj_Item_Weapon_Batteringram( this );
			new Obj_Item_Device_Gps_Secure( this );
			return;
		}

	}

}