// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Backpack_SatchelFlat : Obj_Item_Weapon_Storage_Backpack {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.max_combined_w_class = 15;
			this.level = 1;
			this.cant_hold = new ByTable(new object [] { typeof(Obj_Item_Weapon_Storage_Backpack_SatchelFlat) });
			this.icon_state = "satchel-flat";
		}

		// Function from file: backpack.dm
		public Obj_Item_Weapon_Storage_Backpack_SatchelFlat ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Stack_Tile_Plasteel( this );
			new Obj_Item_Weapon_Crowbar( this );
			return;
		}

		// Function from file: backpack.dm
		public override void hide( bool h = false ) {
			
			if ( h ) {
				this.invisibility = 101;
				this.anchored = 1;
				this.icon_state = "" + Lang13.Initial( this, "icon_state" ) + "2";
			} else {
				this.invisibility = Convert.ToInt32( Lang13.Initial( this, "invisibility" ) );
				this.anchored = 0;
				this.icon_state = Lang13.Initial( this, "icon_state" );
			}
			return;
		}

	}

}