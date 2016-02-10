// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Language_Diona : Language {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Rootspeak";
			this.desc = "A creaking, subvocal language spoken instinctively by the Dionaea. Due to the unique makeup of the average Diona, a phrase of Rootspeak can be a combination of anywhere from one to twelve individual voices and notes.";
			this.speech_verb = "creaks and rustles";
			this.ask_verb = "creaks";
			this.exclaim_verb = "rustles";
			this.colour = "soghun";
			this.key = "q";
			this.flags = 2;
			this.syllables = new ByTable(new object [] { "hs", "zt", "kr", "st", "sh" });
		}

	}

}