// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Tank_Internals_Plasmaman_Belt_Full : Obj_Item_Weapon_Tank_Internals_Plasmaman_Belt {

		// Function from file: tank_types.dm
		public Obj_Item_Weapon_Tank_Internals_Plasmaman_Belt_Full ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.air_contents.assert_gas( "plasma" );
			this.air_contents.gases["plasma"][1] = ( this.volume ??0) * 1013.25 / 2436.07666015625;
			return;
		}

	}

}