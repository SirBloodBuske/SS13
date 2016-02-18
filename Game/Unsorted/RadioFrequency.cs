// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RadioFrequency : Game_Data {

		public dynamic frequency = null;
		public ByTable devices = new ByTable();

		// Function from file: communications.dm
		public void remove_listener( Obj device = null ) {
			dynamic devices_filter = null;
			ByTable devices_line = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.devices )) {
				devices_filter = _a;
				
				devices_line = this.devices[devices_filter];

				if ( !( devices_line != null ) ) {
					this.devices.Remove( devices_filter );
				}
				devices_line.Remove( device );

				if ( !( devices_line.len != 0 ) ) {
					this.devices.Remove( devices_filter );
				}
			}
			return;
		}

		// Function from file: communications.dm
		public void add_listener( Obj device = null, string filter = null ) {
			ByTable devices_line = null;

			
			if ( !Lang13.Bool( filter ) ) {
				filter = "_default";
			}
			devices_line = this.devices[filter];

			if ( !( devices_line != null ) ) {
				devices_line = new ByTable();
				this.devices[filter] = devices_line;
			}
			devices_line.Add( device );
			return;
		}

		// Function from file: communications.dm
		public bool post_signal( Obj source = null, Signal signal = null, string filter = null, int? range = null ) {
			ByTable filter_list = null;
			dynamic start_point = null;
			dynamic current_filter = null;
			Obj device = null;
			dynamic end_point = null;

			
			if ( Lang13.Bool( filter ) ) {
				filter_list = new ByTable(new object [] { filter, "_default" });
			} else {
				filter_list = this.devices;
			}

			if ( Lang13.Bool( range ) ) {
				start_point = GlobalFuncs.get_turf( source );

				if ( !Lang13.Bool( start_point ) ) {
					return false;
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( filter_list )) {
				current_filter = _b;
				

				foreach (dynamic _a in Lang13.Enumerate( this.devices[current_filter], typeof(Obj) )) {
					device = _a;
					

					if ( device == source ) {
						continue;
					}

					if ( Lang13.Bool( range ) ) {
						end_point = GlobalFuncs.get_turf( device );

						if ( !Lang13.Bool( end_point ) ) {
							continue;
						}

						if ( start_point.z != end_point.z || ( range ??0) > 0 && Map13.GetDistance( start_point, end_point ) > ( range ??0) ) {
							continue;
						}
					}
					device.receive_signal( signal, true, this.frequency );
				}
			}
			return false;
		}

	}

}