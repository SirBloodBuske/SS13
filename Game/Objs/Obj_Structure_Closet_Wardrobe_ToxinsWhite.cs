// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Wardrobe_ToxinsWhite : Obj_Structure_Closet_Wardrobe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_closed = "white";
			this.icon_state = "white";
		}

		// Function from file: wardrobe.dm
		public Obj_Structure_Closet_Wardrobe_ToxinsWhite ( dynamic loc = null ) : base( (object)(loc) ) {
			new Obj_Item_Clothing_Under_Rank_Scientist( this );
			new Obj_Item_Clothing_Under_Rank_Scientist( this );
			new Obj_Item_Clothing_Under_Rank_Xenoarch( this );
			new Obj_Item_Clothing_Under_Rank_Plasmares( this );
			new Obj_Item_Clothing_Under_Rank_Xenobio( this );
			new Obj_Item_Clothing_Under_Rank_Anomalist( this );
			new Obj_Item_Clothing_Suit_Storage_Labcoat( this );
			new Obj_Item_Clothing_Suit_Storage_Labcoat( this );
			new Obj_Item_Clothing_Suit_Storage_Labcoat( this );
			new Obj_Item_Clothing_Shoes_White( this );
			new Obj_Item_Clothing_Shoes_White( this );
			new Obj_Item_Clothing_Shoes_White( this );
			new Obj_Item_Clothing_Shoes_Slippers();
			new Obj_Item_Clothing_Shoes_Slippers();
			new Obj_Item_Clothing_Shoes_Slippers();
			this.AddToProfiler();
			return;
		}

	}

}