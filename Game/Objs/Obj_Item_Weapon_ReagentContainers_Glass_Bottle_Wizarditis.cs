// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Wizarditis : Obj_Item_Weapon_ReagentContainers_Glass_Bottle {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.spawned_disease = typeof(Disease_Wizarditis);
			this.icon_state = "bottle3";
		}

		public Obj_Item_Weapon_ReagentContainers_Glass_Bottle_Wizarditis ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}