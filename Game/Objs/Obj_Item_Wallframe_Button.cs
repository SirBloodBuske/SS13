// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Wallframe_Button : Obj_Item_Wallframe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.result_path = typeof(Obj_Machinery_Button);
			this.materials = new ByTable().Set( "$metal", 2000 );
			this.icon = "icons/obj/apc_repair.dmi";
			this.icon_state = "button_frame";
		}

		public Obj_Item_Wallframe_Button ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}