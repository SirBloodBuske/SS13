// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Energy_KineticAccelerator_Hyper : Obj_Item_Weapon_Gun_Energy_KineticAccelerator {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.ammo_type = new ByTable(new object [] { typeof(Obj_Item_AmmoCasing_Energy_Kinetic_Hyper) });
			this.overheat_time = 14;
			this.origin_tech = "combat=4;powerstorage=3";
			this.icon_state = "kineticgun_h";
		}

		public Obj_Item_Weapon_Gun_Energy_KineticAccelerator_Hyper ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}