// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Drink_Cold_Quantum : Reagent_Drink_Cold {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Nuka Cola Quantum";
			this.id = "quantum";
			this.description = "Take the leap... enjoy a Quantum!";
			this.color = "#100800";
			this.adj_sleepy = -2;
			this.sport = 5;
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}
			M.apply_effect( 2, "irradiate", 0 );
			return false;
		}

	}

}