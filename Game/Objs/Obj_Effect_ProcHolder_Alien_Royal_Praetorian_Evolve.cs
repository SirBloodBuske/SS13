// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Alien_Royal_Praetorian_Evolve : Obj_Effect_ProcHolder_Alien_Royal_Praetorian {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.plasma_cost = 500;
			this.action_icon_state = "alien_evolve_praetorian";
		}

		public Obj_Effect_ProcHolder_Alien_Royal_Praetorian_Evolve ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: praetorian.dm
		public override bool fire( Mob user = null ) {
			Mob_Living_Carbon_Alien_Humanoid_Royal_Queen new_xeno = null;

			
			if ( !GlobalFuncs.alien_type_present( typeof(Mob_Living_Carbon_Alien_Humanoid_Royal_Queen) ) ) {
				new_xeno = new Mob_Living_Carbon_Alien_Humanoid_Royal_Queen( user.loc );
				((Mob_Living_Carbon_Alien)user).alien_evolve( new_xeno );
				return true;
			} else {
				user.WriteMsg( "<span class='notice'>We already have an alive queen.</span>" );
				return false;
			}
		}

	}

}