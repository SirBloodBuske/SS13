// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Wardrobe_GeneticsWhite : Obj_Structure_Closet_Wardrobe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_closed = "white";
			this.icon_state = "white";
		}

		// Function from file: wardrobe.dm
		public Obj_Structure_Closet_Wardrobe_GeneticsWhite ( dynamic loc = null ) : base( (object)(loc) ) {
			new Obj_Item_Clothing_Under_Rank_Geneticist( this );
			new Obj_Item_Clothing_Under_Rank_Geneticist( this );
			new Obj_Item_Clothing_Shoes_White( this );
			new Obj_Item_Clothing_Shoes_White( this );
			new Obj_Item_Clothing_Suit_Storage_Labcoat_Genetics( this );
			new Obj_Item_Clothing_Suit_Storage_Labcoat_Genetics( this );
			this.AddToProfiler();
			return;
		}

	}

}