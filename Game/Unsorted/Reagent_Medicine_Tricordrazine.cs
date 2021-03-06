// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Medicine_Tricordrazine : Reagent_Medicine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Tricordrazine";
			this.id = "tricordrazine";
			this.description = "Has a high chance to heal all types of damage. Overdose instead causes it.";
			this.color = "#C8A5DC";
			this.overdose_threshold = 30;
		}

		// Function from file: medicine_reagents.dm
		public override void overdose_process( dynamic M = null ) {
			((Mob_Living)M).adjustToxLoss( 2 );
			((Mob_Living)M).adjustOxyLoss( 2 );
			((Mob_Living)M).adjustBruteLoss( 2 );
			((Mob_Living)M).adjustFireLoss( 2 );
			base.overdose_process( (object)(M) );
			return;
		}

		// Function from file: medicine_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			
			if ( Rand13.PercentChance( 80 ) ) {
				((Mob_Living)M).adjustBruteLoss( -1 );
				((Mob_Living)M).adjustFireLoss( -1 );
				((Mob_Living)M).adjustOxyLoss( -1 );
				((Mob_Living)M).adjustToxLoss( -1 );
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}