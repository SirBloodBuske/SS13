// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_SubspaceAmplifier : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Subspace Amplifier";
			this.desc = "A compact micro-machine capable of amplifying weak subspace transmissions.";
			this.id = "s-amplifier";
			this.req_tech = new ByTable().Set( "programming", 3 ).Set( "magnets", 4 ).Set( "materials", 4 ).Set( "bluespace", 2 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$iron", 10 ).Set( "$gold", 30 ).Set( "$uranium", 15 );
			this.category = "Stock Parts";
			this.build_path = typeof(Obj_Item_Weapon_StockParts_Subspace_Amplifier);
		}

	}

}