// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_SecureCloset_Miner : Obj_Structure_Closet_SecureCloset {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_access = new ByTable(new object [] { 48 });
			this.icon_state = "mining";
		}

		// Function from file: mine_items.dm
		public Obj_Structure_Closet_SecureCloset_Miner ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Device_Radio_Headset_HeadsetCargo( this );
			new Obj_Item_Device_MiningScanner( this );
			new Obj_Item_Weapon_Storage_Bag_Ore( this );
			new Obj_Item_Weapon_Shovel( this );
			new Obj_Item_Weapon_Pickaxe( this );
			new Obj_Item_Clothing_Glasses_Meson( this );
			return;
		}

	}

}