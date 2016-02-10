// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Map_Spawner_Medical_Pills : Obj_Map_Spawner_Medical {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.amount = 10;
			this.chance = 75;
			this.jiggle = 6;
			this.toSpawn = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_ReagentContainers_Pill_Antitox), 
				typeof(Obj_Item_Weapon_ReagentContainers_Pill_Tox), 
				typeof(Obj_Item_Weapon_ReagentContainers_Pill_Stox), 
				typeof(Obj_Item_Weapon_ReagentContainers_Pill_Kelotane), 
				typeof(Obj_Item_Weapon_ReagentContainers_Pill_Tramadol), 
				typeof(Obj_Item_Weapon_ReagentContainers_Pill_Methylphenidate), 
				typeof(Obj_Item_Weapon_ReagentContainers_Pill_Citalopram), 
				typeof(Obj_Item_Weapon_ReagentContainers_Pill_Inaprovaline), 
				typeof(Obj_Item_Weapon_ReagentContainers_Pill_Dexalin), 
				typeof(Obj_Item_Weapon_ReagentContainers_Pill_Bicaridine), 
				typeof(Obj_Item_Weapon_ReagentContainers_Pill_Happy), 
				typeof(Obj_Item_Weapon_ReagentContainers_Pill_Zoom)
			 });
			this.icon_state = "med_pills";
		}

		public Obj_Map_Spawner_Medical_Pills ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}