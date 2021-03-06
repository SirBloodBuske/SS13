// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Mecha_Medical : Obj_Mecha {

		// Function from file: medical.dm
		public Obj_Mecha_Medical ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_MechaParts_MechaTracking( this );
			return;
		}

		// Function from file: medical.dm
		public override dynamic mechsteprand(  ) {
			dynamic result = null;

			Map13.StepRandom( this );
			result = null;

			if ( Lang13.Bool( result ) ) {
				GlobalFuncs.playsound( this, "sound/mecha/mechstep.ogg", 25, 1 );
			}
			return result;
		}

		// Function from file: medical.dm
		public override dynamic mechstep( int? direction = null ) {
			dynamic result = null;

			Map13.Step( this, direction ??0 );
			result = null;

			if ( Lang13.Bool( result ) ) {
				GlobalFuncs.playsound( this, "sound/mecha/mechstep.ogg", 25, 1 );
			}
			return result;
		}

		// Function from file: medical.dm
		public override bool mechturn( int? direction = null ) {
			this.dir = direction ??0;
			GlobalFuncs.playsound( this, "sound/mecha/mechmove01.ogg", 40, 1 );
			return true;
		}

	}

}