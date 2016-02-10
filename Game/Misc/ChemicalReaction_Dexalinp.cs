// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Dexalinp : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Dexalin Plus";
			this.id = "dexalinp";
			this.result = "dexalinp";
			this.required_reagents = new ByTable().Set( "dexalin", 1 ).Set( "carbon", 1 ).Set( "iron", 1 );
			this.result_amount = 3;
		}

	}

}