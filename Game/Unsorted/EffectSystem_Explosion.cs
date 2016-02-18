// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class EffectSystem_Explosion : EffectSystem {

		// Function from file: effects_explosion.dm
		public override void start(  ) {
			EffectSystem_ExplParticles P = null;
			EffectSystem_SmokeSpread S = null;

			new Obj_Effect_Explosion( this.location );
			P = new EffectSystem_ExplParticles();
			P.set_up( 10, 0, this.location );
			P.start();
			Task13.Schedule( 5, (Task13.Closure)(() => {
				S = new EffectSystem_SmokeSpread();
				S.set_up( 2, this.location );
				S.start();
				return;
			}));
			return;
		}

		// Function from file: effects_explosion.dm
		public override void set_up( dynamic amt = null, dynamic loca = null, dynamic flash = null, dynamic flash_fact = null, bool? message = null ) {
			
			if ( amt is Tile ) {
				this.location = amt;
			} else {
				this.location = GlobalFuncs.get_turf( amt );
			}
			return;
		}

	}

}