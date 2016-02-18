// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RoundEvent_Wizard_Ghost : RoundEvent_Wizard {

		// Function from file: ghost.dm
		public override bool start(  ) {
			Mob_Dead_Observer G = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_Dead_Observer) )) {
				G = _a;
				
				G.invisibility = 0;
				G.WriteMsg( "You suddenly feel extremely obvious..." );
			}
			return false;
		}

	}

}