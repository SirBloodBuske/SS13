// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Energy_Rad : Obj_Item_Projectile_Energy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage = 30;
			this.damage_type = "tox";
			this.weaken = 10;
			this.stutter = 10;
			this.icon_state = "rad";
		}

		public Obj_Item_Projectile_Energy_Rad ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: energy.dm
		public override bool on_hit( dynamic atarget = null, int? blocked = null ) {
			dynamic H = null;

			
			if ( atarget is Mob_Living_Carbon_Human ) {
				H = atarget;
				((Mob)H).generate_name();
				GlobalFuncs.scramble( true, H, 100 );
				GlobalFuncs.scramble( null, H, 5 );
				((Mob_Living)H).apply_effect( Rand13.Int( 50, 250 ), "irradiate" );
			}
			return false;
		}

	}

}