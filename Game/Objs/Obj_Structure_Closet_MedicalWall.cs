// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_MedicalWall : Obj_Structure_Closet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_closed = "medical_wall";
			this.icon_opened = "medical_wall_open";
			this.anchored = 1;
			this.wall_mounted = true;
			this.pick_up_stuff = false;
			this.icon_state = "medical_wall";
		}

		public Obj_Structure_Closet_MedicalWall ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: utility_closets.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( !this.opened ) {
				this.icon_state = this.icon_closed;
			} else {
				this.icon_state = this.icon_opened;
			}
			return null;
		}

	}

}