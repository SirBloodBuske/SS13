// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RcdSchematic_Rsf_Camera : RcdSchematic_Rsf {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Camera";
			this.spawn_type = typeof(Obj_Item_Device_Camera);
			this.energy_cost = 4;
		}

		public RcdSchematic_Rsf_Camera ( dynamic n_master = null ) : base( (object)(n_master) ) {
			
		}

	}

}