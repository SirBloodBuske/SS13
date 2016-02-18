// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mutation_Human_BadDna : Mutation_Human {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Unstable DNA";
			this.quality = 2;
			this.text_gain_indication = "<span class='danger'>You feel strange.</span>";
		}

		// Function from file: mutations.dm
		public override dynamic on_acquiring( dynamic owner = null ) {
			dynamic _default = null;

			dynamic new_mob = null;

			owner.WriteMsg( this.text_gain_indication );

			if ( Rand13.PercentChance( 95 ) ) {
				
				if ( Rand13.PercentChance( 50 ) ) {
					new_mob = GlobalFuncs.randmutb( owner );
				} else {
					new_mob = GlobalFuncs.randmuti( owner );
				}
			} else {
				new_mob = GlobalFuncs.randmutg( owner );
			}

			if ( Lang13.Bool( new_mob ) && new_mob is Mob ) {
				owner = new_mob;
			}
			_default = owner;
			this.on_losing( owner );
			return _default;
		}

	}

}