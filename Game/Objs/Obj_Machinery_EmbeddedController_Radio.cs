// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_EmbeddedController_Radio : Obj_Machinery_EmbeddedController {

		public double frequency = 0;
		public RadioFrequency radio_connection = null;

		public Obj_Machinery_EmbeddedController_Radio ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: embedded_controller_base.dm
		public void set_frequency( double new_frequency = 0 ) {
			GlobalVars.SSradio.remove_object( this, this.frequency );
			this.frequency = new_frequency;
			this.radio_connection = GlobalVars.SSradio.add_object( this, this.frequency );
			return;
		}

		// Function from file: embedded_controller_base.dm
		public override bool post_signal( Signal signal = null, dynamic comm_line = null ) {
			signal.transmission_method = 1;

			if ( this.radio_connection != null ) {
				return this.radio_connection.post_signal( this, signal );
			} else {
				signal = null;
			}
			return false;
		}

		// Function from file: embedded_controller_base.dm
		public override void initialize(  ) {
			this.set_frequency( this.frequency );
			return;
		}

		// Function from file: embedded_controller_base.dm
		public override dynamic Destroy(  ) {
			
			if ( GlobalVars.SSradio != null ) {
				GlobalVars.SSradio.remove_object( this, this.frequency );
			}
			return base.Destroy();
		}

	}

}