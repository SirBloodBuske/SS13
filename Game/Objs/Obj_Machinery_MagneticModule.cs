// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_MagneticModule : Obj_Machinery {

		public double freq = 1449;
		public int electricity_level = 1;
		public int magnetic_field = 1;
		public bool code = false;
		public Ent_Static center = null;
		public bool on = false;
		public bool pulling = false;
		public double center_x = 0;
		public double center_y = 0;
		public double max_dist = 20;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.level = 1;
			this.anchored = 1;
			this.idle_power_usage = 50;
			this.icon = "icons/obj/objects.dmi";
			this.icon_state = "floor_magnet-f";
			this.layer = 2.5;
		}

		// Function from file: magnet.dm
		public Obj_Machinery_MagneticModule ( dynamic loc = null ) : base( (object)(loc) ) {
			Ent_Static T = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			T = this.loc;
			this.hide( Lang13.Bool( ((dynamic)T).intact ) );
			this.center = T;
			Task13.Schedule( 10, (Task13.Closure)(() => {
				
				if ( GlobalVars.SSradio != null ) {
					GlobalVars.SSradio.add_object( this, this.freq, GlobalVars.RADIO_MAGNETS );
				}
				return;
			}));
			Task13.Schedule( 0, (Task13.Closure)(() => {
				this.magnetic_process();
				return;
			}));
			return;
		}

		// Function from file: magnet.dm
		public override int? process( dynamic seconds = null ) {
			
			if ( ( this.stat & 2 ) != 0 ) {
				this.on = false;
			}

			if ( this.electricity_level <= 0 ) {
				this.electricity_level = 1;
			}

			if ( this.magnetic_field <= 0 ) {
				this.magnetic_field = 1;
			}

			if ( Math.Abs( this.center_x ) > this.max_dist ) {
				this.center_x = this.max_dist;
			}

			if ( Math.Abs( this.center_y ) > this.max_dist ) {
				this.center_y = this.max_dist;
			}

			if ( this.magnetic_field > 4 ) {
				this.magnetic_field = 4;
			}

			if ( this.electricity_level > 12 ) {
				this.electricity_level = 12;
			}

			if ( this.on ) {
				this.use_power = 2;
				this.active_power_usage = this.electricity_level * 15;
			} else {
				this.use_power = 0;
			}
			this.updateicon();
			return null;
		}

		// Function from file: magnet.dm
		public override bool receive_signal( Signal signal = null, bool? receive_method = null, dynamic receive_param = null ) {
			dynamic command = null;
			dynamic modifier = null;
			bool signal_code = false;

			command = signal.data["command"];
			modifier = signal.data["modifier"];
			signal_code = Lang13.Bool( signal.data["code"] );

			if ( Lang13.Bool( command ) && signal_code == this.code ) {
				this.Cmd( command, modifier );
			}
			return false;
		}

		// Function from file: magnet.dm
		public void magnetic_process(  ) {
			Obj M = null;
			Mob_Living_Silicon S = null;

			
			if ( this.pulling ) {
				return;
			}

			while (this.on) {
				this.pulling = true;
				this.center = Map13.GetTile( ((int)( this.x + this.center_x )), ((int)( this.y + this.center_y )), this.z );

				if ( this.center != null ) {
					
					foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInRangeExcludeThis( this.center, this.magnetic_field ), typeof(Obj) )) {
						M = _a;
						

						if ( !Lang13.Bool( M.anchored ) && Lang13.Bool( M.flags & 64 ) ) {
							Map13.StepTowardsSimple( M, this.center );
						}
					}

					foreach (dynamic _b in Lang13.Enumerate( Map13.FetchInRangeExcludeThis( this.center, this.magnetic_field ), typeof(Mob_Living_Silicon) )) {
						S = _b;
						

						if ( S is Mob_Living_Silicon_Ai ) {
							continue;
						}
						Map13.StepTowardsSimple( S, this.center );
					}
				}
				this.f_use_power( this.electricity_level * 5 );
				Task13.Sleep( 13 - this.electricity_level );
			}
			this.pulling = false;
			return;
		}

		// Function from file: magnet.dm
		public void Cmd( dynamic command = null, dynamic modifier = null ) {
			
			if ( Lang13.Bool( command ) ) {
				
				dynamic _a = command; // Was a switch-case, sorry for the mess.
				if ( _a=="set-electriclevel" ) {
					
					if ( Lang13.Bool( modifier ) ) {
						this.electricity_level = Convert.ToInt32( modifier );
					}
				} else if ( _a=="set-magneticfield" ) {
					
					if ( Lang13.Bool( modifier ) ) {
						this.magnetic_field = Convert.ToInt32( modifier );
					}
				} else if ( _a=="add-elec" ) {
					this.electricity_level++;

					if ( this.electricity_level > 12 ) {
						this.electricity_level = 12;
					}
				} else if ( _a=="sub-elec" ) {
					this.electricity_level--;

					if ( this.electricity_level <= 0 ) {
						this.electricity_level = 1;
					}
				} else if ( _a=="add-mag" ) {
					this.magnetic_field++;

					if ( this.magnetic_field > 4 ) {
						this.magnetic_field = 4;
					}
				} else if ( _a=="sub-mag" ) {
					this.magnetic_field--;

					if ( this.magnetic_field <= 0 ) {
						this.magnetic_field = 1;
					}
				} else if ( _a=="set-x" ) {
					
					if ( Lang13.Bool( modifier ) ) {
						this.center_x = Convert.ToDouble( modifier );
					}
				} else if ( _a=="set-y" ) {
					
					if ( Lang13.Bool( modifier ) ) {
						this.center_y = Convert.ToDouble( modifier );
					}
				} else if ( _a=="N" ) {
					this.center_y++;
				} else if ( _a=="S" ) {
					this.center_y--;
				} else if ( _a=="E" ) {
					this.center_x++;
				} else if ( _a=="W" ) {
					this.center_x--;
				} else if ( _a=="C" ) {
					this.center_x = 0;
					this.center_y = 0;
				} else if ( _a=="R" ) {
					this.center_x = Rand13.Int( ((int)( -this.max_dist )), ((int)( this.max_dist )) );
					this.center_y = Rand13.Int( ((int)( -this.max_dist )), ((int)( this.max_dist )) );
				} else if ( _a=="set-code" ) {
					
					if ( Lang13.Bool( modifier ) ) {
						this.code = Lang13.Bool( modifier );
					}
				} else if ( _a=="toggle-power" ) {
					this.on = !this.on;

					if ( this.on ) {
						Task13.Schedule( 0, (Task13.Closure)(() => {
							this.magnetic_process();
							return;
						}));
					}
				}
			}
			return;
		}

		// Function from file: magnet.dm
		public void updateicon(  ) {
			string state = null;
			string onstate = null;

			state = "floor_magnet";
			onstate = "";

			if ( !this.on ) {
				onstate = "0";
			}

			if ( this.invisibility != 0 ) {
				this.icon_state = "" + state + onstate + "-f";
			} else {
				this.icon_state = "" + state + onstate;
			}
			return;
		}

		// Function from file: magnet.dm
		public override void hide( bool h = false ) {
			this.invisibility = ( h ? 101 : 0 );
			this.updateicon();
			return;
		}

		// Function from file: magnet.dm
		public override dynamic Destroy(  ) {
			dynamic _default = null;

			
			if ( GlobalVars.SSradio != null ) {
				GlobalVars.SSradio.remove_object( this, this.freq );
			}
			_default = base.Destroy();
			this.center = null;
			return _default;
		}

	}

}