// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Nuclearbomb : Obj_Machinery {

		public dynamic timeleft = 60;
		public int timing = 0;
		public dynamic r_code = "ADMIN";
		public string code = "";
		public bool yes_code = false;
		public bool safety = true;
		public dynamic auth = null;
		public string previous_level = "";
		public string lastentered = "";
		public Obj_Item_NukeCore core = null;
		public int deconstruction_state = 5;
		public Image lights = null;
		public Image interior = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.use_power = 0;
			this.icon = "icons/obj/machines/nuke.dmi";
			this.icon_state = "nuclearbomb_base";
		}

		// Function from file: nuclearbomb.dm
		public Obj_Machinery_Nuclearbomb ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.nuke_list.Add( this );
			this.core = new Obj_Item_NukeCore( this );
			GlobalVars.SSobj.processing.Remove( this.core );
			this.update_icon();
			this.previous_level = GlobalFuncs.get_security_level();
			return;
		}

		// Function from file: nuclearbomb.dm
		public override bool blob_act( dynamic severity = null ) {
			
			if ( this.timing == -1 ) {
				return false;
			} else {
				return base.blob_act( (object)(severity) );
			}
		}

		// Function from file: nuclearbomb.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			return false;
		}

		// Function from file: nuclearbomb.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			dynamic I = null;
			dynamic LOC = null;
			double? time = null;
			dynamic M = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return null;
			}
			Task13.User.set_machine( this );

			if ( Lang13.Bool( href_list["auth"] ) ) {
				
				if ( Lang13.Bool( this.auth ) ) {
					this.auth.loc = this.loc;
					this.yes_code = false;
					this.auth = null;
				} else {
					I = Task13.User.get_active_hand();

					if ( I is Obj_Item_Weapon_Disk_Nuclear ) {
						Task13.User.drop_item();
						I.loc = this;
						this.auth = I;
					}
				}
			}

			if ( Lang13.Bool( this.auth ) ) {
				
				if ( Lang13.Bool( href_list["type"] ) ) {
					
					if ( href_list["type"] == "E" ) {
						
						if ( this.code == this.r_code ) {
							this.yes_code = true;
							this.code = null;
						} else {
							this.code = "ERROR";
						}
					} else if ( href_list["type"] == "R" ) {
						this.yes_code = false;
						this.code = null;
					} else {
						this.lastentered = "" + href_list["type"];

						if ( String13.ParseNumber( this.lastentered ) == null ) {
							LOC = GlobalFuncs.get_turf( Task13.User );
							GlobalFuncs.message_admins( new Txt().item( GlobalFuncs.key_name_admin( Task13.User ) ).str( " (<A HREF='?_src_=holder;adminplayerobservefollow=" ).Ref( Task13.User ).str( "'>FLW</A>) tried to exploit a nuclear bomb by entering non-numerical codes: <a href='?_src_=vars;Vars=" ).Ref( this ).str( "'>" ).item( this.lastentered ).str( "</a> ! (" ).item( ( Lang13.Bool( LOC ) ? "<a href='?_src_=holder;adminplayerobservecoodjump=1;X=" + LOC.x + ";Y=" + LOC.y + ";Z=" + LOC.z + "'>JMP</a>" : "null" ) ).str( ")" ).ToString() );
							GlobalFuncs.log_admin( "EXPLOIT : " + GlobalFuncs.key_name( Task13.User ) + " tried to exploit a nuclear bomb by entering non-numerical codes: " + this.lastentered + " !" );
						} else {
							this.code += this.lastentered;

							if ( Lang13.Length( this.code ) > 5 ) {
								this.code = "ERROR";
							}
						}
					}
				}

				if ( this.yes_code ) {
					
					if ( Lang13.Bool( href_list["time"] ) ) {
						time = String13.ParseNumber( href_list["time"] );
						this.timeleft += time;
						this.timeleft = Num13.MinInt( Num13.MaxInt( Num13.Floor( Convert.ToDouble( this.timeleft ) ), 60 ), 600 );
					}

					if ( Lang13.Bool( href_list["timer"] ) ) {
						this.set_active();
					}

					if ( Lang13.Bool( href_list["safety"] ) ) {
						this.set_safety();
					}

					if ( Lang13.Bool( href_list["anchor"] ) ) {
						this.set_anchor();
					}
				}
			}
			this.add_fingerprint( Task13.User );

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( this, 1 ) )) {
				M = _a;
				

				if ( Lang13.Bool( M.client ) && M.machine == this ) {
					this.attack_hand( M );
				}
			}
			return null;
		}

		// Function from file: nuclearbomb.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			string dat = null;
			string message = null;
			Browser popup = null;

			((Mob)a).set_machine( this );
			dat = new Txt( "<TT>\nAuth. Disk: <A href='?src=" ).Ref( this ).str( ";auth=1'>" ).item( ( Lang13.Bool( this.auth ) ? "++++++++++" : "----------" ) ).str( "</A><HR>" ).ToString();

			if ( Lang13.Bool( this.auth ) ) {
				
				if ( this.yes_code ) {
					dat += new Txt( "\n<B>Status</B>: " ).item( ( this.timing != 0 ? "Func/Set" : "Functional" ) ).str( "-" ).item( ( this.safety ? "Safe" : "Engaged" ) ).str( "<BR>\n<B>Timer</B>: " ).item( this.timeleft ).str( "<BR>\n<BR>\nTimer: " ).item( ( this.timing != 0 ? "On" : "Off" ) ).str( " <A href='?src=" ).Ref( this ).str( ";timer=1'>Toggle</A><BR>\nTime: <A href='?src=" ).Ref( this ).str( ";time=-10'>-</A> <A href='?src=" ).Ref( this ).str( ";time=-1'>-</A> " ).item( this.timeleft ).str( " <A href='?src=" ).Ref( this ).str( ";time=1'>+</A> <A href='?src=" ).Ref( this ).str( ";time=10'>+</A><BR>\n<BR>\nSafety: " ).item( ( this.safety ? "On" : "Off" ) ).str( " <A href='?src=" ).Ref( this ).str( ";safety=1'>Toggle</A><BR>\nAnchor: " ).item( ( Lang13.Bool( this.anchored ) ? "Engaged" : "Off" ) ).str( " <A href='?src=" ).Ref( this ).str( ";anchor=1'>Toggle</A><BR>\n" ).ToString();
				} else {
					dat += "\n<B>Status</B>: Auth. S2-" + ( this.safety ? "Safe" : "Engaged" ) + "<BR>\n<B>Timer</B>: " + this.timeleft + "<BR>\n<BR>\nTimer: " + ( this.timing != 0 ? "On" : "Off" ) + " Toggle<BR>\nTime: - - " + this.timeleft + " + +<BR>\n<BR>\n" + ( this.safety ? "On" : "Off" ) + " Safety: Toggle<BR>\nAnchor: " + ( Lang13.Bool( this.anchored ) ? "Engaged" : "Off" ) + " Toggle<BR>\n";
				}
			} else if ( this.timing != 0 ) {
				dat += "\n<B>Status</B>: Set-" + ( this.safety ? "Safe" : "Engaged" ) + "<BR>\n<B>Timer</B>: " + this.timeleft + "<BR>\n<BR>\nTimer: " + ( this.timing != 0 ? "On" : "Off" ) + " Toggle<BR>\nTime: - - " + this.timeleft + " + +<BR>\n<BR>\nSafety: " + ( this.safety ? "On" : "Off" ) + " Toggle<BR>\nAnchor: " + ( Lang13.Bool( this.anchored ) ? "Engaged" : "Off" ) + " Toggle<BR>\n";
			} else {
				dat += "\n<B>Status</B>: Auth. S1-" + ( this.safety ? "Safe" : "Engaged" ) + "<BR>\n<B>Timer</B>: " + this.timeleft + "<BR>\n<BR>\nTimer: " + ( this.timing != 0 ? "On" : "Off" ) + " Toggle<BR>\nTime: - - " + this.timeleft + " + +<BR>\n<BR>\nSafety: " + ( this.safety ? "On" : "Off" ) + " Toggle<BR>\nAnchor: " + ( Lang13.Bool( this.anchored ) ? "Engaged" : "Off" ) + " Toggle<BR>\n";
			}
			message = "AUTH";

			if ( Lang13.Bool( this.auth ) ) {
				message = "" + this.code;

				if ( this.yes_code ) {
					message = "*****";
				}
			}
			dat += new Txt( "<HR>\n>" ).item( message ).str( "<BR>\n<A href='?src=" ).Ref( this ).str( ";type=1'>1</A><A href='?src=" ).Ref( this ).str( ";type=2'>2</A><A href='?src=" ).Ref( this ).str( ";type=3'>3</A><BR>\n<A href='?src=" ).Ref( this ).str( ";type=4'>4</A><A href='?src=" ).Ref( this ).str( ";type=5'>5</A><A href='?src=" ).Ref( this ).str( ";type=6'>6</A><BR>\n<A href='?src=" ).Ref( this ).str( ";type=7'>7</A><A href='?src=" ).Ref( this ).str( ";type=8'>8</A><A href='?src=" ).Ref( this ).str( ";type=9'>9</A><BR>\n<A href='?src=" ).Ref( this ).str( ";type=R'>R</A><A href='?src=" ).Ref( this ).str( ";type=0'>0</A><A href='?src=" ).Ref( this ).str( ";type=E'>E</A><BR>\n</TT>" ).ToString();
			popup = new Browser( a, "nuclearbomb", this.name, 300, 400 );
			popup.set_content( dat );
			popup.open();
			return null;
		}

		// Function from file: nuclearbomb.dm
		public override dynamic attack_ai( dynamic user = null ) {
			return null;
		}

		// Function from file: nuclearbomb.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: nuclearbomb.dm
		public override int? process( dynamic seconds = null ) {
			int? volume = null;
			dynamic M = null;

			
			if ( this.timing > 0 ) {
				GlobalVars.bomb_set = true;
				this.timeleft--;

				if ( Convert.ToDouble( this.timeleft ) <= 0 ) {
					this.explode();
				} else {
					volume = ( Convert.ToDouble( this.timeleft ) <= 20 ? 30 : 5 );
					GlobalFuncs.playsound( this.loc, "sound/items/timer.ogg", volume, 0 );
				}

				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( this, 1 ) )) {
					M = _a;
					

					if ( Lang13.Bool( M.client ) && M.machine == this ) {
						this.attack_hand( M );
					}
				}
			}
			return null;
		}

		// Function from file: nuclearbomb.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			
			if ( this.deconstruction_state == 5 ) {
				
				switch ((int)( this.get_nuke_state() )) {
					case 0:
					case 1:
						this.icon_state = "nuclearbomb_base";
						this.update_icon_interior();
						this.update_icon_lights();
						break;
					case 2:
						this.overlays.Cut();
						this.icon_state = "nuclearbomb_timing";
						break;
					case 3:
						this.overlays.Cut();
						this.icon_state = "nuclearbomb_exploding";
						break;
				}
			} else {
				this.icon_state = "nuclearbomb_base";
				this.update_icon_interior();
				this.update_icon_lights();
			}
			return false;
		}

		// Function from file: nuclearbomb.dm
		public void explode(  ) {
			dynamic M = null;
			int off_station = 0;
			dynamic bomb_location = null;
			Obj_DockingPort_Mobile Shuttle = null;

			
			if ( this.safety ) {
				this.timing = 0;
				return;
			}
			this.timing = -1;
			this.yes_code = false;
			this.safety = true;
			this.update_icon();

			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list )) {
				M = _a;
				
				M.WriteMsg( "sound/machines/Alarm.ogg" );
			}

			if ( GlobalVars.ticker != null && Lang13.Bool( GlobalVars.ticker.mode ) ) {
				GlobalVars.ticker.mode.explosion_in_progress = true;
			}
			Task13.Sleep( 100 );

			if ( !( this.core != null ) ) {
				GlobalVars.ticker.station_explosion_cinematic( 3, "no_core" );
				GlobalVars.ticker.mode.explosion_in_progress = false;
				return;
			}
			GlobalVars.enter_allowed = false;
			off_station = 0;
			bomb_location = GlobalFuncs.get_turf( this );

			if ( Lang13.Bool( bomb_location ) && Lang13.Bool( bomb_location.z ) == true ) {
				
				if ( Convert.ToDouble( bomb_location.x ) < 48 || Convert.ToDouble( bomb_location.x ) > 208 || Convert.ToDouble( bomb_location.y ) < 48 || Convert.ToDouble( bomb_location.y ) > 208 ) {
					off_station = 1;
				}
			} else {
				off_station = 2;
			}

			if ( Lang13.Bool( GlobalVars.ticker.mode ) && GlobalVars.ticker.mode.name == "nuclear emergency" ) {
				Shuttle = GlobalVars.SSshuttle.getShuttle( "syndicate" );
				GlobalVars.ticker.mode.syndies_didnt_escape = ( Shuttle != null && Shuttle.z == 2 ? false : true );
				GlobalVars.ticker.mode.nuke_off_station = off_station;
			}
			GlobalVars.ticker.station_explosion_cinematic( off_station, null );

			if ( Lang13.Bool( GlobalVars.ticker.mode ) ) {
				GlobalVars.ticker.mode.explosion_in_progress = false;

				if ( GlobalVars.ticker.mode.name == "nuclear emergency" ) {
					GlobalVars.ticker.mode.nukes_left--;
				} else {
					Game13.WriteMsg( "<B>The station was destoyed by the nuclear blast!</B>" );
				}
				GlobalVars.ticker.mode.station_was_nuked = off_station < 2;

				if ( !((GameMode)GlobalVars.ticker.mode).check_finished() ) {
					Task13.Schedule( 0, (Task13.Closure)(() => {
						Game13.Reboot( "Station destroyed by Nuclear Device.", "end_error", "nuke - unhandled ending" );
						return;
					}));
					return;
				}
			}
			return;
		}

		// Function from file: nuclearbomb.dm
		public virtual void set_active(  ) {
			
			if ( this.safety ) {
				Task13.User.WriteMsg( "<span class='danger'>The safety is still on.</span>" );
				return;
			}
			this.timing = !( this.timing != 0 ) ?1:0;
			this.previous_level = GlobalFuncs.get_security_level();

			if ( this.timing != 0 ) {
				GlobalVars.bomb_set = true;
				GlobalFuncs.set_security_level( "delta" );
			} else {
				GlobalVars.bomb_set = false;
				GlobalFuncs.set_security_level( this.previous_level );
			}
			this.update_icon();
			return;
		}

		// Function from file: nuclearbomb.dm
		public virtual void set_safety(  ) {
			this.safety = !this.safety;

			if ( this.safety ) {
				this.timing = 0;
				GlobalVars.bomb_set = false;
				GlobalFuncs.set_security_level( this.previous_level );
			}
			this.update_icon();
			return;
		}

		// Function from file: nuclearbomb.dm
		public virtual void set_anchor(  ) {
			
			if ( !this.isinspace() ) {
				this.anchored = !Lang13.Bool( this.anchored );
			} else {
				Task13.User.WriteMsg( "<span class='warning'>There is nothing to anchor to!</span>" );
			}
			return;
		}

		// Function from file: nuclearbomb.dm
		public void update_icon_lights(  ) {
			this.overlays.Remove( this.lights );

			switch ((int)( this.get_nuke_state() )) {
				case 0:
					this.lights = null;
					break;
				case 1:
					this.lights = new Image( this.icon, "lights-safety" );
					break;
				case 2:
					this.lights = new Image( this.icon, "lights-timing" );
					break;
				case 3:
					this.lights = new Image( this.icon, "lights-exploding" );
					break;
			}
			this.overlays.Add( this.lights );
			return;
		}

		// Function from file: nuclearbomb.dm
		public void update_icon_interior(  ) {
			this.overlays.Remove( this.interior );

			switch ((int)( this.deconstruction_state )) {
				case 4:
					this.interior = new Image( this.icon, "panel-unscrewed" );
					break;
				case 3:
					this.interior = new Image( this.icon, "panel-removed" );
					break;
				case 2:
					this.interior = new Image( this.icon, "plate-welded" );
					break;
				case 1:
					this.interior = new Image( this.icon, "plate-removed" );
					break;
				case 0:
					this.interior = new Image( this.icon, "core-removed" );
					break;
				case 5:
					this.interior = null;
					break;
			}
			this.overlays.Add( this.interior );
			return;
		}

		// Function from file: nuclearbomb.dm
		public int get_nuke_state(  ) {
			
			if ( this.timing < 0 ) {
				return 3;
			}

			if ( this.timing > 0 ) {
				return 2;
			}

			if ( this.safety ) {
				return 0;
			} else {
				return 1;
			}
		}

		// Function from file: nuclearbomb.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic welder = null;
			dynamic core_box = null;
			dynamic M = null;

			
			if ( A is Obj_Item_Weapon_Disk_Nuclear ) {
				
				if ( !Lang13.Bool( user.drop_item() ) ) {
					return null;
				}
				A.loc = this;
				this.auth = A;
				this.add_fingerprint( user );
				return null;
			}

			switch ((int)( this.deconstruction_state )) {
				case 5:
					
					if ( A is Obj_Item_Weapon_Screwdriver_Nuke ) {
						GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 100, 1 );
						user.WriteMsg( "<span class='notice'>You start removing " + this + "'s front panel's screws...</span>" );

						if ( GlobalFuncs.do_after( user, 60 / A.toolspeed, null, this ) ) {
							this.deconstruction_state = 4;
							user.WriteMsg( "<span class='notice'>You remove the screws from " + this + "'s front panel.</span>" );
							this.update_icon();
						}
						return null;
					}
					break;
				case 4:
					
					if ( A is Obj_Item_Weapon_Crowbar ) {
						user.WriteMsg( "<span class='notice'>You start removing " + this + "'s front panel...</span>" );
						GlobalFuncs.playsound( this.loc, "sound/items/Crowbar.ogg", 100, 1 );

						if ( GlobalFuncs.do_after( user, 30 / A.toolspeed, null, this ) ) {
							user.WriteMsg( "<span class='notice'>You remove " + this + "'s front panel.</span>" );
							this.deconstruction_state = 3;
							this.update_icon();
						}
						return null;
					}
					break;
				case 3:
					
					if ( A is Obj_Item_Weapon_Weldingtool ) {
						welder = A;
						GlobalFuncs.playsound( this.loc, "sound/items/welder.ogg", 100, 1 );
						user.WriteMsg( "<span class='notice'>You start cutting " + this + "'s inner plate...</span>" );

						if ( ((Obj_Item_Weapon_Weldingtool)welder).remove_fuel( 1, user ) ) {
							
							if ( GlobalFuncs.do_after( user, 80 / A.toolspeed, null, this ) ) {
								user.WriteMsg( "<span class='notice'>You cut " + this + "'s inner plate.</span>" );
								this.deconstruction_state = 2;
								this.update_icon();
							}
						}
						return null;
					}
					break;
				case 2:
					
					if ( A is Obj_Item_Weapon_Crowbar ) {
						user.WriteMsg( "<span class='notice'>You start prying off " + this + "'s inner plate...</span>" );
						GlobalFuncs.playsound( this.loc, "sound/items/Crowbar.ogg", 100, 1 );

						if ( GlobalFuncs.do_after( user, 50 / A.toolspeed, null, this ) ) {
							user.WriteMsg( "<span class='notice'>You pry off " + this + "'s inner plate. You can see the core's green glow!</span>" );
							this.deconstruction_state = 1;
							this.update_icon();
							GlobalVars.SSobj.processing.Add( this.core );
						}
					}
					break;
				case 1:
					
					if ( A is Obj_Item_NukeCoreContainer ) {
						core_box = A;
						user.WriteMsg( "<span class='notice'>You start loading the plutonium core into " + core_box + "...</span>" );

						if ( GlobalFuncs.do_after( user, 50, null, this ) ) {
							
							if ( Lang13.Bool( core_box.load( this.core, user ) ) ) {
								user.WriteMsg( "<span class='notice'>You load the plutonium core into " + core_box + ".</span>" );
								this.deconstruction_state = 0;
								this.update_icon();
								this.core = null;
							} else {
								user.WriteMsg( "<span class='warning'>You fail to load the plutonium core into " + core_box + ". " + core_box + " has already been used!</span>" );
							}
						}
						return null;
					}

					if ( A is Obj_Item_Stack_Sheet_Metal ) {
						M = A;

						if ( Convert.ToDouble( M.amount ) >= 20 ) {
							user.WriteMsg( "<span class='notice'>You begin repairing " + this + "'s inner metal plate...</span>" );

							if ( GlobalFuncs.do_after( user, 100, null, this ) ) {
								
								if ( Lang13.Bool( M.use( 20 ) ) ) {
									user.WriteMsg( "<span class='notice'>You repair " + this + "'s inner metal plate. The radiation is contained.</span>" );
									this.deconstruction_state = 3;
									GlobalVars.SSobj.processing.Remove( this.core );
									this.update_icon();
								} else {
									user.WriteMsg( "<span class='warning'>You need more metal to do that!</span>" );
								}
							}
						} else {
							user.WriteMsg( "<span class='warning'>You need more metal to do that!</span>" );
						}
						return null;
					}
					break;
				default:
					base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
					break;
			}
			return null;
		}

		// Function from file: swarmer.dm
		public override void swarmer_act( Mob_Living_SimpleAnimal_Hostile_Swarmer S = null ) {
			S.WriteMsg( "<span class='warning'>This device's destruction would result in the extermination of everything in the area. Aborting.</span>" );
			return;
		}

	}

}