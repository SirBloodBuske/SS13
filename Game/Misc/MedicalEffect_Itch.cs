// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class MedicalEffect_Itch : MedicalEffect {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Itch";
		}

		// Function from file: MedicalSideEffects.dm
		public override bool cure( Mob_Living_Carbon_Human H = null ) {
			
			if ( ((Reagents)H.reagents).has_reagent( "inaprovaline" ) ) {
				GlobalFuncs.to_chat( H, "<span class='warning'>The itching stops..</span>" );
				return true;
			}
			return false;
		}

		// Function from file: MedicalSideEffects.dm
		public override void on_life( Mob_Living_Carbon_Human H = null, double strength = 0 ) {
			
			dynamic _a = strength; // Was a switch-case, sorry for the mess.
			if ( 1<=_a&&_a<=10 ) {
				H.custom_pain( "You feel a slight itch.", false );
			} else if ( 11<=_a&&_a<=30 ) {
				H.custom_pain( "You want to scratch your itch badly.", false );
			} else if ( 31<=_a&&_a<=50 ) {
				H.emote( "me", 1, "shivers slightly." );
				H.custom_pain( "This itch makes it really hard to concentrate.", true );
				H.adjustToxLoss( 1 );
			} else if ( 51<=_a&&_a<=Double.PositiveInfinity ) {
				H.emote( "me", 1, "shivers." );
				H.custom_pain( "The itch starts hurting and oozing blood.", true );
				H.apply_damage( 1, "fire", null, null, null, null, "Itch" );
				H.drip( 1 );
			}
			return;
		}

	}

}