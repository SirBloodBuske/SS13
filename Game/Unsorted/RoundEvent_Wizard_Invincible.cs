// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RoundEvent_Wizard_Invincible : RoundEvent_Wizard {

		// Function from file: invincible.dm
		public override bool start(  ) {
			Mob_Living_Carbon_Human H = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.living_mob_list, typeof(Mob_Living_Carbon_Human) )) {
				H = _a;
				
				H.reagents.add_reagent( "adminordrazine", 40 );
				H.WriteMsg( "<span class='notice'>You feel invincible, nothing can hurt you!</span>" );
			}
			return false;
		}

	}

}