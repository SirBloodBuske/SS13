// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_VoxRaiders : Obj_Structure_Closet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_closed = "syndicate";
			this.icon_opened = "syndicateopen";
			this.icon_state = "syndicate";
		}

		// Function from file: syndicate.dm
		public Obj_Structure_Closet_VoxRaiders ( dynamic loc = null ) : base( (object)(loc) ) {
			Task13.Sleep( 2 );
			new Obj_Item_Clothing_Head_Helmet_Space_Vox_Pressure( this );
			new Obj_Item_Clothing_Mask_Breath_Vox( this );
			new Obj_Item_Clothing_Shoes_Magboots_Vox( this );
			new Obj_Item_Clothing_Suit_Space_Vox_Pressure( this );
			new Obj_Item_Clothing_Under_Vox_VoxCasual( this );
			new Obj_Item_Weapon_Tank_Jetpack_Nitrogen( this );
			return;
		}

	}

}