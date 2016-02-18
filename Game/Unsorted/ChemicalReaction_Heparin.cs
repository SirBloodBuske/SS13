// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Heparin : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Heparin";
			this.id = "Heparin";
			this.result = "heparin";
			this.required_reagents = new ByTable().Set( "formaldehyde", 1 ).Set( "sodium", 1 ).Set( "chlorine", 1 ).Set( "lithium", 1 );
			this.result_amount = 4;
			this.mix_message = "<span class='danger'>The mixture thins and loses all color.</span>";
		}

	}

}