// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Box_Samplebags : Obj_Item_Weapon_Storage_Box {

		// Function from file: tools_coresampler.dm
		public Obj_Item_Weapon_Storage_Box_Samplebags ( dynamic loc = null ) : base( (object)(loc) ) {
			int? i = null;
			Obj_Item_Weapon_Evidencebag S = null;

			i = null;
			i = 0;

			while (( i ??0) < 7) {
				S = new Obj_Item_Weapon_Evidencebag( this );
				S.name = "sample bag";
				S.desc = "a bag for holding research samples.";
				i++;
			}
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}