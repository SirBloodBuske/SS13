// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Table_Wood : Obj_Structure_Table {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.frame = typeof(Obj_Structure_TableFrame_Wood);
			this.framestack = typeof(Obj_Item_Stack_Sheet_Mineral_Wood);
			this.buildstack = typeof(Obj_Item_Stack_Sheet_Mineral_Wood);
			this.burn_state = 0;
			this.burntime = 20;
			this.canSmoothWith = new ByTable(new object [] { typeof(Obj_Structure_Table_Wood), typeof(Obj_Structure_Table_Wood_Poker) });
			this.icon = "icons/obj/smooth_structures/wood_table.dmi";
			this.icon_state = "wood_table";
		}

		public Obj_Structure_Table_Wood ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}