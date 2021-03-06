// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Medicine_Synaptizine : Reagent_Medicine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Synaptizine";
			this.id = "synaptizine";
			this.description = "Increases resistance to stuns as well as reducing drowsiness and hallucinations.";
			this.color = "#C8A5DC";
		}

		// Function from file: medicine_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			M.drowsyness = Num13.MaxInt( M.drowsyness - 5, 0 );
			((Mob)M).AdjustParalysis( -1 );
			((Mob)M).AdjustStunned( -1 );
			((Mob)M).AdjustWeakened( -1 );

			if ( Lang13.Bool( ((dynamic)this.holder).has_reagent( "mindbreaker" ) ) ) {
				((dynamic)this.holder).remove_reagent( "mindbreaker", 5 );
			}
			M.hallucination = Num13.MaxInt( 0, ((int)( M.hallucination - 10 )) );

			if ( Rand13.PercentChance( 30 ) ) {
				((Mob_Living)M).adjustToxLoss( 1 );
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}