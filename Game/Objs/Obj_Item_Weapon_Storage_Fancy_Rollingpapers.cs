// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Fancy_Rollingpapers : Obj_Item_Weapon_Storage_Fancy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 1;
			this.storage_slots = 10;
			this.icon_type = "rolling paper";
			this.can_hold = new ByTable(new object [] { typeof(Obj_Item_Weapon_Rollingpaper) });
			this.spawn_type = typeof(Obj_Item_Weapon_Rollingpaper);
			this.icon = "icons/obj/cigarettes.dmi";
			this.icon_state = "cig_paper_pack";
		}

		public Obj_Item_Weapon_Storage_Fancy_Rollingpapers ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: fancy.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			this.overlays.Cut();

			if ( !( this.contents.len != 0 ) ) {
				this.overlays.Add( "" + this.icon_state + "_empty" );
			}
			return false;
		}

	}

}