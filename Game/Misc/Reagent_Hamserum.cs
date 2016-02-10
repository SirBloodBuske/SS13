// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Hamserum : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Ham Serum";
			this.id = "hamserum";
			this.description = "Concentrated legal discussions";
			this.reagent_state = 2;
			this.color = "#00FF21";
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool reaction_mob( dynamic M = null, int? method = null, double volume = 0 ) {
			method = method ?? GlobalVars.TOUCH;

			
			if ( base.reaction_mob( (object)(M), method, volume ) ) {
				return true;
			}
			GlobalFuncs.empulse( GlobalFuncs.get_turf( M ), 1, 2, false );
			return false;
		}

	}

}