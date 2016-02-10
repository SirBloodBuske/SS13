// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Ethylredoxrazine : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Ethylredoxrazine";
			this.id = "ethylredoxrazine";
			this.result = "ethylredoxrazine";
			this.required_reagents = new ByTable().Set( "oxygen", 1 ).Set( "anti_toxin", 1 ).Set( "carbon", 1 );
			this.result_amount = 3;
		}

	}

}