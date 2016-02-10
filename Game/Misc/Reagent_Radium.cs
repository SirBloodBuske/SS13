// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Radium : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.custom_plant_metabolism = 2;
			this.name = "Radium";
			this.id = "radium";
			this.description = "Radium is an alkaline earth metal. It is extremely radioactive.";
			this.color = "#C7C7C7";
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool reaction_turf( dynamic T = null, double volume = 0 ) {
			
			if ( base.reaction_turf( (object)(T), volume ) ) {
				return true;
			}

			if ( volume >= 3 ) {
				
				if ( !Lang13.Bool( Lang13.FindIn( typeof(Obj_Effect_Decal_Cleanable_Greenglow), T ) ) ) {
					new Obj_Effect_Decal_Cleanable_Greenglow( T );
				}
			}
			return false;
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			Mob_Living C = null;
			dynamic ID = null;
			Disease2_Disease V = null;

			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}
			M.apply_effect( 1, "irradiate", 0 );

			if ( M is Mob_Living_Carbon ) {
				C = M;

				if ( ((dynamic)C).virus2.len != 0 ) {
					
					foreach (dynamic _a in Lang13.Enumerate( ((dynamic)C).virus2 )) {
						ID = _a;
						
						V = ((dynamic)C).virus2[ID];

						if ( Rand13.PercentChance( 5 ) ) {
							
							if ( Rand13.PercentChance( 50 ) ) {
								C.radiation += 50;
								C.adjustToxLoss( 100 );
							}
							((dynamic)C).antibodies |= V.antigen;
						}
					}
				}
			}
			return false;
		}

		// Function from file: hydroponics_reagents.dm
		public override void on_plant_life( Obj_Machinery_PortableAtmospherics_Hydroponics T = null ) {
			base.on_plant_life( T );
			T.mutation_level += T.mutation_mod * ( this.custom_plant_metabolism ??0) * 0.6;
			T.toxins += 4;

			if ( T.seed != null && !T.dead ) {
				T.health -= 1.5;

				if ( Rand13.PercentChance( 20 ) ) {
					T.mutation_mod += 0.1;
				}
			}
			return;
		}

	}

}