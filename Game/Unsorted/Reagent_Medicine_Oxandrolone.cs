// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Medicine_Oxandrolone : Reagent_Medicine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Oxandrolone";
			this.id = "oxandrolone";
			this.description = "Stimulates the healing of severe burns. Extremely rapidly heals severe burns and slowly heals minor ones. Overdose will worsen existing burns.";
			this.color = "#f7ffa5";
			this.metabolization_rate = 0.2;
			this.overdose_threshold = 25;
		}

		// Function from file: medicine_reagents.dm
		public override void overdose_process( dynamic M = null ) {
			
			if ( ((Mob_Living)M).getFireLoss() != 0 ) {
				((Mob_Living)M).adjustFireLoss( 4.5 );
			}
			base.overdose_process( (object)(M) );
			return;
		}

		// Function from file: medicine_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			
			if ( ((Mob_Living)M).getFireLoss() > 50 ) {
				((Mob_Living)M).adjustFireLoss( -4 );
			} else {
				((Mob_Living)M).adjustFireLoss( -0.5 );
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}