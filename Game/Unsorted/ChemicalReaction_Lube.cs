// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Lube : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Space Lube";
			this.id = "lube";
			this.result = "lube";
			this.required_reagents = new ByTable().Set( "water", 1 ).Set( "silicon", 1 ).Set( "oxygen", 1 );
			this.result_amount = 4;
		}

	}

}