// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Acetone : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "acetone";
			this.id = "acetone";
			this.result = "acetone";
			this.required_reagents = new ByTable().Set( "oil", 1 ).Set( "welding_fuel", 1 ).Set( "oxygen", 1 );
			this.result_amount = 3;
		}

	}

}