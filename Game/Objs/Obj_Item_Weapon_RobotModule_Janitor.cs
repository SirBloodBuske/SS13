// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_RobotModule_Janitor : Obj_Item_Weapon_RobotModule {

		public Obj_Item_Weapon_ReagentContainers_Spray drying_agent = null;

		// Function from file: robot_modules.dm
		public Obj_Item_Weapon_RobotModule_Janitor ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.modules.Add( new Obj_Item_Weapon_Soap_Nanotrasen( this ) );
			this.modules.Add( new Obj_Item_Weapon_Storage_Bag_Trash_Cyborg( this ) );
			this.modules.Add( new Obj_Item_Weapon_Mop_Cyborg( this ) );
			this.modules.Add( new Obj_Item_Device_Lightreplacer_Cyborg( this ) );
			this.modules.Add( new Obj_Item_Weapon_HolosignCreator( this ) );
			this.drying_agent = new Obj_Item_Weapon_ReagentContainers_Spray( this );
			this.drying_agent.reagents.add_reagent( "drying_agent", 250 );
			this.drying_agent.name = "drying agent spray";
			this.drying_agent.color = "#A000A0";
			this.modules.Add( this.drying_agent );
			this.emag = new Obj_Item_Weapon_ReagentContainers_Spray( this );
			this.emag.reagents.add_reagent( "lube", 250 );
			this.emag.name = "lube spray";
			this.fix_modules();
			return;
		}

		// Function from file: robot_modules.dm
		public override void respawn_consumable( dynamic R = null, double? coeff = null ) {
			coeff = coeff ?? 1;

			dynamic LR = null;
			double? i = null;

			base.respawn_consumable( (object)(R), coeff );
			LR = Lang13.FindIn( typeof(Obj_Item_Device_Lightreplacer), this.get_usable_modules() );

			if ( Lang13.Bool( LR ) ) {
				i = null;
				i = 1;

				while (( i ??0) <= ( coeff ??0)) {
					((Obj_Item_Device_Lightreplacer)LR).Charge( R );
					i++;
				}
			}
			this.drying_agent.reagents.add_reagent( "drying_agent", ( coeff ??0) * 5 );

			if ( Lang13.Bool( R.emagged ) && this.emag is Obj_Item_Weapon_ReagentContainers_Spray ) {
				this.emag.reagents.add_reagent( "lube", ( coeff ??0) * 2 );
			}
			return;
		}

	}

}