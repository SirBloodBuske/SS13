// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Spell_AoeTurf_Repulse_Xeno : Obj_Effect_ProcHolder_Spell_AoeTurf_Repulse {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.sound = "sound/magic/Tail_swing.ogg";
			this.charge_max = 150;
			this.clothes_req = 0;
			this.range = 2;
			this.animation = "tailsweep";
			this.action_icon_state = "tailsweep";
			this.action_background_icon_state = "bg_alien";
		}

		public Obj_Effect_ProcHolder_Spell_AoeTurf_Repulse_Xeno ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: wizard.dm
		public override bool cast( dynamic targets = null, dynamic thearea = null, dynamic user = null ) {
			thearea = thearea ?? Task13.User;

			dynamic C = null;

			
			if ( thearea is Mob_Living_Carbon ) {
				C = thearea;
				GlobalFuncs.playsound( C.loc, "sound/voice/hiss5.ogg", 80, 1, 1 );
				C.spin( 6, 1 );
			}
			base.cast( (object)(targets), (object)(thearea), (object)(user) );
			return false;
		}

	}

}