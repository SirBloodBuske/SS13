// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Irishcarbomb : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Irish Car Bomb";
			this.id = "irishcarbomb";
			this.result = "irishcarbomb";
			this.required_reagents = new ByTable().Set( "ale", 1 ).Set( "irishcream", 1 );
			this.result_amount = 2;
		}

	}

}