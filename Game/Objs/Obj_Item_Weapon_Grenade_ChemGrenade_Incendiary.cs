// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Grenade_ChemGrenade_Incendiary : Obj_Item_Weapon_Grenade_ChemGrenade {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.path = 1;
			this.stage = 2;
		}

		// Function from file: chem_grenade.dm
		public Obj_Item_Weapon_Grenade_ChemGrenade_Incendiary ( dynamic loc = null ) : base( (object)(loc) ) {
			Obj_Item_Weapon_ReagentContainers_Glass_Beaker B1 = null;
			Obj_Item_Weapon_ReagentContainers_Glass_Beaker B2 = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			B1 = new Obj_Item_Weapon_ReagentContainers_Glass_Beaker( this );
			B2 = new Obj_Item_Weapon_ReagentContainers_Glass_Beaker( this );
			((Reagents)B1.reagents).add_reagent( "aluminum", 15 );
			((Reagents)B2.reagents).add_reagent( "plasma", 15 );
			((Reagents)B2.reagents).add_reagent( "sacid", 15 );
			this.detonator = new Obj_Item_Device_AssemblyHolder_TimerIgniter( this );
			this.beakers.Add( B1 );
			this.beakers.Add( B2 );
			this.icon_state = Lang13.Initial( this, "icon_state" ) + "_locked";
			return;
		}

	}

}