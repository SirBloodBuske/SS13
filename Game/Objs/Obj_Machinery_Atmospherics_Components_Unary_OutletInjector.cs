// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Atmospherics_Components_Unary_OutletInjector : Obj_Machinery_Atmospherics_Components_Unary {

		public double? on = 0;
		public bool injecting = false;
		public int volume_rate = 50;
		public double frequency = 0;
		public dynamic id = null;
		public RadioFrequency radio_connection = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.level = 1;
			this.icon_state = "inje_map";
		}

		public Obj_Machinery_Atmospherics_Components_Unary_OutletInjector ( dynamic loc = null, int? process = null ) : base( (object)(loc), process ) {
			
		}

		// Function from file: outlet_injector.dm
		public override bool receive_signal( Signal signal = null, bool? receive_method = null, dynamic receive_param = null ) {
			double? number = null;
			dynamic air_contents = null;

			
			if ( !Lang13.Bool( signal.data["tag"] ) || signal.data["tag"] != this.id || signal.data["sigtype"] != "command" ) {
				return false;
			}

			if ( signal.data.Contains( "power" ) ) {
				this.on = String13.ParseNumber( signal.data["power"] );
			}

			if ( signal.data.Contains( "power_toggle" ) ) {
				this.on = !Lang13.Bool( this.on ) ?1:0;
			}

			if ( signal.data.Contains( "inject" ) ) {
				Task13.Schedule( 0, (Task13.Closure)(() => {
					this.inject();
					return;
				}));
				return false;
			}

			if ( signal.data.Contains( "set_volume_rate" ) ) {
				number = String13.ParseNumber( signal.data["set_volume_rate"] );
				air_contents = this.airs[1];
				this.volume_rate = Num13.MaxInt( 0, Num13.MinInt( ((int)( number ??0 )), Convert.ToInt32( air_contents.volume ) ) );
			}

			if ( signal.data.Contains( "status" ) ) {
				Task13.Schedule( 2, (Task13.Closure)(() => {
					this.broadcast_status();
					return;
				}));
				return false;
			}
			Task13.Schedule( 2, (Task13.Closure)(() => {
				this.broadcast_status();
				return;
			}));
			this.update_icon();
			return false;
		}

		// Function from file: outlet_injector.dm
		public override void atmosinit( ByTable node_connects = null ) {
			this.set_frequency( this.frequency );
			this.broadcast_status();
			base.atmosinit( node_connects );
			return;
		}

		// Function from file: outlet_injector.dm
		public bool broadcast_status(  ) {
			Signal signal = null;

			
			if ( !( this.radio_connection != null ) ) {
				return false;
			}
			signal = new Signal();
			signal.transmission_method = 1;
			signal.source = this;
			signal.data = new ByTable().Set( "tag", this.id ).Set( "device", "AO" ).Set( "power", this.on ).Set( "volume_rate", this.volume_rate ).Set( "sigtype", "status" );
			this.radio_connection.post_signal( this, signal );
			return true;
		}

		// Function from file: outlet_injector.dm
		public void set_frequency( double new_frequency = 0 ) {
			GlobalVars.SSradio.remove_object( this, this.frequency );
			this.frequency = new_frequency;

			if ( this.frequency != 0 ) {
				this.radio_connection = GlobalVars.SSradio.add_object( this, this.frequency );
			}
			return;
		}

		// Function from file: outlet_injector.dm
		public bool inject(  ) {
			dynamic air_contents = null;
			dynamic transfer_moles = null;
			dynamic removed = null;

			
			if ( Lang13.Bool( this.on ) || this.injecting ) {
				return false;
			}
			air_contents = this.airs[1];
			this.injecting = true;

			if ( Convert.ToDouble( air_contents.temperature ) > 0 ) {
				transfer_moles = air_contents.return_pressure() * this.volume_rate / ( air_contents.temperature * 8.31 );
				removed = air_contents.remove( transfer_moles );
				this.loc.assume_air( removed );
				this.update_parents();
			}
			Icon13.Flick( "inje_inject", this );
			return false;
		}

		// Function from file: outlet_injector.dm
		public override int? process_atmos(  ) {
			dynamic air_contents = null;
			dynamic transfer_moles = null;
			dynamic removed = null;

			base.process_atmos();
			this.injecting = false;

			if ( !Lang13.Bool( this.on ) || ( this.stat & 2 ) != 0 ) {
				return 0;
			}
			air_contents = this.airs[1];

			if ( Convert.ToDouble( air_contents.temperature ) > 0 ) {
				transfer_moles = air_contents.return_pressure() * this.volume_rate / ( air_contents.temperature * 8.31 );
				removed = air_contents.remove( transfer_moles );
				this.loc.assume_air( removed );
				this.air_update_turf();
				this.update_parents();
			}
			return 1;
		}

		// Function from file: outlet_injector.dm
		public override void power_change(  ) {
			int old_stat = 0;

			old_stat = this.stat;
			base.power_change();

			if ( old_stat != this.stat ) {
				this.update_icon();
			}
			return;
		}

		// Function from file: outlet_injector.dm
		public override void update_icon_nopipes( bool? animation = null ) {
			
			if ( !Lang13.Bool( this.nodes[1] ) || !Lang13.Bool( this.on ) || ( this.stat & 3 ) != 0 ) {
				this.icon_state = "inje_off";
				return;
			}
			this.icon_state = "inje_on";
			return;
		}

		// Function from file: outlet_injector.dm
		public override dynamic Destroy(  ) {
			
			if ( GlobalVars.SSradio != null ) {
				GlobalVars.SSradio.remove_object( this, this.frequency );
			}
			return base.Destroy();
		}

	}

}