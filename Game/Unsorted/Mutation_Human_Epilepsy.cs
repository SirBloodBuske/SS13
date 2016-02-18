// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mutation_Human_Epilepsy : Mutation_Human {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Epilepsy";
			this.quality = 2;
			this.text_gain_indication = "<span class='danger'>You get a headache.</span>";
		}

		// Function from file: mutations.dm
		public override void on_life( Mob_Living owner = null ) {
			
			if ( Rand13.PercentChance( 1 ) && !( owner.paralysis != 0 ) ) {
				owner.visible_message( "<span class='danger'>" + owner + " starts having a seizure!</span>", "<span class='userdanger'>You have a seizure!</span>" );
				owner.Paralyse( 10 );
				owner.Jitter( 1000 );
				Task13.Schedule( 90, (Task13.Closure)(() => {
					owner.jitteriness = 10;
					return;
				}));
			}
			return;
		}

	}

}