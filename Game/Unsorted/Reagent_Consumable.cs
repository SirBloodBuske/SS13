// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Consumable : Reagent {

		public double nutriment_factor = 0.4;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Consumable";
			this.id = "consumable";
		}

		// Function from file: food_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			this.current_cycle++;
			M.nutrition += this.nutriment_factor;
			((Reagents)this.holder).remove_reagent( this.id, this.metabolization_rate );
			return false;
		}

	}

}