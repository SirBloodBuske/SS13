// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Media_Transmitter : Obj_Machinery_Media {

		public dynamic media_frequency = 1234;
		public dynamic media_crypto = null;

		// Function from file: transmitter.dm
		public Obj_Machinery_Media_Transmitter ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.connect_frequency();
			return;
		}

		// Function from file: transmitter.dm
		public override void update_music(  ) {
			string freq = null;
			Obj_Machinery_Media_Receiver R = null;

			freq = String13.NumberToString( Convert.ToDouble( this.media_frequency ) );
			Interface13.Stat( null, GlobalVars.media_receivers.Contains( freq ) );

			if ( false ) {
				
				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.media_receivers[freq], typeof(Obj_Machinery_Media_Receiver) )) {
					R = _a;
					

					if ( R.media_crypto == this.media_crypto ) {
						R.receive_broadcast( this.media_url, this.media_start_time );
					}
				}
			}
			return;
		}

		// Function from file: transmitter.dm
		public void disconnect_frequency(  ) {
			ByTable transmitters = null;
			string freq = null;

			transmitters = new ByTable();
			freq = String13.NumberToString( Convert.ToDouble( this.media_frequency ) );
			Interface13.Stat( null, GlobalVars.media_transmitters.Contains( freq ) );

			if ( false ) {
				transmitters = GlobalVars.media_transmitters[freq];
			}
			transmitters.Remove( this );
			GlobalVars.media_transmitters[freq] = transmitters;
			this.broadcast();
			return;
		}

		// Function from file: transmitter.dm
		public void connect_frequency(  ) {
			ByTable transmitters = null;
			string freq = null;

			transmitters = new ByTable();
			freq = String13.NumberToString( Convert.ToDouble( this.media_frequency ) );
			Interface13.Stat( null, GlobalVars.media_transmitters.Contains( freq ) );

			if ( false ) {
				transmitters = GlobalVars.media_transmitters[freq];
			}
			transmitters.Add( this );
			GlobalVars.media_transmitters[freq] = transmitters;
			return;
		}

		// Function from file: transmitter.dm
		public void broadcast( string url = null, int? start_time = null ) {
			url = url ?? "";
			start_time = start_time ?? 0;

			this.media_url = url;
			this.media_start_time = start_time;
			this.update_music();
			return;
		}

	}

}