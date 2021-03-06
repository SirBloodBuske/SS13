// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Toxin_Lipolicide : Reagent_Toxin {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Lipolicide";
			this.id = "lipolicide";
			this.description = "A powerful toxin that will destroy fat cells, massively reducing body weight in a short time. More deadly to those without nutriment in their body.";
			this.metabolization_rate = 0.2;
			this.toxpwr = 0.5;
		}

		// Function from file: toxin_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			
			if ( !Lang13.Bool( ((Reagents)this.holder).has_reagent( "nutriment" ) ) ) {
				((Mob_Living)M).adjustToxLoss( 0.5 );
			}
			M.nutrition -= 2;
			M.overeatduration = 0;

			if ( M.nutrition < 0 ) {
				M.nutrition = 0;
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}