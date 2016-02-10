// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Chloralhydrate : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Chloral Hydrate";
			this.id = "chloralhydrate";
			this.result = "chloralhydrate";
			this.required_reagents = new ByTable().Set( "ethanol", 1 ).Set( "chlorine", 3 ).Set( "water", 1 );
			this.result_amount = 1;
		}

	}

}