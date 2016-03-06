// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_PortaTurret : Obj_Machinery {

		public string base_icon_state = "grey";
		public string active_state = "Taser";
		public string off_state = "Off";
		public bool emp_vunerable = true;
		public int scan_range = 7;
		public Obj v_base = null;
		public string lasercolor = "";
		public bool raised = false;
		public bool raising = false;
		public double health = 80;
		public bool locked = true;
		public bool controllock = false;
		public dynamic installation = typeof(Obj_Item_Weapon_Gun_Energy_Gun_Turret);
		public bool gun_charge = false;
		public Type projectile = null;
		public Type eprojectile = null;
		public int reqpower = 500;
		public bool egun = false;
		public bool always_up = false;
		public bool has_cover = true;
		public Obj_Machinery_PortaTurretCover cover = null;
		public int last_fired = 0;
		public int shot_delay = 15;
		public bool check_records = true;
		public bool criminals = true;
		public bool auth_weapons = false;
		public bool stun_all = false;
		public bool check_anomalies = true;
		public bool attacked = false;
		public bool on = true;
		public bool disabled = false;
		public string shot_sound = null;
		public string eshot_sound = null;
		public dynamic faction = "neutral";
		public EffectSystem_SparkSpread spark_system = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.invisibility = 60;
			this.anchored = 1;
			this.idle_power_usage = 50;
			this.active_power_usage = 300;
			this.req_access = new ByTable(new object [] { 1 });
			this.icon = "icons/obj/turrets.dmi";
			this.icon_state = "grey_target_prism";
		}

		// Function from file: portable_turret.dm
		public Obj_Machinery_PortaTurret ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( !( this.v_base != null ) ) {
				this.v_base = this;
			}
			this.icon_state = "" + this.base_icon_state + this.off_state;
			this.spark_system = new EffectSystem_SparkSpread();
			this.spark_system.set_up( 5, 0, this );
			this.spark_system.attach( this );

			if ( this.has_cover ) {
				this.cover = new Obj_Machinery_PortaTurretCover( this.loc );
				this.cover.Parent_Turret = this;
			}
			this.setup();

			if ( !this.has_cover ) {
				this.popUp();
			}
			return;
		}

		// Function from file: portable_turret.dm
		public override int? process( dynamic seconds = null ) {
			ByTable targets = null;

			
			if ( this.cover == null && Lang13.Bool( this.anchored ) ) {
				
				if ( ( this.stat & 1 ) != 0 ) {
					GlobalFuncs.qdel( this.cover );
				} else if ( this.has_cover ) {
					this.cover = new Obj_Machinery_PortaTurretCover( this.loc );
					this.cover.Parent_Turret = this;
				}
			}

			if ( ( this.stat & 3 ) != 0 ) {
				
				if ( !this.always_up ) {
					this.popDown();
				}
				return null;
			}

			if ( !this.on ) {
				
				if ( !this.always_up ) {
					this.popDown();
				}
				return null;
			}
			targets = this.calculate_targets();

			if ( !this.tryToShootAt( targets ) ) {
				
				if ( !this.always_up ) {
					this.popDown();
				}
			}
			return null;
		}

		// Function from file: portable_turret.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			
			if ( ( severity ??0) >= 3 ) {
				this.die();
			} else {
				GlobalFuncs.qdel( this );
			}
			return false;
		}

		// Function from file: portable_turret.dm
		public override double emp_act( int severity = 0 ) {
			
			if ( this.on && this.emp_vunerable ) {
				this.check_records = Lang13.Bool( Rand13.Pick(new object [] { 0, 1 }) );
				this.criminals = Lang13.Bool( Rand13.Pick(new object [] { 0, 1 }) );
				this.auth_weapons = Lang13.Bool( Rand13.Pick(new object [] { 0, 1 }) );
				this.stun_all = Lang13.Bool( Rand13.Pick(new object [] { 0, 0, 0, 0, 1 }) );
				this.on = false;
				Task13.Schedule( Rand13.Int( 60, 600 ), (Task13.Closure)(() => {
					
					if ( !this.on ) {
						this.on = true;
					}
					return;
				}));
			}
			base.emp_act( severity );
			return 0;
		}

		// Function from file: portable_turret.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			bool damage_dealt = false;

			
			if ( this.on ) {
				
				if ( !this.attacked && !Lang13.Bool( this.emagged ) ) {
					this.attacked = true;
					Task13.Schedule( 0, (Task13.Closure)(() => {
						Task13.Sleep( 60 );
						this.attacked = false;
						return;
					}));
				}
			}
			damage_dealt = false;

			if ( P.damage_type == "brute" || P.damage_type == "fire" ) {
				damage_dealt = Lang13.Bool( P.damage );
			}
			base.bullet_act( (object)(P), (object)(def_zone) );

			if ( damage_dealt ) {
				
				if ( Rand13.PercentChance( 45 ) ) {
					this.spark_system.start();
				}
				this.take_damage( damage_dealt );
			}

			if ( this.lasercolor == "b" && !this.disabled ) {
				
				if ( P is Obj_Item_Projectile_Beam_Lasertag_Redtag ) {
					this.disabled = true;
					GlobalFuncs.qdel( P );
					Task13.Sleep( 100 );
					this.disabled = false;
				}
			}

			if ( this.lasercolor == "r" && !this.disabled ) {
				
				if ( P is Obj_Item_Projectile_Beam_Lasertag_Bluetag ) {
					this.disabled = true;
					GlobalFuncs.qdel( P );
					Task13.Sleep( 100 );
					this.disabled = false;
				}
			}
			return null;
		}

		// Function from file: portable_turret.dm
		public override bool emag_act( dynamic user = null ) {
			
			if ( !Lang13.Bool( this.emagged ) ) {
				user.WriteMsg( "<span class='warning'>You short out " + this + "'s threat assessment circuits.</span>" );
				this.visible_message( "" + this + " hums oddly..." );
				this.emagged = 1;
				this.active_state = "Laser";
				this.controllock = true;
				this.on = false;
				Task13.Sleep( 60 );
				this.on = true;
			}
			return false;
		}

		// Function from file: portable_turret.dm
		public override bool attack_alien( dynamic user = null ) {
			((Mob)user).changeNext_move( 8 );
			((Ent_Dynamic)user).do_attack_animation( this );

			if ( !( ( this.stat & 1 ) != 0 ) ) {
				GlobalFuncs.playsound( this.loc, "sound/weapons/slash.ogg", 25, 1, -1 );
				this.visible_message( "<span class='danger'>" + user + " has slashed at " + this + "!</span>" );
				GlobalFuncs.add_logs( user, this, "attacked" );
				this.take_damage( 15 );
			} else {
				user.WriteMsg( "ÿ That object is useless to you." );
			}
			return false;
		}

		// Function from file: portable_turret.dm
		public override bool attack_animal( Mob_Living user = null ) {
			user.changeNext_move( 8 );
			user.do_attack_animation( this );

			if ( Lang13.Bool( ((dynamic)user).melee_damage_upper ) == false || ((dynamic)user).melee_damage_type != "brute" && ((dynamic)user).melee_damage_type != "fire" ) {
				return false;
			}

			if ( !( ( this.stat & 1 ) != 0 ) ) {
				this.visible_message( "<span class='danger'>" + user + " " + ((dynamic)user).attacktext + " " + this + "!</span>" );
				GlobalFuncs.add_logs( user, this, "attacked" );
				this.take_damage( ((dynamic)user).melee_damage_upper );
			} else {
				user.WriteMsg( "<span class='danger'>That object is useless to you.</span>" );
			}
			return false;
		}

		// Function from file: portable_turret.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic Gun = null;
			dynamic M = null;

			
			if ( ( this.stat & 1 ) != 0 ) {
				
				if ( A is Obj_Item_Weapon_Crowbar ) {
					user.WriteMsg( "<span class='notice'>You begin prying the metal coverings off...</span>" );

					if ( GlobalFuncs.do_after( user, 20 / A.toolspeed, null, this ) ) {
						
						if ( Rand13.PercentChance( 70 ) ) {
							user.WriteMsg( "<span class='notice'>You remove the turret and salvage some components.</span>" );

							if ( Lang13.Bool( this.installation ) ) {
								Gun = Lang13.Call( this.installation, this.loc );
								Gun.power_supply.charge = this.gun_charge;
								Gun.update_icon();
								this.lasercolor = null;
							}

							if ( Rand13.PercentChance( 50 ) ) {
								new Obj_Item_Stack_Sheet_Metal( this.loc, Rand13.Int( 1, 4 ) );
							}

							if ( Rand13.PercentChance( 50 ) ) {
								new Obj_Item_Device_Assembly_ProxSensor( this.loc );
							}
						} else {
							user.WriteMsg( "<span class='notice'>You remove the turret but did not manage to salvage anything.</span>" );
						}
						GlobalFuncs.qdel( this );
					}
				}
			} else if ( A is Obj_Item_Weapon_Wrench && !this.on ) {
				
				if ( this.raised ) {
					return null;
				}

				if ( !Lang13.Bool( this.anchored ) && !this.isinspace() ) {
					this.anchored = 1;
					this.invisibility = 60;
					this.icon_state = "" + this.base_icon_state + this.off_state;
					user.WriteMsg( "<span class='notice'>You secure the exterior bolts on the turret.</span>" );

					if ( this.has_cover ) {
						this.cover = new Obj_Machinery_PortaTurretCover( this.loc );
						this.cover.Parent_Turret = this;
					}
				} else if ( Lang13.Bool( this.anchored ) ) {
					this.anchored = 0;
					user.WriteMsg( "<span class='notice'>You unsecure the exterior bolts on the turret.</span>" );
					this.icon_state = "turretCover";
					this.invisibility = 0;
					GlobalFuncs.qdel( this.cover );
				}
			} else if ( A is Obj_Item_Weapon_Card_Id || A is Obj_Item_Device_Pda ) {
				
				if ( this.allowed( user ) ) {
					this.locked = !this.locked;
					user.WriteMsg( "<span class='notice'>Controls are now " + ( this.locked ? "locked" : "unlocked" ) + ".</span>" );
				} else {
					user.WriteMsg( "<span class='notice'>Access denied.</span>" );
				}
			} else if ( A is Obj_Item_Device_Multitool && !this.locked ) {
				M = A;
				M.buffer = this;
				user.WriteMsg( "<span class='notice'>You add " + this + " to multitool buffer.</span>" );
			} else {
				((Mob)user).changeNext_move( 8 );
				this.take_damage( A.force * 0.5 );

				if ( Convert.ToDouble( A.force * 0.5 ) > 1 ) {
					
					if ( !this.attacked && !Lang13.Bool( this.emagged ) ) {
						this.attacked = true;
						Task13.Schedule( 0, (Task13.Closure)(() => {
							Task13.Sleep( 60 );
							this.attacked = false;
							return;
						}));
					}
				}
				base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			}
			return null;
		}

		// Function from file: portable_turret.dm
		public override void power_change(  ) {
			
			if ( !Lang13.Bool( this.anchored ) ) {
				this.icon_state = "turretCover";
				return;
			}

			if ( ( this.stat & 1 ) != 0 ) {
				this.icon_state = "" + this.base_icon_state + "Broken";
			} else if ( Lang13.Bool( this.powered() ) ) {
				
				if ( this.on ) {
					this.icon_state = "" + this.base_icon_state + this.active_state;
				} else {
					this.icon_state = "" + this.base_icon_state + this.off_state;
				}
				this.stat &= 65533;
			} else {
				Task13.Schedule( Rand13.Int( 0, 15 ), (Task13.Closure)(() => {
					this.icon_state = "" + this.base_icon_state + this.off_state;
					this.stat |= 2;
					return;
				}));
			}
			return;
		}

		// Function from file: portable_turret.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return null;
			}
			Task13.User.set_machine( this );
			this.add_fingerprint( Task13.User );

			if ( Lang13.Bool( href_list["power"] ) && !this.locked ) {
				
				if ( Lang13.Bool( this.anchored ) ) {
					this.on = !this.on;
				} else {
					Task13.User.WriteMsg( "<span class='notice'>It has to be secured first!</span>" );
				}
				this.updateUsrDialog();
				return null;
			}

			dynamic _a = href_list["operation"]; // Was a switch-case, sorry for the mess.
			if ( _a=="authweapon" ) {
				this.auth_weapons = !this.auth_weapons;
			} else if ( _a=="checkrecords" ) {
				this.check_records = !this.check_records;
			} else if ( _a=="shootcrooks" ) {
				this.criminals = !this.criminals;
			} else if ( _a=="shootall" ) {
				this.stun_all = !this.stun_all;
			} else if ( _a=="checkxenos" ) {
				this.check_anomalies = !this.check_anomalies;
			}
			this.updateUsrDialog();
			return null;
		}

		// Function from file: portable_turret.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			dynamic _default = null;

			dynamic dat = null;
			dynamic H = null;

			_default = base.attack_hand( (object)(a), b, c );

			if ( Lang13.Bool( _default ) ) {
				return _default;
			}

			if ( !Lang13.Bool( this.lasercolor ) ) {
				dat += "\n					<TT><B>Automatic Portable Turret Installation</B></TT><BR><BR>\n					Status: " + new Txt( "<A href='?src=" ).Ref( this ).str( ";power=1'>" ).item( ( this.on ? "On" : "Off" ) ).str( "</A>" ).ToString() + "<BR>\n					Behaviour controls are " + ( this.locked ? "locked" : "unlocked" );

				if ( !this.locked ) {
					dat += "<BR>\n						Check for Weapon Authorization: " + new Txt( "<A href='?src=" ).Ref( this ).str( ";operation=authweapon'>" ).item( ( this.auth_weapons ? "Yes" : "No" ) ).str( "</A>" ).ToString() + "<BR>\n						Check Security Records: " + new Txt( "<A href='?src=" ).Ref( this ).str( ";operation=checkrecords'>" ).item( ( this.check_records ? "Yes" : "No" ) ).str( "</A>" ).ToString() + "<BR>\n						Neutralize Identified Criminals: " + new Txt( "<A href='?src=" ).Ref( this ).str( ";operation=shootcrooks'>" ).item( ( this.criminals ? "Yes" : "No" ) ).str( "</A>" ).ToString() + "<BR>\n						Neutralize All Non-Security and Non-Command Personnel: " + new Txt( "<A href='?src=" ).Ref( this ).str( ";operation=shootall'>" ).item( ( this.stun_all ? "Yes" : "No" ) ).str( "</A>" ).ToString() + "<BR>\n						Neutralize All Unidentified Life Signs: " + new Txt( "<A href='?src=" ).Ref( this ).str( ";operation=checkxenos'>" ).item( ( this.check_anomalies ? "Yes" : "No" ) ).str( "</A>" ).ToString() + "<BR>";
				}
			} else {
				
				if ( a is Mob_Living_Carbon_Human ) {
					H = a;

					if ( this.lasercolor == "b" && H.wear_suit is Obj_Item_Clothing_Suit_Redtag ) {
						return _default;
					}

					if ( this.lasercolor == "r" && H.wear_suit is Obj_Item_Clothing_Suit_Bluetag ) {
						return _default;
					}
				}
				dat += "\n					<TT><B>Automatic Portable Turret Installation</B></TT><BR><BR>\n					Status: " + new Txt( "<A href='?src=" ).Ref( this ).str( ";power=1'>" ).item( ( this.on ? "On" : "Off" ) ).str( "</A>" ).ToString() + "<BR>";
			}
			Interface13.Browse( a, "<HEAD><TITLE>Automatic Portable Turret Installation</TITLE></HEAD>" + dat, "window=autosec" );
			GlobalFuncs.onclose( a, "autosec" );
			return _default;
		}

		// Function from file: portable_turret.dm
		public override dynamic attack_ai( dynamic user = null ) {
			return this.attack_hand( user );
		}

		// Function from file: portable_turret.dm
		public override dynamic Destroy(  ) {
			GlobalFuncs.qdel( this.cover );
			this.cover = null;
			return base.Destroy();
		}

		// Function from file: portable_turret.dm
		public void setState( bool on = false, bool emagged = false ) {
			
			if ( this.controllock ) {
				return;
			}
			this.on = on;
			this.emagged = emagged ?1:0;

			if ( emagged ) {
				this.active_state = "Laser";
			}
			this.power_change();
			return;
		}

		// Function from file: portable_turret.dm
		public virtual dynamic shootAt( dynamic target = null ) {
			dynamic T = null;
			dynamic U = null;
			dynamic A = null;

			
			if ( !this.raised ) {
				return null;
			}

			if ( !Lang13.Bool( this.emagged ) ) {
				
				if ( this.last_fired + this.shot_delay > Game13.time ) {
					return null;
				}
				this.last_fired = Game13.time;
			}
			T = GlobalFuncs.get_turf( this );
			U = GlobalFuncs.get_turf( target );

			if ( !( T is Tile ) || !( U is Tile ) ) {
				return null;
			}
			this.icon_state = "" + this.base_icon_state + this.active_state;

			if ( !Lang13.Bool( this.emagged ) ) {
				this.f_use_power( this.reqpower );
				A = Lang13.Call( this.projectile, T );
				GlobalFuncs.playsound( this.loc, this.shot_sound, 75, 1 );
			} else {
				this.f_use_power( this.reqpower * 2 );
				A = Lang13.Call( this.eprojectile, T );
				GlobalFuncs.playsound( this.loc, this.eshot_sound, 75, 1 );
			}
			A.original = target;
			A.current = T;
			A.yo = Convert.ToDouble( U.y - T.y );
			A.xo = Convert.ToDouble( U.x - T.x );
			A.fire();
			return A;
		}

		// Function from file: portable_turret.dm
		public bool target( dynamic target = null ) {
			
			if ( this.disabled ) {
				return false;
			}

			if ( Lang13.Bool( target ) ) {
				Task13.Schedule( 0, (Task13.Closure)(() => {
					this.popUp();
					return;
				}));
				this.dir = Map13.GetDistance( this.v_base, target );
				Task13.Schedule( 0, (Task13.Closure)(() => {
					this.shootAt( target );
					return;
				}));
				return true;
			}
			return false;
		}

		// Function from file: portable_turret.dm
		public bool in_faction( dynamic target = null ) {
			
			if ( !Lang13.Bool( target.faction.Contains( this.faction ) ) ) {
				return false;
			}
			return true;
		}

		// Function from file: portable_turret.dm
		public virtual int assess_perp( dynamic perp = null ) {
			int threatcount = 0;
			dynamic perpname = null;
			Data_Record R = null;

			threatcount = 0;

			if ( Lang13.Bool( this.emagged ) ) {
				return 10;
			}

			if ( ( this.stun_all || this.attacked ) && !this.allowed( perp ) ) {
				
				if ( !this.allowed( perp ) ) {
					return 10;
				}
			}

			if ( this.auth_weapons ) {
				
				if ( perp.wear_id == null || ((Obj_Item)perp.wear_id).GetID() is Obj_Item_Weapon_Card_Id_Syndicate ) {
					
					if ( this.allowed( perp ) && !Lang13.Bool( this.lasercolor ) ) {
						return 0;
					}

					if ( perp.l_hand is Obj_Item_Weapon_Gun && !( perp.l_hand is Obj_Item_Weapon_Gun_Projectile_Revolver_Doublebarrel ) || perp.l_hand is Obj_Item_Weapon_Melee_Baton ) {
						threatcount += 4;
					}

					if ( perp.r_hand is Obj_Item_Weapon_Gun && !( perp.r_hand is Obj_Item_Weapon_Gun_Projectile_Revolver_Doublebarrel ) || perp.r_hand is Obj_Item_Weapon_Melee_Baton ) {
						threatcount += 4;
					}

					if ( perp.belt is Obj_Item_Weapon_Gun || perp.belt is Obj_Item_Weapon_Melee_Baton ) {
						threatcount += 2;
					}
				}
			}

			if ( this.lasercolor == "b" ) {
				threatcount = 0;

				if ( perp.wear_suit is Obj_Item_Clothing_Suit_Redtag ) {
					threatcount += 4;
				}

				if ( perp.r_hand is Obj_Item_Weapon_Gun_Energy_Laser_Redtag || perp.l_hand is Obj_Item_Weapon_Gun_Energy_Laser_Redtag ) {
					threatcount += 4;
				}

				if ( perp.belt is Obj_Item_Weapon_Gun_Energy_Laser_Redtag ) {
					threatcount += 2;
				}
			}

			if ( this.lasercolor == "r" ) {
				threatcount = 0;

				if ( perp.wear_suit is Obj_Item_Clothing_Suit_Bluetag ) {
					threatcount += 4;
				}

				if ( perp.r_hand is Obj_Item_Weapon_Gun_Energy_Laser_Bluetag || perp.l_hand is Obj_Item_Weapon_Gun_Energy_Laser_Bluetag ) {
					threatcount += 4;
				}

				if ( perp.belt is Obj_Item_Weapon_Gun_Energy_Laser_Bluetag ) {
					threatcount += 2;
				}
			}

			if ( this.check_records ) {
				perpname = ((Mob_Living_Carbon_Human)perp).get_face_name( ((Mob_Living_Carbon_Human)perp).get_id_name() );
				R = GlobalFuncs.find_record( "name", perpname, GlobalVars.data_core.security );

				if ( !( R != null ) || R.fields["criminal"] == "*Arrest*" ) {
					threatcount += 4;
				}
			}
			return threatcount;
		}

		// Function from file: portable_turret.dm
		public void popDown(  ) {
			
			if ( this.disabled ) {
				return;
			}

			if ( this.raising || !this.raised ) {
				return;
			}

			if ( ( this.stat & 1 ) != 0 ) {
				return;
			}
			this.layer = 3;
			this.raising = true;

			if ( this.cover != null ) {
				Icon13.Flick( "popdown", this.cover );
			}
			Task13.Sleep( 10 );
			this.raising = false;

			if ( this.cover != null ) {
				this.cover.icon_state = "turretCover";
			}
			this.raised = false;
			this.invisibility = 2;
			this.icon_state = "" + this.base_icon_state + this.off_state;
			return;
		}

		// Function from file: portable_turret.dm
		public void popUp(  ) {
			
			if ( this.disabled ) {
				return;
			}

			if ( this.raising || this.raised ) {
				return;
			}

			if ( ( this.stat & 1 ) != 0 ) {
				return;
			}
			this.invisibility = 0;
			this.raising = true;

			if ( this.cover != null ) {
				Icon13.Flick( "popup", this.cover );
			}
			Task13.Sleep( 10 );
			this.raising = false;

			if ( this.cover != null ) {
				this.cover.icon_state = "openTurretCover";
			}
			this.raised = true;
			this.layer = 4;
			return;
		}

		// Function from file: portable_turret.dm
		public bool tryToShootAt( ByTable targets = null ) {
			dynamic M = null;

			
			while (targets.len > 0) {
				M = Rand13.PickFromTable( targets );
				targets.Remove( M );

				if ( this.target( M ) ) {
					return true;
				}
			}
			return false;
		}

		// Function from file: portable_turret.dm
		public ByTable calculate_targets(  ) {
			ByTable targets = null;
			ByTable turretview = null;
			dynamic A = null;
			dynamic SA = null;
			dynamic C = null;
			dynamic M = null;

			targets = new ByTable();
			turretview = Map13.FetchInView( this.v_base, this.scan_range );

			foreach (dynamic _a in Lang13.Enumerate( turretview )) {
				A = _a;
				

				if ( this.check_anomalies ) {
					
					if ( A is Mob_Living_SimpleAnimal ) {
						SA = A;

						if ( Lang13.Bool( SA.stat ) || this.in_faction( SA ) ) {
							continue;
						}
						targets.Add( SA );
					}
				}

				if ( A is Mob_Living_Carbon ) {
					C = A;

					if ( !Lang13.Bool( this.emagged ) && ( Lang13.Bool( C.stat ) || Lang13.Bool( C.handcuffed ) || Lang13.Bool( C.lying ) ) ) {
						continue;
					}

					if ( Lang13.Bool( this.emagged ) && Convert.ToInt32( C.stat ) == 2 ) {
						continue;
					}

					if ( C is Mob_Living_Carbon_Human && !this.in_faction( C ) ) {
						
						if ( this.assess_perp( C ) >= 4 ) {
							targets.Add( C );
						}
					} else if ( this.check_anomalies ) {
						
						if ( !this.in_faction( C ) ) {
							targets.Add( C );
						}
					}
				}

				if ( A is Obj_Mecha ) {
					M = A;

					if ( Lang13.Bool( M.occupant ) && !this.in_faction( M.occupant ) ) {
						
						if ( this.assess_perp( M.occupant ) >= 4 ) {
							targets.Add( M );
						}
					}
				}
			}
			return targets;
		}

		// Function from file: portable_turret.dm
		public void die(  ) {
			this.health = 0;
			this.density = false;
			this.stat |= 1;
			this.icon_state = "" + this.base_icon_state + "Broken";
			this.invisibility = 0;
			this.spark_system.start();
			this.density = true;
			GlobalFuncs.qdel( this.cover );
			return;
		}

		// Function from file: portable_turret.dm
		public void take_damage( dynamic damage = null ) {
			this.health -= Convert.ToDouble( damage );

			if ( this.health <= 0 ) {
				this.die();
			}
			return;
		}

		// Function from file: portable_turret.dm
		public virtual void setup(  ) {
			dynamic E = null;
			dynamic shottype = null;

			E = Lang13.Call( this.installation );
			shottype = E.ammo_type[1];
			this.projectile = shottype.projectile_type;
			this.eprojectile = this.projectile;
			this.shot_sound = shottype.fire_sound;
			this.eshot_sound = this.shot_sound;

			dynamic _a = E.type; // Was a switch-case, sorry for the mess.
			if ( _a==typeof(Obj_Item_Weapon_Gun_Energy_Laser_Bluetag) ) {
				this.eprojectile = typeof(Obj_Item_Projectile_Beam_Lasertag_Bluetag);
				this.lasercolor = "b";
				this.req_access = new ByTable(new object [] { GlobalVars.access_maint_tunnels, GlobalVars.access_theatre });
				this.check_records = false;
				this.criminals = false;
				this.auth_weapons = true;
				this.stun_all = false;
				this.check_anomalies = false;
				this.shot_delay = 30;
			} else if ( _a==typeof(Obj_Item_Weapon_Gun_Energy_Laser_Redtag) ) {
				this.eprojectile = typeof(Obj_Item_Projectile_Beam_Lasertag_Redtag);
				this.lasercolor = "r";
				this.req_access = new ByTable(new object [] { GlobalVars.access_maint_tunnels, GlobalVars.access_theatre });
				this.check_records = false;
				this.criminals = false;
				this.auth_weapons = true;
				this.stun_all = false;
				this.check_anomalies = false;
				this.shot_delay = 30;
				this.active_state = "Laser";
			} else if ( _a==typeof(Obj_Item_Weapon_Gun_Energy_Laser_Practice) ) {
				this.active_state = "Laser";
				this.eprojectile = typeof(Obj_Item_Projectile_Beam);
			} else if ( _a==typeof(Obj_Item_Weapon_Gun_Energy_Laser_Retro) ) {
				this.active_state = "Laser";
			} else if ( _a==typeof(Obj_Item_Weapon_Gun_Energy_Laser_Captain) ) {
				this.active_state = "Laser";
			} else if ( _a==typeof(Obj_Item_Weapon_Gun_Energy_Lasercannon) ) {
				this.active_state = "Laser";
			} else if ( _a==typeof(Obj_Item_Weapon_Gun_Energy_Gun_Advtaser) ) {
				this.eprojectile = typeof(Obj_Item_Projectile_Beam);
				this.eshot_sound = "sound/weapons/Laser.ogg";
			} else if ( _a==typeof(Obj_Item_Weapon_Gun_Energy_Gun) ) {
				this.eprojectile = typeof(Obj_Item_Projectile_Beam);
				this.eshot_sound = "sound/weapons/Laser.ogg";
				this.egun = true;
			} else if ( _a==typeof(Obj_Item_Weapon_Gun_Energy_Gun_Nuclear) ) {
				this.eprojectile = typeof(Obj_Item_Projectile_Beam);
				this.eshot_sound = "sound/weapons/Laser.ogg";
				this.egun = true;
			} else if ( _a==typeof(Obj_Item_Weapon_Gun_Energy_Gun_Turret) ) {
				this.eprojectile = typeof(Obj_Item_Projectile_Beam);
				this.eshot_sound = "sound/weapons/Laser.ogg";
				this.egun = true;
			}
			this.base_icon_state = this.get_base_icon();
			return;
		}

		// Function from file: portable_turret.dm
		public string get_base_icon(  ) {
			
			if ( Lang13.Bool( this.installation ) ) {
				
				dynamic _a = this.installation; // Was a switch-case, sorry for the mess.
				if ( _a==typeof(Obj_Item_Weapon_Gun_Energy_Laser_Bluetag) ) {
					return "blue";
				} else if ( _a==typeof(Obj_Item_Weapon_Gun_Energy_Laser_Redtag) ) {
					return "red";
				}
			}
			return "grey";
		}

		// Function from file: swarmer.dm
		public override void swarmer_act( Mob_Living_SimpleAnimal_Hostile_Swarmer S = null ) {
			S.WriteMsg( "<span class='warning'>Attempting to dismantle this machine would result in an immediate counterattack. Aborting.</span>" );
			return;
		}

	}

}