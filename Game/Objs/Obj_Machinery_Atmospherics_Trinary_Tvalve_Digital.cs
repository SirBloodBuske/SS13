// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Atmospherics_Trinary_Tvalve_Digital : Obj_Machinery_Atmospherics_Trinary_Tvalve {

		public bool frequency = false;
		public dynamic id_tag = null;
		public RadioFrequency radio_connection = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.mirror = typeof(Obj_Machinery_Atmospherics_Trinary_Tvalve_Digital_Mirrored);
			this.icon = "icons/obj/atmospherics/digital_valve.dmi";
		}

		public Obj_Machinery_Atmospherics_Trinary_Tvalve_Digital ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: t_valve.dm
		public override bool receive_signal( Game_Data signal = null, bool? receive_method = null, dynamic receive_param = null ) {
			bool state_changed = false;

			
			if ( !Lang13.Bool( ((dynamic)signal).data["tag"] ) || ((dynamic)signal).data["tag"] != this.id_tag ) {
				return false;
			}
			state_changed = false;

			dynamic _a = ((dynamic)signal).data["command"]; // Was a switch-case, sorry for the mess.
			if ( _a=="valve_open" ) {
				
				if ( !Lang13.Bool( this.state ) ) {
					this.go_to_side();
					state_changed = true;
				}
			} else if ( _a=="valve_close" ) {
				
				if ( Lang13.Bool( this.state ) ) {
					this.go_straight();
					state_changed = true;
				}
			} else if ( _a=="valve_toggle" ) {
				
				if ( Lang13.Bool( this.state ) ) {
					this.go_straight();
				} else {
					this.go_to_side();
				}
				state_changed = true;
			}

			if ( state_changed ) {
				this.investigation_log( "atmos", "was " + ( Lang13.Bool( this.state ) ? "opened (side)" : "closed (straight) " ) + " by a signal" );
			}
			return false;
		}

		// Function from file: t_valve.dm
		public override bool initialize( bool? suppress_icon_check = null ) {
			base.initialize( suppress_icon_check );

			if ( this.frequency ) {
				this.set_frequency( this.frequency );
			}
			return false;
		}

		// Function from file: t_valve.dm
		public void set_frequency( bool new_frequency = false ) {
			GlobalVars.radio_controller.remove_object( this, this.frequency );
			this.frequency = new_frequency;

			if ( this.frequency ) {
				this.radio_connection = GlobalVars.radio_controller.add_object( this, this.frequency, GlobalVars.RADIO_ATMOSIA );
			}
			return;
		}

		// Function from file: t_valve.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( !this.allowed( a ) ) {
				GlobalFuncs.to_chat( a, "<span class='warning'>Access denied.</span>" );
				return null;
			}
			base.attack_hand( (object)(a), (object)(b), (object)(c) );
			return null;
		}

		// Function from file: t_valve.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.add_hiddenprint( user );
			return this.attack_hand( user );
		}

	}

}