// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_TripleCitrus : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "triple_citrus";
			this.id = "triple_citrus";
			this.result = "triple_citrus";
			this.required_reagents = new ByTable().Set( "lemonjuice", 1 ).Set( "limejuice", 1 ).Set( "orangejuice", 1 );
			this.result_amount = 5;
		}

	}

}