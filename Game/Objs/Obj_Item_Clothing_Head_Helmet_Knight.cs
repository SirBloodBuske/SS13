// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Knight : Obj_Item_Clothing_Head_Helmet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "knight_green";
			this.body_parts_covered = 47105;
			this.armor = new ByTable().Set( "melee", 20 ).Set( "bullet", 5 ).Set( "laser", 2 ).Set( "energy", 2 ).Set( "bomb", 2 ).Set( "bio", 2 ).Set( "rad", 0 );
			this.icon_state = "knight_green";
		}

		public Obj_Item_Clothing_Head_Helmet_Knight ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}