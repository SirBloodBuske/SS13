// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Atmospherics_Unary_OxygenGenerator : Obj_Machinery_Atmospherics_Unary {

		public bool on = false;
		public int oxygen_content = 10;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/atmospherics/oxygen_generator.dmi";
			this.icon_state = "intact_off";
		}

		// Function from file: oxygen_generator.dm
		public Obj_Machinery_Atmospherics_Unary_OxygenGenerator ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.air_contents.volume = 50;
			return;
		}

		// Function from file: oxygen_generator.dm
		public override dynamic process(  ) {
			dynamic _default = null;

			dynamic total_moles = null;
			int current_heat_capacity = 0;
			double added_oxygen = 0;

			_default = base.process();

			if ( !this.on ) {
				return _default;
			}
			total_moles = this.air_contents.f_total_moles();

			if ( Convert.ToDouble( total_moles ) < this.oxygen_content ) {
				current_heat_capacity = this.air_contents.heat_capacity();
				added_oxygen = this.oxygen_content - Convert.ToDouble( total_moles );
				this.air_contents.temperature = ( current_heat_capacity * ( this.air_contents.temperature ??0) + added_oxygen * 5463 ) / ( current_heat_capacity + added_oxygen * 20 );
				this.air_contents.oxygen += added_oxygen;

				if ( this.network != null ) {
					((dynamic)this.network).update = 1;
				}
			}
			return 1;
		}

		// Function from file: oxygen_generator.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( this.node != null ) {
				this.icon_state = "intact_" + ( this.on ? "on" : "off" );
			} else {
				this.icon_state = "exposed_off";
				this.on = false;
			}
			return null;
		}

	}

}