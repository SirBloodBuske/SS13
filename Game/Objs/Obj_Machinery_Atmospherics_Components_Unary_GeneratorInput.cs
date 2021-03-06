// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Atmospherics_Components_Unary_GeneratorInput : Obj_Machinery_Atmospherics_Components_Unary {

		public dynamic update_cycle = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "he_intact";
		}

		public Obj_Machinery_Atmospherics_Components_Unary_GeneratorInput ( dynamic loc = null, int? process = null ) : base( (object)(loc), process ) {
			
		}

		// Function from file: generator_input.dm
		public dynamic return_exchange_air(  ) {
			return this.airs[1];
		}

		// Function from file: generator_input.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			
			if ( Lang13.Bool( this.nodes[1] ) ) {
				this.icon_state = "intact";
			} else {
				this.icon_state = "exposed";
			}
			return false;
		}

	}

}