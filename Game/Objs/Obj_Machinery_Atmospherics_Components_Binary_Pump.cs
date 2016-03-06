// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Atmospherics_Components_Binary_Pump : Obj_Machinery_Atmospherics_Components_Binary {

		public double? on = 0;
		public double target_pressure = 101.32499694824219;
		public double frequency = 0;
		public dynamic id = null;
		public RadioFrequency radio_connection = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.can_unwrench = true;
			this.icon_state = "pump_map";
		}

		public Obj_Machinery_Atmospherics_Components_Binary_Pump ( dynamic loc = null, int? process = null ) : base( (object)(loc), process ) {
			
		}

		// Function from file: pump.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( !( A is Obj_Item_Weapon_Wrench ) ) {
				return base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}

			if ( !( ( this.stat & 2 ) != 0 ) && Lang13.Bool( this.on ) ) {
				user.WriteMsg( "<span class='warning'>You cannot unwrench this " + this + ", turn it off first!</span>" );
				return 1;
			}
			return base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
		}

		// Function from file: pump.dm
		public override void power_change(  ) {
			base.power_change();
			this.update_icon();
			return;
		}

		// Function from file: pump.dm
		public override bool receive_signal( Signal signal = null, bool? receive_method = null, dynamic receive_param = null ) {
			double? old_on = null;

			
			if ( !Lang13.Bool( signal.data["tag"] ) || signal.data["tag"] != this.id || signal.data["sigtype"] != "command" ) {
				return false;
			}
			old_on = this.on;

			if ( signal.data.Contains( "power" ) ) {
				this.on = String13.ParseNumber( signal.data["power"] );
			}

			if ( signal.data.Contains( "power_toggle" ) ) {
				this.on = !Lang13.Bool( this.on ) ?1:0;
			}

			if ( signal.data.Contains( "set_output_pressure" ) ) {
				this.target_pressure = Num13.MaxInt( 0, Num13.MinInt( ((int)( String13.ParseNumber( signal.data["set_output_pressure"] ) ??0 )), ((int)( 5066.25 )) ) );
			}

			if ( this.on != old_on ) {
				this.investigate_log( "was turned " + ( Lang13.Bool( this.on ) ? "on" : "off" ) + " by a remote signal", "atmos" );
			}

			if ( signal.data.Contains( "status" ) ) {
				this.broadcast_status();
				return false;
			}
			this.broadcast_status();
			this.update_icon();
			return false;
		}

		// Function from file: pump.dm
		public override void atmosinit( ByTable node_connects = null ) {
			base.atmosinit( node_connects );

			if ( this.frequency != 0 ) {
				this.set_frequency( this.frequency );
			}
			return;
		}

		// Function from file: pump.dm
		public override int? ui_act( string action = null, ByTable _params = null, Tgui ui = null, UiState state = null ) {
			int? _default = null;

			dynamic pressure = null;

			
			if ( Lang13.Bool( base.ui_act( action, _params, ui, state ) ) ) {
				return _default;
			}

			switch ((string)( action )) {
				case "power":
					this.on = !Lang13.Bool( this.on ) ?1:0;
					this.investigate_log( "was turned " + ( Lang13.Bool( this.on ) ? "on" : "off" ) + " by " + GlobalFuncs.key_name( Task13.User ), "atmos" );
					_default = GlobalVars.TRUE;
					break;
				case "pressure":
					pressure = _params["pressure"];

					if ( pressure == "max" ) {
						pressure = 4500;
						_default = GlobalVars.TRUE;
					} else if ( pressure == "input" ) {
						pressure = Interface13.Input( "New output pressure (0-" + 4500 + " kPa):", this.name, this.target_pressure, null, null, InputType.Num | InputType.Null );

						if ( !( pressure == null ) && !Lang13.Bool( base.ui_act( action, _params, ui, state ) ) ) {
							_default = GlobalVars.TRUE;
						}
					} else if ( String13.ParseNumber( pressure ) != null ) {
						pressure = String13.ParseNumber( pressure );
						_default = GlobalVars.TRUE;
					}

					if ( Lang13.Bool( _default ) ) {
						this.target_pressure = Num13.MaxInt( 0, Num13.MinInt( Convert.ToInt32( pressure ), 4500 ) );
						this.investigate_log( "was set to " + this.target_pressure + " kPa by " + GlobalFuncs.key_name( Task13.User ), "atmos" );
					}
					break;
			}
			this.update_icon();
			return _default;
		}

		// Function from file: pump.dm
		public override ByTable ui_data( dynamic user = null ) {
			ByTable data = null;

			data = new ByTable();
			data["on"] = this.on;
			data["pressure"] = Num13.Floor( this.target_pressure );
			data["max_pressure"] = Num13.Floor( 4500 );
			return data;
		}

		// Function from file: pump.dm
		public override int ui_interact( dynamic user = null, string ui_key = null, Tgui ui = null, bool? force_open = null, Tgui master_ui = null, UiState state = null ) {
			ui_key = ui_key ?? "main";
			force_open = force_open ?? false;
			state = state ?? GlobalVars.default_state;

			ui = GlobalVars.SStgui.try_update_ui( user, this, ui_key, ui, force_open );

			if ( !( ui != null ) ) {
				ui = new Tgui( user, this, ui_key, "atmos_pump", this.name, 335, 115, master_ui, state );
				ui.open();
			}
			return 0;
		}

		// Function from file: pump.dm
		public bool broadcast_status(  ) {
			Signal signal = null;

			
			if ( !( this.radio_connection != null ) ) {
				return false;
			}
			signal = new Signal();
			signal.transmission_method = 1;
			signal.source = this;
			signal.data = new ByTable().Set( "tag", this.id ).Set( "device", "AGP" ).Set( "power", this.on ).Set( "target_output", this.target_pressure ).Set( "sigtype", "status" );
			this.radio_connection.post_signal( this, signal, GlobalVars.RADIO_ATMOSIA );
			return true;
		}

		// Function from file: pump.dm
		public void set_frequency( double new_frequency = 0 ) {
			GlobalVars.SSradio.remove_object( this, this.frequency );
			this.frequency = new_frequency;

			if ( this.frequency != 0 ) {
				this.radio_connection = GlobalVars.SSradio.add_object( this, this.frequency, GlobalVars.RADIO_ATMOSIA );
			}
			return;
		}

		// Function from file: pump.dm
		public override int? process_atmos(  ) {
			GasMixture air1 = null;
			dynamic air2 = null;
			dynamic output_starting_pressure = null;
			double pressure_delta = 0;
			double transfer_moles = 0;
			GasMixture removed = null;

			
			if ( ( this.stat & 3 ) != 0 ) {
				return 0;
			}

			if ( !Lang13.Bool( this.on ) ) {
				return 0;
			}
			air1 = this.airs[1];
			air2 = this.airs[2];
			output_starting_pressure = air2.return_pressure();

			if ( this.target_pressure - Convert.ToDouble( output_starting_pressure ) < 0.01 ) {
				return 1;
			}

			if ( air1.total_moles() > 0 && Convert.ToDouble( air1.temperature ) > 0 ) {
				pressure_delta = this.target_pressure - Convert.ToDouble( output_starting_pressure );
				transfer_moles = pressure_delta * Convert.ToDouble( air2.volume ) / Convert.ToDouble( air1.temperature * 8.31 );
				removed = air1.remove( transfer_moles );
				air2.merge( removed );
				this.update_parents();
			}
			return 1;
		}

		// Function from file: pump.dm
		public override void update_icon_nopipes( bool? animation = null ) {
			
			if ( ( this.stat & 2 ) != 0 ) {
				this.icon_state = "pump_off";
				return;
			}
			this.icon_state = "pump_" + ( Lang13.Bool( this.on ) ? "on" : "off" );
			return;
		}

		// Function from file: pump.dm
		public override dynamic Destroy(  ) {
			
			if ( GlobalVars.SSradio != null ) {
				GlobalVars.SSradio.remove_object( this, this.frequency );
			}

			if ( this.radio_connection != null ) {
				this.radio_connection = null;
			}
			return base.Destroy();
		}

	}

}