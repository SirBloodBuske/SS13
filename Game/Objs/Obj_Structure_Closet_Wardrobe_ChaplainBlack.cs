// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Wardrobe_ChaplainBlack : Obj_Structure_Closet_Wardrobe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_closed = "black";
			this.icon_state = "black";
		}

		// Function from file: wardrobe.dm
		public Obj_Structure_Closet_Wardrobe_ChaplainBlack ( dynamic loc = null ) : base( (object)(loc) ) {
			new Obj_Item_Clothing_Under_Rank_Chaplain( this );
			new Obj_Item_Clothing_Shoes_Black( this );
			new Obj_Item_Clothing_Suit_Nun( this );
			new Obj_Item_Clothing_Head_NunHood( this );
			new Obj_Item_Clothing_Suit_ChaplainHoodie( this );
			new Obj_Item_Clothing_Head_ChaplainHood( this );
			new Obj_Item_Clothing_Suit_Holidaypriest( this );
			new Obj_Item_Clothing_Under_Wedding_BrideWhite( this );
			new Obj_Item_Weapon_Storage_Backpack_Cultpack( this );
			new Obj_Item_Weapon_Storage_Fancy_CandleBox( this );
			new Obj_Item_Weapon_Storage_Fancy_CandleBox( this );
			this.AddToProfiler();
			return;
		}

	}

}