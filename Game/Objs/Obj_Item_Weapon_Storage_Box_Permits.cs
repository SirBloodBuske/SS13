// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Box_Permits : Obj_Item_Weapon_Storage_Box {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "id";
		}

		// Function from file: boxes.dm
		public Obj_Item_Weapon_Storage_Box_Permits ( dynamic loc = null ) : base( (object)(loc) ) {
			double i = 0;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			foreach (dynamic _a in Lang13.IterateRange( 1, 3 )) {
				i = _a;
				
				new Obj_Item_Areaeditor_Permit( this );
			}
			return;
		}

	}

}