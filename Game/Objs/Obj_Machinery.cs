// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery : Obj {

		public int stat = 0;
		public double? emagged = 0;
		public int use_power = 1;
		public double idle_power_usage = 0;
		public dynamic active_power_usage = 0;
		public int? power_channel = 1;
		public ByTable component_parts = null;
		public double uid = 0;
		public bool gl_uid = true;
		public int? panel_open = 0;
		public int? state_open = 0;
		public dynamic occupant = null;
		public Type unsecuring_tool = typeof(Obj_Item_Weapon_Wrench);
		public bool interact_open = false;
		public bool interact_offline = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.verb_yell = "blares";
			this.pressure_resistance = 10;
			this.icon = "icons/obj/stationobjs.dmi";
		}

		// Function from file: machinery.dm
		public Obj_Machinery ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			GlobalVars.machines.Add( this );
			GlobalVars.SSmachine.processing.Add( this );
			this.power_change();
			return;
		}

		// Function from file: requests_console.dm
		public override string say_quote( dynamic input = null, dynamic spans = null ) {
			string ending = null;

			ending = String13.SubStr( input, Lang13.Length( input ) - 2, 0 );

			if ( ending == "!!!" ) {
				return "blares, \"" + GlobalFuncs.attach_spans( input, spans ) + "\"";
			}
			return base.say_quote( (object)(input), (object)(spans) );
		}

		// Function from file: machinery.dm
		public override void tesla_act( double power = 0 ) {
			base.tesla_act( power );

			if ( Rand13.PercentChance( 85 ) ) {
				this.emp_act( 2 );
			} else if ( Rand13.PercentChance( 50 ) ) {
				this.ex_act( 3 );
			} else if ( Rand13.PercentChance( 90 ) ) {
				this.ex_act( 2 );
			} else {
				this.ex_act( 1 );
			}
			return;
		}

		// Function from file: machinery.dm
		public override bool allow_drop(  ) {
			return false;
		}

		// Function from file: machinery.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );

			if ( user.research_scanner && this.component_parts != null ) {
				this.display_parts( user );
			}
			return 0;
		}

		// Function from file: machinery.dm
		public override void CheckParts( Game_Data holder = null ) {
			this.RefreshParts();
			return;
		}

		// Function from file: machinery.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			b = b ?? true;
			c = c ?? true;

			dynamic H = null;

			
			if ( Lang13.Bool( base.attack_hand( (object)(a), b, c ) ) ) {
				return 1;
			}

			if ( ( Lang13.Bool( a.lying ) || Lang13.Bool( a.stat ) ) && !Lang13.Bool( GlobalFuncs.IsAdminGhost( a ) ) ) {
				return 1;
			}

			if ( !((Mob)a).IsAdvancedToolUser() && !Lang13.Bool( GlobalFuncs.IsAdminGhost( a ) ) ) {
				Task13.User.WriteMsg( "<span class='warning'>You don't have the dexterity to do this!</span>" );
				return 1;
			}

			if ( a is Mob_Living_Carbon_Human ) {
				H = a;

				if ( Rand13.PercentChance( ((Mob_Living)H).getBrainLoss() ) ) {
					a.WriteMsg( "<span class='warning'>You momentarily forget how to use " + this + "!</span>" );
					return 1;
				}
			}

			if ( !Lang13.Bool( this.is_interactable() ) ) {
				a.WriteMsg( new Txt( "<span class='danger'>" ).The( this ).item().str( " seems offline.</span>" ).ToString() );
				return 1;
			}

			if ( c == true ) {
				((Mob)a).set_machine( this );
			}
			this.interact( a );
			this.add_fingerprint( a );
			return 0;
		}

		// Function from file: machinery.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: machinery.dm
		public override dynamic attack_ai( dynamic user = null ) {
			dynamic R = null;

			
			if ( user is Mob_Living_Silicon_Robot ) {
				R = user;

				if ( Lang13.Bool( R.client ) && R.client.eye == R && !R.low_power_mode ) {
					return this.attack_hand( user );
				}
			} else {
				return this.attack_hand( user );
			}
			return null;
		}

		// Function from file: machinery.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			base.Topic( href, href_list, (object)(hsrc) );

			if ( !Lang13.Bool( this.is_interactable() ) ) {
				return 1;
			}

			if ( !Task13.User.canUseTopic( this ) ) {
				return 1;
			}
			this.add_fingerprint( Task13.User );
			return 0;
		}

		// Function from file: machinery.dm
		public override int? ui_act( string action = null, ByTable _params = null, Tgui ui = null, UiState state = null ) {
			this.add_fingerprint( Task13.User );
			return base.ui_act( action, _params, ui, state );
		}

		// Function from file: machinery.dm
		public override int ui_status( dynamic user = null, UiState state = null ) {
			
			if ( Lang13.Bool( this.is_interactable() ) ) {
				return base.ui_status( (object)(user), state );
			}
			return -1;
		}

		// Function from file: machinery.dm
		public override dynamic interact( dynamic user = null, bool? flag1 = null ) {
			this.add_fingerprint( user );
			this.ui_interact( user );
			return null;
		}

		// Function from file: machinery.dm
		public override bool blob_act( dynamic severity = null ) {
			
			if ( !this.density ) {
				GlobalFuncs.qdel( this );
			}

			if ( Rand13.PercentChance( 75 ) ) {
				GlobalFuncs.qdel( this );
			}
			return false;
		}

		// Function from file: machinery.dm
		public override double emp_act( int severity = 0 ) {
			
			if ( this.use_power != 0 && this.stat == 0 ) {
				this.f_use_power( 7500 / severity );
				GlobalFuncs.PoolOrNew( typeof(Obj_Effect_Overlay_Temp_Emp), this.loc );
			}
			base.emp_act( severity );
			return 0;
		}

		// Function from file: machinery.dm
		public override int? process( dynamic seconds = null ) {
			return 26;
		}

		// Function from file: power.dm
		public virtual void power_change(  ) {
			
			if ( Lang13.Bool( this.powered( this.power_channel ) ) ) {
				this.stat &= 65533;
			} else {
				this.stat |= 2;
			}
			return;
		}

		// Function from file: power.dm
		public void removeStaticPower( dynamic value = null, int powerchannel = 0 ) {
			this.addStaticPower( -value, powerchannel );
			return;
		}

		// Function from file: power.dm
		public void addStaticPower( dynamic value = null, int powerchannel = 0 ) {
			dynamic A = null;

			A = GlobalFuncs.get_area( this );

			if ( !Lang13.Bool( A ) || !Lang13.Bool( A.master ) ) {
				return;
			}
			A.master.addStaticPower( value, powerchannel );
			return;
		}

		// Function from file: power.dm
		[VerbInfo( name: "use power" )]
		public void f_use_power( dynamic amount = null, int? chan = null ) {
			chan = chan ?? -1;

			dynamic A = null;

			A = GlobalFuncs.get_area( this );

			if ( !Lang13.Bool( A ) || !( A is Zone ) || !Lang13.Bool( A.master ) ) {
				return;
			}

			if ( chan == -1 ) {
				chan = this.power_channel;
			}
			A.master.use_power( amount, chan );
			return;
		}

		// Function from file: power.dm
		public dynamic powered( int? chan = null ) {
			chan = chan ?? -1;

			Ent_Static A = null;

			
			if ( !( this.loc != null ) ) {
				return 0;
			}

			if ( !( this.use_power != 0 ) ) {
				return 1;
			}
			A = this.loc.loc;

			if ( !( A != null ) || !( A is Zone ) || !Lang13.Bool( ((dynamic)A).master ) ) {
				return 0;
			}

			if ( chan == -1 ) {
				chan = this.power_channel;
			}
			return ((dynamic)A).master.powered( chan );
		}

		// Function from file: machinery.dm
		public virtual bool can_be_overridden(  ) {
			bool _default = false;

			_default = true;
			return _default;
		}

		// Function from file: machinery.dm
		public void hiOnHide( dynamic hclient = null ) {
			
			if ( Lang13.Bool( hclient.client.mob ) && hclient.client.mob.machine == this ) {
				((Mob)hclient.client.mob).unset_machine();
			}
			return;
		}

		// Function from file: machinery.dm
		public int? hiIsValidClient( dynamic hclient = null, dynamic hi = null ) {
			
			if ( Lang13.Bool( hclient.client.mob ) && ( Lang13.Bool( hclient.client.mob.stat ) == false || Lang13.Bool( GlobalFuncs.IsAdminGhost( hclient.client.mob ) ) ) ) {
				
				if ( hclient.client.mob is Mob_Living_Silicon_Ai || Lang13.Bool( GlobalFuncs.IsAdminGhost( hclient.client.mob ) ) ) {
					return GlobalVars.TRUE;
				} else {
					return hclient.client.mob.machine == this && this.Adjacent( hclient.client.mob ) ?1:0;
				}
			} else {
				return GlobalVars.FALSE;
			}
			return null;
		}

		// Function from file: machinery.dm
		public virtual void deconstruction(  ) {
			return;
		}

		// Function from file: machinery.dm
		public virtual void construction( dynamic pipe_type = null, dynamic obj_color = null ) {
			return;
		}

		// Function from file: machinery.dm
		public void display_parts( dynamic user = null ) {
			Obj_Item C = null;

			user.WriteMsg( "<span class='notice'>Following parts detected in the machine:</span>" );

			foreach (dynamic _a in Lang13.Enumerate( this.component_parts, typeof(Obj_Item) )) {
				C = _a;
				
				user.WriteMsg( new Txt( "<span class='notice'>" ).icon( C ).str( " " ).item( C.name ).str( "</span>" ).ToString() );
			}
			return;
		}

		// Function from file: machinery.dm
		public bool exchange_parts( dynamic user = null, dynamic W = null ) {
			bool shouldplaysound = false;
			dynamic CB = null;
			dynamic P = null;
			Obj_Item_Weapon_StockParts A = null;
			dynamic D = null;
			Obj_Item_Weapon_StockParts B = null;

			
			if ( Lang13.Bool( this.flags & 128 ) ) {
				return false;
			}
			shouldplaysound = false;

			if ( W is Obj_Item_Weapon_Storage_PartReplacer && this.component_parts != null ) {
				
				if ( Lang13.Bool( this.panel_open ) || W.works_from_distance ) {
					CB = Lang13.FindIn( typeof(Obj_Item_Weapon_Circuitboard), this.component_parts );

					if ( W.works_from_distance ) {
						this.display_parts( user );
					}

					foreach (dynamic _c in Lang13.Enumerate( this.component_parts, typeof(Obj_Item_Weapon_StockParts) )) {
						A = _c;
						

						foreach (dynamic _a in Lang13.Enumerate( CB.req_components )) {
							D = _a;
							

							if ( Lang13.Bool( ((dynamic)A.type).IsSubclassOf( D ) ) ) {
								P = D;
								break;
							}
						}

						foreach (dynamic _b in Lang13.Enumerate( W.contents, typeof(Obj_Item_Weapon_StockParts) )) {
							B = _b;
							

							if ( Lang13.Bool( P.IsInstanceOfType( B ) ) && Lang13.Bool( P.IsInstanceOfType( A ) ) ) {
								
								if ( Convert.ToDouble( B.rating ) > Convert.ToDouble( A.rating ) ) {
									((Obj_Item_Weapon_Storage)W).remove_from_storage( B, this );
									((Obj_Item_Weapon_Storage)W).handle_item_insertion( A, true );
									this.component_parts.Remove( A );
									this.component_parts.Add( B );
									B.loc = null;
									user.WriteMsg( "<span class='notice'>" + A.name + " replaced with " + B.name + ".</span>" );
									shouldplaysound = true;
									break;
								}
							}
						}
					}
					this.RefreshParts();
				} else {
					this.display_parts( user );
				}

				if ( shouldplaysound ) {
					((Obj_Item_Weapon_Storage_PartReplacer)W).play_rped_sound();
				}
				return true;
			}
			return false;
		}

		// Function from file: machinery.dm
		public virtual bool default_change_direction_wrench( dynamic user = null, dynamic W = null ) {
			
			if ( Lang13.Bool( this.panel_open ) && W is Obj_Item_Weapon_Wrench ) {
				GlobalFuncs.playsound( this.loc, "sound/items/ratchet.ogg", 50, 1 );
				this.dir = Num13.Rotate( this.dir, -90 );
				user.WriteMsg( "<span class='notice'>You rotate " + this + ".</span>" );
				return true;
			}
			return false;
		}

		// Function from file: machinery.dm
		public bool default_deconstruction_screwdriver( dynamic user = null, dynamic icon_state_open = null, dynamic icon_state_closed = null, dynamic S = null ) {
			
			if ( S is Obj_Item_Weapon_Screwdriver && !Lang13.Bool( this.flags & 128 ) ) {
				GlobalFuncs.playsound( this.loc, "sound/items/Screwdriver.ogg", 50, 1 );

				if ( !Lang13.Bool( this.panel_open ) ) {
					this.panel_open = 1;
					this.icon_state = icon_state_open;
					user.WriteMsg( "<span class='notice'>You open the maintenance hatch of " + this + ".</span>" );
				} else {
					this.panel_open = 0;
					this.icon_state = icon_state_closed;
					user.WriteMsg( "<span class='notice'>You close the maintenance hatch of " + this + ".</span>" );
				}
				return true;
			}
			return false;
		}

		// Function from file: machinery.dm
		public virtual bool default_deconstruction_crowbar( dynamic C = null, bool? ignore_panel = null ) {
			ignore_panel = ignore_panel ?? false;

			bool _default = false;

			Obj_Machinery_ConstructableFrame_MachineFrame M = null;
			Obj_Item I = null;

			_default = C is Obj_Item_Weapon_Crowbar && ( Lang13.Bool( this.panel_open ) || ignore_panel == true ) && !Lang13.Bool( this.flags & 128 );

			if ( _default ) {
				this.deconstruction();
				GlobalFuncs.playsound( this.loc, "sound/items/Crowbar.ogg", 50, 1 );
				M = new Obj_Machinery_ConstructableFrame_MachineFrame( this.loc );
				this.transfer_fingerprints_to( M );
				M.state = 2;
				M.icon_state = "box_1";

				foreach (dynamic _a in Lang13.Enumerate( this.component_parts, typeof(Obj_Item) )) {
					I = _a;
					

					if ( I.reliability != 100 && this.crit_fail ) {
						I.crit_fail = true;
					}
					I.loc = this.loc;
				}
				GlobalFuncs.qdel( this );
			}
			return _default;
		}

		// Function from file: machinery.dm
		public bool default_pry_open( dynamic C = null ) {
			bool _default = false;

			_default = !( Lang13.Bool( this.state_open ) || Lang13.Bool( this.panel_open ) || this.is_operational() || Lang13.Bool( this.flags & 128 ) ) && C is Obj_Item_Weapon_Crowbar;

			if ( _default ) {
				GlobalFuncs.playsound( this.loc, "sound/items/Crowbar.ogg", 50, 1 );
				this.visible_message( new Txt( "<span class='notice'>" ).item( Task13.User ).str( " pry open " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You pry open " ).the( this ).item().str( ".</span>" ).ToString() );
				this.open_machine();
				return true;
			}
			return _default;
		}

		// Function from file: machinery.dm
		public void assign_uid(  ) {
			this.uid = GlobalVars.gl_uid;
			GlobalVars.gl_uid++;
			return;
		}

		// Function from file: machinery.dm
		public virtual void RefreshParts(  ) {
			return;
		}

		// Function from file: machinery.dm
		public int? is_interactable(  ) {
			
			if ( ( this.stat & 3 ) != 0 && !this.interact_offline ) {
				return GlobalVars.FALSE;
			}

			if ( Lang13.Bool( this.panel_open ) && !this.interact_open ) {
				return GlobalVars.FALSE;
			}
			return GlobalVars.TRUE;
		}

		// Function from file: machinery.dm
		public bool is_operational(  ) {
			return !( ( this.stat & 11 ) != 0 );
		}

		// Function from file: machinery.dm
		public virtual bool auto_use_power(  ) {
			
			if ( !Lang13.Bool( this.powered( this.power_channel ) ) ) {
				return false;
			}

			if ( this.use_power == 1 ) {
				this.f_use_power( this.idle_power_usage, this.power_channel );
			} else if ( this.use_power >= 2 ) {
				this.f_use_power( this.active_power_usage, this.power_channel );
			}
			return true;
		}

		// Function from file: machinery.dm
		public virtual dynamic close_machine( Ent_Static target = null ) {
			Mob_Living_Carbon C = null;

			this.state_open = 0;
			this.density = true;

			if ( !( target != null ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Mob_Living_Carbon) )) {
					C = _a;
					

					if ( C.buckled != null || Lang13.Bool( C.buckled_mob ) ) {
						continue;
					} else {
						target = C;
					}
				}
			}

			if ( target != null && !Lang13.Bool( ((dynamic)target).buckled ) && !Lang13.Bool( ((dynamic)target).buckled_mob ) ) {
				this.occupant = target;
				((dynamic)target).forceMove( this );
			}
			this.updateUsrDialog();
			this.update_icon();
			return null;
		}

		// Function from file: machinery.dm
		public dynamic dropContents(  ) {
			dynamic _default = null;

			dynamic T = null;
			Mob_Living L = null;

			T = GlobalFuncs.get_turf( this );

			foreach (dynamic _a in Lang13.Enumerate( this, typeof(Mob_Living) )) {
				L = _a;
				
				L.loc = T;
				L.reset_perspective( null );
				L.update_canmove();
				_default += L;
			}
			T.contents.Add( this.contents );
			this.occupant = null;
			return _default;
		}

		// Function from file: machinery.dm
		public virtual bool open_machine( int? dump = null ) {
			this.state_open = 1;
			this.density = false;
			this.dropContents();
			this.update_icon();
			this.updateUsrDialog();
			return false;
		}

		// Function from file: machinery.dm
		public virtual int? process_atmos(  ) {
			return 26;
		}

		// Function from file: machinery.dm
		public virtual void locate_machinery(  ) {
			return;
		}

		// Function from file: machinery.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			((Mob)user).changeNext_move( 8 );
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

		// Function from file: machinery.dm
		public override dynamic Destroy(  ) {
			GlobalVars.machines.Remove( this );
			GlobalVars.SSmachine.processing.Remove( this );
			this.dropContents();
			return base.Destroy();
		}

		// Function from file: swarmer.dm
		public override void swarmer_act( Mob_Living_SimpleAnimal_Hostile_Swarmer S = null ) {
			S.DismantleMachine( this );
			return;
		}

	}

}