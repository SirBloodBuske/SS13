// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Landmark_Costume_Thegriffin : Obj_Effect_Landmark_Costume {

		// Function from file: landmarks.dm
		public Obj_Effect_Landmark_Costume_Thegriffin ( dynamic loc = null ) : base( (object)(loc) ) {
			new Obj_Item_Clothing_Suit_Toggle_Owlwings_Griffinwings( this.loc );
			new Obj_Item_Clothing_Shoes_Griffin( this.loc );
			new Obj_Item_Clothing_Under_Griffin( this.loc );
			new Obj_Item_Clothing_Head_Griffin( this.loc );
			GlobalFuncs.qdel( this );
			return;
		}

	}

}