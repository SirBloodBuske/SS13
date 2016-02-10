// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_PhazonPhaseArray : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Phazon Phase Array";
			this.desc = "Show physics who's boss.";
			this.id = "phazon_phasearray";
			this.req_tech = new ByTable().Set( "bluespace", 10 ).Set( "programming", 4 );
			this.build_type = 16;
			this.materials = new ByTable().Set( "$iron", 5000 ).Set( "$phazon", 2000 );
			this.category = "Exosuit_Modules";
			this.build_path = typeof(Obj_Item_MechaParts_Part_PhazonPhaseArray);
		}

	}

}