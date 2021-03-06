// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_HairDye : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "hair_dye";
			this.id = "hair_dye";
			this.result = "hair_dye";
			this.required_reagents = new ByTable().Set( "colorful_reagent", 1 ).Set( "radium", 1 ).Set( "space_drugs", 1 );
			this.result_amount = 5;
		}

	}

}