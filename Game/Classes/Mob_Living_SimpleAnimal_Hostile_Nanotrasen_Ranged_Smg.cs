// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Hostile_Nanotrasen_Ranged_Smg : Mob_Living_SimpleAnimal_Hostile_Nanotrasen_Ranged {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_living = "nanotrasenrangedsmg";
			this.rapid = true;
			this.casingtype = typeof(Obj_Item_AmmoCasing_C46x30mm);
			this.projectilesound = "sound/weapons/gunshot_smg.ogg";
			this.loot = new ByTable(new object [] { typeof(Obj_Item_Weapon_Gun_Projectile_Automatic_Wt550), typeof(Obj_Effect_Landmark_Mobcorpse_Nanotrasensoldier) });
			this.icon_state = "nanotrasenrangedsmg";
		}

		public Mob_Living_SimpleAnimal_Hostile_Nanotrasen_Ranged_Smg ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}