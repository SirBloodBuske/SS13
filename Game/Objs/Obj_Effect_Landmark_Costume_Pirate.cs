// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Landmark_Costume_Pirate : Obj_Effect_Landmark_Costume {

		// Function from file: landmarks.dm
		public Obj_Effect_Landmark_Costume_Pirate ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic CHOICE = null;

			new Obj_Item_Clothing_Under_Pirate( this.loc );
			new Obj_Item_Clothing_Suit_Pirate( this.loc );
			CHOICE = Rand13.Pick(new object [] { typeof(Obj_Item_Clothing_Head_Pirate), typeof(Obj_Item_Clothing_Head_Bandana) });
			Lang13.Call( CHOICE, this.loc );
			new Obj_Item_Clothing_Glasses_Eyepatch( this.loc );
			GlobalFuncs.qdel( this );
			return;
		}

	}

}