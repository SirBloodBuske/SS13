// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Power_Changeling_Epinephrine : Power_Changeling {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Epinephrine sacs";
			this.desc = "We evolve additional sacs of adrenaline throughout our body.";
			this.helptext = "Gives the ability to instantly recover from stuns.  High chemical cost.";
			this.genomecost = 4;
			this.verbpath = typeof(Mob).GetMethod( "changeling_unstun" );
		}

	}

}