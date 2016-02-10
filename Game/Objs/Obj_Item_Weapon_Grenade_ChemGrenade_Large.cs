// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Grenade_ChemGrenade_Large : Obj_Item_Weapon_Grenade_ChemGrenade {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.allowed_containers = new ByTable(new object [] { typeof(Obj_Item_Weapon_ReagentContainers_Glass), typeof(Obj_Item_SlimeExtract) });
			this.origin_tech = "combat=3;materials=3";
			this.affected_area = 4;
			this.icon_state = "large_grenade";
		}

		public Obj_Item_Weapon_Grenade_ChemGrenade_Large ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}