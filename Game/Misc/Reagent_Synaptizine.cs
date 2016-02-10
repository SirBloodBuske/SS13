// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Synaptizine : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Synaptizine";
			this.id = "synaptizine";
			this.description = "Synaptizine is used to treat various diseases.";
			this.reagent_state = 2;
			this.color = "#C8A5DC";
			this.custom_metabolism = 0.01;
			this.overdose = 30;
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}
			M.drowsyness = Num13.MaxInt( Convert.ToInt32( M.drowsyness - 5 ), 0 );
			M.AdjustParalysis( -1 );
			M.AdjustStunned( -1 );
			M.AdjustWeakened( -1 );

			if ( Lang13.Bool( ((dynamic)this.holder).has_reagent( "mindbreaker" ) ) ) {
				((dynamic)this.holder).remove_reagent( "mindbreaker", 5 );
			}
			M.hallucination = Num13.MaxInt( 0, M.hallucination - 10 );

			if ( Rand13.PercentChance( 60 ) ) {
				M.adjustToxLoss( 1 );
			}
			return false;
		}

	}

}