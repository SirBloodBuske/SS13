// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Pcrate : Obj_Structure_Closet {

		public bool rigged = false;
		public string sound_effect_open = "sound/machines/click.ogg";
		public string sound_effect_close = "sound/machines/click.ogg";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_opened = "plasticcrateopen";
			this.icon_closed = "plasticcrate";
			this.starting_materials = new ByTable().Set( "$plastic", 37500 );
			this.icon = "icons/obj/storage.dmi";
			this.icon_state = "plasticcrate";
		}

		public Obj_Structure_Closet_Pcrate ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}