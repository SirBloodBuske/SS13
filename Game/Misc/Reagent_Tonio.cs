// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Tonio : Reagent {

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			Mob_Living H = null;
			Reagent reagent = null;

			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}

			if ( M is Mob_Living_Carbon_Human && Rand13.PercentChance( 5 ) ) {
				H = M;
				((dynamic)H).vomit();
			}

			foreach (dynamic _a in Lang13.Enumerate( ((dynamic)this.holder).reagent_list, typeof(Reagent) )) {
				reagent = _a;
				
				Interface13.Stat( null, GlobalVars.tonio_doesnt_remove.Contains( reagent.id ) );

				if ( reagent is Reagent ) {
					continue;
				}
				((dynamic)this.holder).remove_reagent( reagent.id, 1.5 );
			}
			M.adjustToxLoss( -1 );
			M.nutrition += this.nutriment_factor;

			if ( M.getBruteLoss() != 0 && Rand13.PercentChance( 20 ) ) {
				M.heal_organ_damage( 1, 0 );
			}
			return false;
		}

	}

}