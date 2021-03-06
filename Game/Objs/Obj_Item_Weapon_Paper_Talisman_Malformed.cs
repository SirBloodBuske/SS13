// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Paper_Talisman_Malformed : Obj_Item_Weapon_Paper_Talisman {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.cultist_name = "malformed talisman";
			this.cultist_desc = "A talisman with gibberish scrawlings. No good can come from invoking this.";
			this.invocation = "Ra'sha yoka!";
		}

		public Obj_Item_Weapon_Paper_Talisman_Malformed ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: talisman.dm
		public override bool invoke( dynamic user = null ) {
			dynamic C = null;

			user.WriteMsg( "<span class='cultitalic'>You feel a pain in your head. The Geometer is displeased.</span>" );

			if ( user is Mob_Living_Carbon ) {
				C = user;
				((Mob_Living)C).apply_damage( 10, "brute", "head" );
			}
			return false;
		}

	}

}