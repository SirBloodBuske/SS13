// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Box_Bodybags : Obj_Item_Weapon_Storage_Box {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "bodybags";
		}

		// Function from file: bodybag.dm
		public Obj_Item_Weapon_Storage_Box_Bodybags ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Bodybag( this );
			new Obj_Item_Bodybag( this );
			new Obj_Item_Bodybag( this );
			new Obj_Item_Bodybag( this );
			new Obj_Item_Bodybag( this );
			new Obj_Item_Bodybag( this );
			new Obj_Item_Bodybag( this );
			return;
		}

	}

}