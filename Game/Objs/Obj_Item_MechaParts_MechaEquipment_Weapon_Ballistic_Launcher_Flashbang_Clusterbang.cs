// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic_Launcher_Flashbang_Clusterbang : Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic_Launcher_Flashbang {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.projectiles = 3;
			this.projectile = typeof(Obj_Item_Weapon_Grenade_Clusterbuster);
			this.projectile_energy_cost = 1600;
			this.equip_cooldown = 90;
		}

		public Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic_Launcher_Flashbang_Clusterbang ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}