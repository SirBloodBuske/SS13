// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Defibrillator_Loaded : Obj_Item_Weapon_Defibrillator {

		// Function from file: defib.dm
		public Obj_Item_Weapon_Defibrillator_Loaded ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.paddles = this.make_paddles();
			this.bcell = new Obj_Item_Weapon_StockParts_Cell_High( this );
			this.update_icon();
			return;
		}

	}

}