// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Teleporter : Obj_Machinery_Computer {

		public dynamic locked = null;
		public string regime_set = "Teleporter";
		public string id = null;
		public dynamic power_station = null;
		public bool calibrating = false;
		public dynamic target = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_screen = "teleport";
			this.icon_keyboard = "teleport_key";
			this.circuit = "/obj/item/weapon/circuitboard/teleporter";
		}

		// Function from file: teleporter.dm
		public Obj_Machinery_Computer_Teleporter ( dynamic location = null, dynamic C = null ) : base( (object)(location), (object)(C) ) {
			this.id = "" + Rand13.Int( 1000, 9999 );
			this.link_power_station();
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: teleporter.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return null;
			}

			if ( Lang13.Bool( href_list["eject"] ) ) {
				this.eject();
				this.updateDialog();
				return null;
			}

			if ( !this.check_hub_connection() ) {
				this.say( "<span class='warning'>Error: Unable to detect hub.</span>" );
				return null;
			}

			if ( this.calibrating ) {
				this.say( "<span class='warning'>Error: Calibration in progress. Stand by.</span>" );
				return null;
			}

			if ( Lang13.Bool( href_list["regimeset"] ) ) {
				this.power_station.engaged = 0;
				this.power_station.teleporter_hub.update_icon();
				this.power_station.teleporter_hub.calibrated = 0;
				this.reset_regime();
			}

			if ( Lang13.Bool( href_list["settarget"] ) ) {
				this.power_station.engaged = 0;
				this.power_station.teleporter_hub.update_icon();
				this.power_station.teleporter_hub.calibrated = 0;
				this.set_target( Task13.User );
			}

			if ( Lang13.Bool( href_list["locked"] ) ) {
				this.power_station.engaged = 0;
				this.power_station.teleporter_hub.update_icon();
				this.power_station.teleporter_hub.calibrated = 0;
				this.target = GlobalFuncs.get_turf( this.locked.locked_location );
			}

			if ( Lang13.Bool( href_list["calibrate"] ) ) {
				
				if ( !Lang13.Bool( this.target ) ) {
					this.say( "<span class='danger'>Error: No target set to calibrate to.</span>" );
					return null;
				}

				if ( Lang13.Bool( this.power_station.teleporter_hub.calibrated ) || this.power_station.teleporter_hub.accurate >= 3 ) {
					this.say( "<span class='warning'>Hub is already calibrated!</span>" );
					return null;
				}
				this.say( "<span class='notice'>Processing hub calibration to target...</span>" );
				this.calibrating = true;
				Task13.Schedule( ((int)( ( 3 - this.power_station.teleporter_hub.accurate ) * 50 )), (Task13.Closure)(() => {
					this.calibrating = false;

					if ( this.check_hub_connection() ) {
						this.power_station.teleporter_hub.calibrated = 1;
						this.say( "<span class='notice'>Calibration complete.</span>" );
					} else {
						this.say( "<span class='danger'>Error: Unable to detect hub.</span>" );
					}
					this.updateDialog();
					return;
				}));
			}
			this.updateDialog();
			return null;
		}

		// Function from file: teleporter.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			string data = null;
			Browser popup = null;

			data = "<h3>Teleporter Status</h3>";

			if ( !Lang13.Bool( this.power_station ) ) {
				data += "<div class='statusDisplay'>No power station linked.</div>";
			} else if ( !Lang13.Bool( this.power_station.teleporter_hub ) ) {
				data += "<div class='statusDisplay'>No hub linked.</div>";
			} else {
				data += "<div class='statusDisplay'>Current regime: " + this.regime_set + "<BR>";
				data += "Current target: " + ( !Lang13.Bool( this.target ) ? "None" : "" + GlobalFuncs.get_area( this.target ) + " " + ( this.regime_set != "Gate" ? "" : "Teleporter" ) ) + "<BR>";

				if ( this.calibrating ) {
					data += "Calibration: <font color='yellow'>In Progress</font>";
				} else if ( Lang13.Bool( this.power_station.teleporter_hub.calibrated ) || this.power_station.teleporter_hub.accurate >= 3 ) {
					data += "Calibration: <font color='green'>Optimal</font>";
				} else {
					data += "Calibration: <font color='red'>Sub-Optimal</font>";
				}
				data += "</div><BR>";
				data += new Txt( "<A href='?src=" ).Ref( this ).str( ";regimeset=1'>Change regime</A><BR>" ).ToString();
				data += new Txt( "<A href='?src=" ).Ref( this ).str( ";settarget=1'>Set target</A><BR>" ).ToString();

				if ( Lang13.Bool( this.locked ) ) {
					data += new Txt( "<BR><A href='?src=" ).Ref( this ).str( ";locked=1'>Get target from memory</A><BR>" ).ToString();
					data += new Txt( "<A href='?src=" ).Ref( this ).str( ";eject=1'>Eject GPS device</A><BR>" ).ToString();
				} else {
					data += "<BR><span class='linkOff'>Get target from memory</span><BR>";
					data += "<span class='linkOff'>Eject GPS device</span><BR>";
				}
				data += new Txt( "<BR><A href='?src=" ).Ref( this ).str( ";calibrate=1'>Calibrate Hub</A>" ).ToString();
			}
			popup = new Browser( user, "teleporter", this.name, 400, 400 );
			popup.set_content( data );
			popup.open();
			return null;
		}

		// Function from file: teleporter.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			
			if ( Lang13.Bool( base.attack_hand( (object)(a), b, c ) ) ) {
				return null;
			}
			this.interact( a );
			return null;
		}

		// Function from file: teleporter.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.attack_hand( user );
			return null;
		}

		// Function from file: teleporter.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic L = null;

			
			if ( A is Obj_Item_Device_Gps ) {
				L = A;

				if ( L.locked_location != null && !( ( this.stat & 3 ) != 0 ) ) {
					
					if ( !((Mob)user).unEquip( L ) ) {
						user.WriteMsg( new Txt( "<span class='warning'>" ).the( A ).item().str( " is stuck to your hand, you cannot put it in " ).the( this ).item().str( "!</span>" ).ToString() );
						return null;
					}
					L.loc = this;
					this.locked = L;
					user.WriteMsg( "<span class='caution'>You insert the GPS device into the " + this.name + "'s slot.</span>" );
				}
			} else {
				base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			return null;
		}

		// Function from file: teleporter.dm
		public void set_target( Mob user = null ) {
			ByTable L = null;
			ByTable areaindex = null;
			Obj_Item_Device_Radio_Beacon R = null;
			dynamic T = null;
			string tmpname = null;
			Obj_Item_Weapon_Implant_Tracking I = null;
			Ent_Static M = null;
			dynamic T2 = null;
			string tmpname2 = null;
			dynamic desc = null;
			ByTable L2 = null;
			ByTable areaindex2 = null;
			ByTable S = null;
			Obj_Machinery_Teleport_Station R2 = null;
			dynamic T3 = null;
			string tmpname3 = null;
			dynamic desc2 = null;
			dynamic trg = null;

			
			if ( this.regime_set == "Teleporter" ) {
				L = new ByTable();
				areaindex = new ByTable();

				foreach (dynamic _a in Lang13.Enumerate( typeof(Game13), typeof(Obj_Item_Device_Radio_Beacon) )) {
					R = _a;
					
					T = GlobalFuncs.get_turf( R );

					if ( !Lang13.Bool( T ) ) {
						continue;
					}

					if ( Convert.ToInt32( T.z ) == 2 || Convert.ToDouble( T.z ) > 7 ) {
						continue;
					}
					tmpname = T.loc.name;

					if ( Lang13.Bool( areaindex[tmpname] ) ) {
						tmpname = "" + tmpname + " (" + ++areaindex[tmpname] + ")";
					} else {
						areaindex[tmpname] = 1;
					}
					L[tmpname] = R;
				}

				foreach (dynamic _b in Lang13.Enumerate( GlobalVars.tracked_implants, typeof(Obj_Item_Weapon_Implant_Tracking) )) {
					I = _b;
					

					if ( !Lang13.Bool( I.implanted ) || !( I.loc is Mob ) ) {
						continue;
					} else {
						M = I.loc;

						if ( Convert.ToInt32( ((dynamic)M).stat ) == 2 ) {
							
							if ( Convert.ToDouble( ((dynamic)M).timeofdeath + 6000 ) < Game13.time ) {
								continue;
							}
						}
						T2 = GlobalFuncs.get_turf( M );

						if ( !Lang13.Bool( T2 ) ) {
							continue;
						}

						if ( Convert.ToInt32( T2.z ) == 2 ) {
							continue;
						}
						tmpname2 = ((dynamic)M).real_name;

						if ( Lang13.Bool( areaindex[tmpname2] ) ) {
							tmpname2 = "" + tmpname2 + " (" + ++areaindex[tmpname2] + ")";
						} else {
							areaindex[tmpname2] = 1;
						}
						L[tmpname2] = I;
					}
				}
				desc = Interface13.Input( "Please select a location to lock in.", "Locking Computer", null, null, L, InputType.Any );
				this.target = L[desc];
			} else {
				L2 = new ByTable();
				areaindex2 = new ByTable();
				S = this.power_station.linked_stations;

				if ( !( S.len != 0 ) ) {
					user.WriteMsg( "<span class='alert'>No connected stations located.</span>" );
					return;
				}

				foreach (dynamic _c in Lang13.Enumerate( S, typeof(Obj_Machinery_Teleport_Station) )) {
					R2 = _c;
					
					T3 = GlobalFuncs.get_turf( R2 );

					if ( !Lang13.Bool( T3 ) || !Lang13.Bool( R2.teleporter_hub ) || !Lang13.Bool( R2.teleporter_console ) ) {
						continue;
					}

					if ( Convert.ToInt32( T3.z ) == 2 || Convert.ToDouble( T3.z ) > 7 ) {
						continue;
					}
					tmpname3 = T3.loc.name;

					if ( Lang13.Bool( areaindex2[tmpname3] ) ) {
						tmpname3 = "" + tmpname3 + " (" + ++areaindex2[tmpname3] + ")";
					} else {
						areaindex2[tmpname3] = 1;
					}
					L2[tmpname3] = R2;
				}
				desc2 = Interface13.Input( "Please select a station to lock in.", "Locking Computer", null, null, L2, InputType.Any );
				this.target = L2[desc2];

				if ( Lang13.Bool( this.target ) ) {
					trg = this.target;
					trg.linked_stations.Or( this.power_station );
					trg.stat &= 65533;

					if ( Lang13.Bool( trg.teleporter_hub ) ) {
						trg.teleporter_hub.stat &= 65533;
						trg.teleporter_hub.update_icon();
					}

					if ( Lang13.Bool( trg.teleporter_console ) ) {
						trg.teleporter_console.stat &= 65533;
						trg.teleporter_console.update_icon();
					}
				}
			}
			return;
		}

		// Function from file: teleporter.dm
		public void eject(  ) {
			
			if ( Lang13.Bool( this.locked ) ) {
				this.locked.loc = this.loc;
				this.locked = null;
			}
			return;
		}

		// Function from file: teleporter.dm
		public void reset_regime(  ) {
			this.target = null;

			if ( this.regime_set == "Teleporter" ) {
				this.regime_set = "Gate";
			} else {
				this.regime_set = "Teleporter";
			}
			return;
		}

		// Function from file: teleporter.dm
		public bool check_hub_connection(  ) {
			
			if ( !Lang13.Bool( this.power_station ) ) {
				return false;
			}

			if ( !Lang13.Bool( this.power_station.teleporter_hub ) ) {
				return false;
			}
			return true;
		}

		// Function from file: teleporter.dm
		public dynamic link_power_station(  ) {
			
			if ( Lang13.Bool( this.power_station ) ) {
				return null;
			}

			foreach (dynamic _a in Lang13.Enumerate( new ByTable(new object [] { GlobalVars.NORTH, GlobalVars.EAST, GlobalVars.SOUTH, GlobalVars.WEST }) )) {
				this.dir = Convert.ToInt32( _a );
				
				this.power_station = Lang13.FindIn( typeof(Obj_Machinery_Teleport_Station), Map13.GetStep( this, this.dir ) );

				if ( Lang13.Bool( this.power_station ) ) {
					break;
				}
			}
			return this.power_station;
		}

		// Function from file: teleporter.dm
		public override dynamic Destroy(  ) {
			
			if ( Lang13.Bool( this.power_station ) ) {
				this.power_station.teleporter_console = null;
				this.power_station = null;
			}
			return base.Destroy();
		}

		// Function from file: teleporter.dm
		public override void initialize(  ) {
			this.link_power_station();
			return;
		}

	}

}