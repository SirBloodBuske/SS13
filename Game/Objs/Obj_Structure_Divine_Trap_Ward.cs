// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Divine_Trap_Ward : Obj_Structure_Divine_Trap {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.health = 150;
			this.maxhealth = 150;
			this.time_between_triggers = 1200;
			this.icon_state = "ward";
		}

		// Function from file: traps.dm
		public Obj_Structure_Divine_Trap_Ward ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Schedule( this.time_between_triggers, (Task13.Closure)(() => {
				
				if ( this != null ) {
					GlobalFuncs.qdel( this );
				}
				return;
			}));
			return;
		}

	}

}