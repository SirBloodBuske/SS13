// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Acidtea : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Earl's Grey Tea";
			this.id = "acidtea";
			this.result = "acidtea";
			this.required_reagents = new ByTable().Set( "sacid", 1 ).Set( "tea", 1 );
			this.result_amount = 2;
		}

	}

}