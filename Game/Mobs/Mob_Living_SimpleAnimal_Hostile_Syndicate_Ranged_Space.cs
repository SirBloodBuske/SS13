// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Syndicate_Ranged_Space : Mob_Living_SimpleAnimal_Hostile_Syndicate_Ranged {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "syndicaterangedspace";
			this.atmos_requirements = new ByTable().Set( "min_oxy", 0 ).Set( "max_oxy", 0 ).Set( "min_tox", 0 ).Set( "max_tox", 0 ).Set( "min_co2", 0 ).Set( "max_co2", 0 ).Set( "min_n2", 0 ).Set( "max_n2", 0 );
			this.minbodytemp = 0;
			this.loot = new ByTable(new object [] { typeof(Obj_Effect_Landmark_Mobcorpse_Syndicatecommando), typeof(Obj_Item_Weapon_Gun_Projectile_Automatic_C20r_Unrestricted), typeof(Obj_Item_Weapon_Shield_Energy) });
			this.icon_state = "syndicaterangedspace";
		}

		public Mob_Living_SimpleAnimal_Hostile_Syndicate_Ranged_Space ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: syndicate.dm
		public override int Process_Spacemove( dynamic movement_dir = null ) {
			movement_dir = movement_dir ?? 0;

			return 1;
		}

	}

}