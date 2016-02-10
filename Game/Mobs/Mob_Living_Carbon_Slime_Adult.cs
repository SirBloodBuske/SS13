// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_Carbon_Slime_Adult : Mob_Living_Carbon_Slime {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.speak_emote = new ByTable(new object [] { "telepathically chirps" });
			this.maxHealth = 200;
			this.health = 200;
			this.nutrition = 800;
			this.icon_state = "grey adult slime";
		}

		// Function from file: slime.dm
		public Mob_Living_Carbon_Slime_Adult ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.name = "" + this.colour + " slime (" + Rand13.Int( 1, 1000 ) + ")";
			this.desc = "An adult " + this.colour + " slime.";
			this.slime_mutation[1] = typeof(Mob_Living_Carbon_Slime_Orange);
			this.slime_mutation[2] = typeof(Mob_Living_Carbon_Slime_Metal);
			this.slime_mutation[3] = typeof(Mob_Living_Carbon_Slime_Blue);
			this.slime_mutation[4] = typeof(Mob_Living_Carbon_Slime_Purple);
			return;
		}

	}

}