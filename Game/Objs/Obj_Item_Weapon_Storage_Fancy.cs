// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Fancy : Obj_Item_Weapon_Storage {

		public string icon_type = "donut";
		public string plural_type = "s";
		public bool empty = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.foldable = typeof(Obj_Item_Stack_Sheet_Cardboard);
			this.allow_quick_gather = true;
			this.use_to_pickup = true;
			this.allow_quick_empty = true;
			this.icon = "icons/obj/food.dmi";
			this.icon_state = "donutbox6";
		}

		public Obj_Item_Weapon_Storage_Fancy ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: fancy.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );

			if ( this.contents.len <= 0 ) {
				GlobalFuncs.to_chat( user, "<span class='info'>There are no " + this.icon_type + this.plural_type + " left in the box.</span>" );
			} else if ( this.contents.len == 1 ) {
				GlobalFuncs.to_chat( user, "<span class='info'>There is one " + this.icon_type + " left in the box.</span>" );
			} else {
				GlobalFuncs.to_chat( user, "<span class='info'>There are " + this.contents.len + " " + this.icon_type + this.plural_type + " in the box.</span>" );
			}
			return null;
		}

		// Function from file: fancy.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			location = location ?? 0;

			double total_contents = 0;

			total_contents = this.contents.len - Convert.ToDouble( location );
			this.icon_state = "" + this.icon_type + "box" + total_contents;
			return null;
		}

	}

}