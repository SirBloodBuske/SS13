// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Window_Full_Reinforced : Obj_Structure_Window_Full {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.base_state = "rwindow";
			this.sheettype = typeof(Obj_Item_Stack_Sheet_Glass_Rglass);
			this.health = 40;
			this.d_state = 3;
			this.reinforced = true;
			this.icon_state = "rwindow0";
		}

		public Obj_Structure_Window_Full_Reinforced ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}