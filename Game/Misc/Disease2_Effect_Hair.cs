// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease2_Effect_Hair : Disease2_Effect {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Hair Loss";
			this.stage = 2;
		}

		// Function from file: effect.dm
		public override bool activate( Mob_Living mob = null, bool multiplier = false ) {
			Mob_Living H = null;

			
			if ( mob is Mob_Living_Carbon_Human ) {
				H = mob;

				if ( ((dynamic)H).species.name == "Human" && !( ((dynamic)H).h_style == "Bald" ) && !( ((dynamic)H).h_style == "Balding Hair" ) ) {
					GlobalFuncs.to_chat( H, "<span class='danger'>Your hair starts to fall out in clumps...</span>" );
					Task13.Schedule( 50, (Task13.Closure)(() => {
						((dynamic)H).h_style = "Balding Hair";
						((Mob_Living_Carbon_Human)H).update_hair();
						return;
					}));
				}
			}
			return false;
		}

	}

}