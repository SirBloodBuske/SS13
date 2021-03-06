// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Bot_Ed209 : Mob_Living_SimpleAnimal_Bot {

		public int lastfired = 0;
		public int shot_delay = 3;
		public string lasercolor = "";
		public bool disabled = false;
		public dynamic target = null;
		public string oldtarget_name = null;
		public int threatlevel = 0;
		public Ent_Static target_lastloc = null;
		public int last_found = 0;
		public bool declare_arrests = true;
		public bool idcheck = true;
		public bool weaponscheck = true;
		public bool check_records = true;
		public bool arrest_type = false;
		public Type projectile = typeof(Obj_Item_Projectile_Energy_Electrode);
		public string shoot_sound = "sound/weapons/taser.ogg";

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage_coeff = new ByTable().Set( "brute", 0.5 ).Set( "fire", 061 ).Set( "tox", 0 ).Set( "clone", 0 ).Set( "stamina", 0 ).Set( "oxy", 0 );
			this.environment_smash = 2;
			this.mob_size = 3;
			this.radio_key = typeof(Obj_Item_Device_Encryptionkey_HeadsetSec);
			this.radio_channel = "Security";
			this.bot_type = 1;
			this.model = "ED-209";
			this.bot_core = typeof(Obj_Machinery_BotCore_Secbot);
			this.window_id = "autoed209";
			this.window_name = "Automatic Security Unit v2.6";
			this.allow_pai = false;
			this.icon_state = "ed2090";
		}

		// Function from file: ed209bot.dm
		public Mob_Living_SimpleAnimal_Bot_Ed209 ( dynamic loc = null, string created_name = null, string created_lasercolor = null ) : base( (object)(loc) ) {
			Job_Detective J = null;
			AtomHud secsensor = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( Lang13.Bool( created_name ) ) {
				this.name = created_name;
			}

			if ( Lang13.Bool( created_lasercolor ) ) {
				this.lasercolor = created_lasercolor;
			}
			this.icon_state = "" + this.lasercolor + "ed209" + this.on;
			this.set_weapon();
			Task13.Schedule( 3, (Task13.Closure)(() => {
				J = new Job_Detective();
				this.access_card.access += J.get_access();
				this.prev_access = this.access_card.access;

				if ( Lang13.Bool( this.lasercolor ) ) {
					this.shot_delay = 6;
					this.check_records = false;
					this.arrest_type = true;
					this.bot_core.req_access = new ByTable(new object [] { GlobalVars.access_maint_tunnels, GlobalVars.access_theatre });
					this.arrest_type = true;

					if ( this.lasercolor == "b" && this.name == "ÿED-209 Security Robot" ) {
						this.name = Rand13.Pick(new object [] { "BLUE BALLER", "SANIC", "BLUE KILLDEATH MURDERBOT" });
					}

					if ( this.lasercolor == "r" && this.name == "ÿED-209 Security Robot" ) {
						this.name = Rand13.Pick(new object [] { "RED RAMPAGE", "RED ROVER", "RED KILLDEATH MURDERBOT" });
					}
				}
				return;
			}));
			secsensor = GlobalVars.huds[2];
			secsensor.add_hud_to( this );
			return;
		}

		// Function from file: ed209bot.dm
		public override void RangedAttack( Ent_Static A = null, string _params = null ) {
			
			if ( !Lang13.Bool( this.on ) ) {
				return;
			}
			this.shootAt( A );
			return;
		}

		// Function from file: ed209bot.dm
		public override void UnarmedAttack( Ent_Static A = null, bool? proximity_flag = null ) {
			Ent_Static C = null;

			
			if ( !Lang13.Bool( this.on ) ) {
				return;
			}

			if ( A is Mob_Living_Carbon ) {
				C = A;

				if ( !Lang13.Bool( ((dynamic)C).stunned ) || this.arrest_type ) {
					this.stun_attack( A );
				} else if ( Lang13.Bool( ((dynamic)C).canBeHandcuffed() ) && !Lang13.Bool( ((dynamic)C).handcuffed ) ) {
					this.cuff( A );
				}
			} else {
				base.UnarmedAttack( A, proximity_flag );
			}
			return;
		}

		// Function from file: ed209bot.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			
			if ( P is Obj_Item_Projectile_Beam || P is Obj_Item_Projectile_Bullet ) {
				
				if ( P.damage_type == "fire" || P.damage_type == "brute" ) {
					
					if ( !P.nodamage && Convert.ToDouble( P.damage ) < Convert.ToDouble( this.health ) ) {
						this.retaliate( P.firer );
					}
				}
			}
			base.bullet_act( (object)(P), (object)(def_zone) );
			return null;
		}

		// Function from file: ed209bot.dm
		public override double emp_act( int severity = 0 ) {
			Obj_Effect_Overlay pulse2 = null;
			ByTable targets = null;
			Mob_Living_Carbon C = null;
			dynamic toshoot = null;
			dynamic toarrest = null;

			
			if ( severity == 2 && Rand13.PercentChance( 70 ) ) {
				base.emp_act( severity - 1 );
			} else {
				pulse2 = new Obj_Effect_Overlay( this.loc );
				pulse2.icon = "icons/effects/effects.dmi";
				pulse2.icon_state = "empdisable";
				pulse2.name = "emp sparks";
				pulse2.anchored = 1;
				pulse2.dir = Convert.ToInt32( Rand13.PickFromTable( GlobalVars.cardinal ) );
				Task13.Schedule( 10, (Task13.Closure)(() => {
					GlobalFuncs.qdel( pulse2 );
					return;
				}));
				targets = new ByTable();

				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInView( this, 12 ), typeof(Mob_Living_Carbon) )) {
					C = _a;
					

					if ( C.stat == 2 ) {
						continue;
					}
					targets.Add( C );
				}

				if ( targets.len != 0 ) {
					
					if ( Rand13.PercentChance( 50 ) ) {
						toshoot = Rand13.PickFromTable( targets );

						if ( Lang13.Bool( toshoot ) ) {
							targets.Remove( toshoot );

							if ( Rand13.PercentChance( 50 ) && this.emagged < 2 ) {
								this.emagged = 2;
								this.set_weapon();
								this.shootAt( toshoot );
								this.emagged = 0;
								this.set_weapon();
							} else {
								this.shootAt( toshoot );
							}
						}
					} else if ( Rand13.PercentChance( 50 ) ) {
						
						if ( targets.len != 0 ) {
							toarrest = Rand13.PickFromTable( targets );

							if ( Lang13.Bool( toarrest ) ) {
								this.target = toarrest;
								this.v_mode = 1;
							}
						}
					}
				}
			}
			return 0;
		}

		// Function from file: ed209bot.dm
		public override bool attack_alien( dynamic user = null ) {
			base.attack_alien( (object)(user) );

			if ( !( this.target is Mob_Living_Carbon_Alien ) ) {
				this.target = user;
				this.v_mode = 1;
			}
			return false;
		}

		// Function from file: ed209bot.dm
		public override void explode(  ) {
			dynamic Tsec = null;
			Obj_Item_Weapon_Ed209Assembly Sa = null;
			Obj_Item_Weapon_Gun_Energy_Gun_Advtaser G = null;
			Obj_Item_Weapon_Gun_Energy_Laser_Bluetag G2 = null;
			Obj_Item_Weapon_Gun_Energy_Laser_Redtag G3 = null;
			EffectSystem_SparkSpread s = null;

			Map13.WalkTowards( this, 0, 0, 0 );
			this.visible_message( "<span class='boldannounce'>" + this + " blows apart!</span>" );
			Tsec = GlobalFuncs.get_turf( this );
			Sa = new Obj_Item_Weapon_Ed209Assembly( Tsec );
			Sa.build_step = 1;
			Sa.overlays.Add( new Image( "icons/obj/aibots.dmi", "hs_hole" ) );
			Sa.created_name = this.name;
			new Obj_Item_Device_Assembly_ProxSensor( Tsec );

			if ( !Lang13.Bool( this.lasercolor ) ) {
				G = new Obj_Item_Weapon_Gun_Energy_Gun_Advtaser( Tsec );
				G.power_supply.charge = 0;
				G.update_icon();
			} else if ( this.lasercolor == "b" ) {
				G2 = new Obj_Item_Weapon_Gun_Energy_Laser_Bluetag( Tsec );
				G2.power_supply.charge = 0;
				G2.update_icon();
			} else if ( this.lasercolor == "r" ) {
				G3 = new Obj_Item_Weapon_Gun_Energy_Laser_Redtag( Tsec );
				G3.power_supply.charge = 0;
				G3.update_icon();
			}

			if ( Rand13.PercentChance( 50 ) ) {
				new Obj_Item_RobotParts_LLeg( Tsec );

				if ( Rand13.PercentChance( 25 ) ) {
					new Obj_Item_RobotParts_RLeg( Tsec );
				}
			}

			if ( Rand13.PercentChance( 25 ) ) {
				
				if ( Rand13.PercentChance( 50 ) ) {
					new Obj_Item_Clothing_Head_Helmet( Tsec );
				} else {
					
					if ( !Lang13.Bool( this.lasercolor ) ) {
						new Obj_Item_Clothing_Suit_Armor_Vest( Tsec );
					}

					if ( this.lasercolor == "b" ) {
						new Obj_Item_Clothing_Suit_Bluetag( Tsec );
					}

					if ( this.lasercolor == "r" ) {
						new Obj_Item_Clothing_Suit_Redtag( Tsec );
					}
				}
			}
			s = new EffectSystem_SparkSpread();
			s.set_up( 3, 1, this );
			s.start();
			new Obj_Effect_Decal_Cleanable_Oil( this.loc );
			base.explode();
			return;
		}

		// Function from file: ed209bot.dm
		public override bool handle_automated_action(  ) {
			ByTable targets = null;
			Mob_Living_Carbon C = null;
			int threatlevel = 0;
			int dst = 0;
			dynamic t = null;
			int olddist = 0;

			
			if ( !base.handle_automated_action() ) {
				return false;
			}

			if ( this.disabled ) {
				return false;
			}
			targets = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInView( this, 7 ), typeof(Mob_Living_Carbon) )) {
				C = _a;
				
				threatlevel = 0;

				if ( C.stat != 0 || Lang13.Bool( C.lying ) ) {
					continue;
				}
				threatlevel = C.assess_threat( this, this.lasercolor );

				if ( threatlevel < 4 ) {
					continue;
				}
				dst = Map13.GetDistance( this, C );

				if ( dst <= 1 || dst > 7 ) {
					continue;
				}
				targets.Add( C );
			}

			if ( targets.len > 0 ) {
				t = Rand13.PickFromTable( targets );

				if ( Convert.ToInt32( t.stat ) != 2 && t.lying != 1 && !Lang13.Bool( t.handcuffed ) ) {
					this.shootAt( t );
				}
			}

			switch ((int)( this.v_mode )) {
				case 0:
					Map13.WalkTowards( this, 0, 0, 0 );

					if ( !Lang13.Bool( this.lasercolor ) ) {
						this.look_for_perp();
					}

					if ( !( this.v_mode != 0 ) && this.auto_patrol ) {
						this.v_mode = 4;
					}
					break;
				case 1:
					
					if ( this.frustration >= 8 ) {
						Map13.WalkTowards( this, 0, 0, 0 );
						this.back_to_idle();
					}

					if ( Lang13.Bool( this.target ) ) {
						
						if ( this.Adjacent( this.target ) && this.target.loc is Tile ) {
							this.stun_attack( this.target );
							this.v_mode = 2;
							this.anchored = 1;
							this.target_lastloc = this.target.loc;
							return false;
						} else {
							olddist = Map13.GetDistance( this, this.target );
							Map13.WalkTowards( this, this.target, 1, 4 );

							if ( Map13.GetDistance( this, this.target ) >= olddist ) {
								this.frustration++;
							} else {
								this.frustration = 0;
							}
						}
					} else {
						this.back_to_idle();
					}
					break;
				case 2:
					
					if ( !this.Adjacent( this.target ) || !( this.target.loc is Tile ) || this.target.weakened < 2 ) {
						this.back_to_hunt();
						return false;
					}

					if ( this.target is Mob_Living_Carbon && ((Mob_Living_Carbon)this.target).canBeHandcuffed() ) {
						
						if ( !this.arrest_type ) {
							
							if ( !Lang13.Bool( this.target.handcuffed ) ) {
								this.cuff( this.target );
							} else {
								this.back_to_idle();
								return false;
							}
						}
					} else {
						this.back_to_idle();
						return false;
					}
					break;
				case 3:
					
					if ( !Lang13.Bool( this.target ) ) {
						this.anchored = 0;
						this.v_mode = 0;
						this.last_found = Game13.time;
						this.frustration = 0;
						return false;
					}

					if ( Lang13.Bool( this.target.handcuffed ) ) {
						this.back_to_idle();
						return false;
					}

					if ( !this.Adjacent( this.target ) || !( this.target.loc is Tile ) || this.target.loc != this.target_lastloc && this.target.weakened < 2 ) {
						this.back_to_hunt();
						return false;
					} else {
						this.v_mode = 2;
						this.anchored = 0;
					}
					break;
				case 4:
					this.look_for_perp();
					this.start_patrol();
					break;
				case 5:
					this.look_for_perp();
					this.bot_patrol();
					break;
			}
			return false;
		}

		// Function from file: ed209bot.dm
		public override bool emag_act( dynamic user = null ) {
			base.emag_act( (object)(user) );

			if ( this.emagged == 2 ) {
				
				if ( Lang13.Bool( user ) ) {
					user.WriteMsg( "<span class='warning'>You short out " + this + "'s target assessment circuits.</span>" );
					this.oldtarget_name = user.name;
				}
				this.audible_message( "<span class='danger'>" + this + " buzzes oddly!</span>" );
				this.declare_arrests = false;
				this.icon_state = "" + this.lasercolor + "ed209" + this.on;
				this.set_weapon();
			}
			return false;
		}

		// Function from file: ed209bot.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( A is Obj_Item_Weapon_Weldingtool && user.a_intent != "harm" ) {
				return null;
			}

			if ( !( A is Obj_Item_Weapon_Screwdriver ) && !Lang13.Bool( this.target ) ) {
				
				if ( Lang13.Bool( A.force ) && A.damtype != "stamina" ) {
					this.retaliate( user );

					if ( Lang13.Bool( this.lasercolor ) ) {
						this.shootAt( user );
					}
				}
			}
			return null;
		}

		// Function from file: ed209bot.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			
			if ( a.a_intent == "harm" ) {
				this.retaliate( a );
			}
			return base.attack_hand( (object)(a), b, c );
		}

		// Function from file: ed209bot.dm
		public void cuff( dynamic C = null ) {
			this.v_mode = 3;
			GlobalFuncs.playsound( this.loc, "sound/weapons/cablecuff.ogg", 30, 1, -2 );
			((Ent_Static)C).visible_message( "<span class='danger'>" + this + " is trying to put zipties on " + C + "!</span>", "<span class='userdanger'>" + this + " is trying to put zipties on you!</span>" );
			Task13.Schedule( 60, (Task13.Closure)(() => {
				
				if ( !this.Adjacent( C ) || !( C.loc is Tile ) ) {
					return;
				}

				if ( !Lang13.Bool( C.handcuffed ) ) {
					C.handcuffed = new Obj_Item_Weapon_Restraints_Handcuffs_Cable_Zipties_Used( C );
					((Mob_Living_Carbon)C).update_handcuffed();
					this.back_to_idle();
				}
				return;
			}));
			return;
		}

		// Function from file: ed209bot.dm
		public void stun_attack( dynamic C = null ) {
			int threat = 0;
			dynamic H = null;
			dynamic location = null;

			GlobalFuncs.playsound( this.loc, "sound/weapons/Egloves.ogg", 50, 1, -1 );
			this.icon_state = "" + this.lasercolor + "ed209-c";
			Task13.Schedule( 2, (Task13.Closure)(() => {
				this.icon_state = "" + this.lasercolor + "ed209" + this.on;
				return;
			}));
			threat = 5;

			if ( C is Mob_Living_Carbon_Human ) {
				C.stuttering = 5;
				((Mob)C).Stun( 5 );
				((Mob)C).Weaken( 5 );
				H = C;
				threat = ((Mob)H).assess_threat( this );
			} else {
				((Mob)C).Weaken( 5 );
				C.stuttering = 5;
				((Mob)C).Stun( 5 );
			}
			GlobalFuncs.add_logs( this, C, "stunned" );

			if ( this.declare_arrests ) {
				location = GlobalFuncs.get_area( this );
				this.f_speak( "" + ( this.arrest_type ? "Detaining" : "Arresting" ) + " level " + threat + " scumbag <b>" + C + "</b> in " + location + ".", this.radio_channel );
			}
			((Ent_Static)C).visible_message( "<span class='danger'>" + this + " has stunned " + C + "!</span>", "<span class='userdanger'>" + this + " has stunned you!</span>" );
			return;
		}

		// Function from file: ed209bot.dm
		public void shootAt( dynamic target = null ) {
			Ent_Static T = null;
			dynamic U = null;
			dynamic A = null;

			
			if ( this.lastfired != 0 && Game13.time - this.lastfired < this.shot_delay ) {
				return;
			}
			this.lastfired = Game13.time;
			T = this.loc;
			U = ( target is Ent_Dynamic ? ((dynamic)( target.loc )) : target );

			if ( !Lang13.Bool( U ) || !( T != null ) ) {
				return;
			}

			while (!( U is Tile )) {
				U = U.loc;
			}

			if ( !( T is Tile ) ) {
				return;
			}

			if ( !( this.projectile != null ) ) {
				return;
			}

			if ( !( U is Tile ) ) {
				return;
			}
			A = Lang13.Call( this.projectile, this.loc );
			GlobalFuncs.playsound( this.loc, this.shoot_sound, 50, 1 );
			A.current = U;
			A.yo = Convert.ToDouble( U.y - T.y );
			A.xo = Convert.ToDouble( U.x - T.x );
			((Obj_Item_Projectile)A).fire();
			return;
		}

		// Function from file: ed209bot.dm
		public void set_weapon(  ) {
			this.shoot_sound = "sound/weapons/Laser.ogg";

			if ( this.emagged == 2 ) {
				
				if ( Lang13.Bool( this.lasercolor ) ) {
					this.projectile = typeof(Obj_Item_Projectile_Beam_Lasertag);
				} else {
					this.projectile = typeof(Obj_Item_Projectile_Beam);
				}
			} else if ( !Lang13.Bool( this.lasercolor ) ) {
				this.shoot_sound = "sound/weapons/taser.ogg";
				this.projectile = typeof(Obj_Item_Projectile_Energy_Electrode);
			} else if ( this.lasercolor == "b" ) {
				this.projectile = typeof(Obj_Item_Projectile_Beam_Lasertag_Bluetag);
			} else if ( this.lasercolor == "r" ) {
				this.projectile = typeof(Obj_Item_Projectile_Beam_Lasertag_Redtag);
			}
			return;
		}

		// Function from file: ed209bot.dm
		public bool check_for_weapons( Obj_Item slot_item = null ) {
			
			if ( slot_item != null && slot_item.needs_permit ) {
				return true;
			}
			return false;
		}

		// Function from file: ed209bot.dm
		public void look_for_perp(  ) {
			Mob_Living_Carbon C = null;

			
			if ( this.disabled ) {
				return;
			}
			this.anchored = 0;
			this.threatlevel = 0;

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInView( this, 7 ), typeof(Mob_Living_Carbon) )) {
				C = _a;
				

				if ( C.stat != 0 || Lang13.Bool( C.handcuffed ) ) {
					continue;
				}

				if ( C.name == this.oldtarget_name && Game13.time < this.last_found + 100 ) {
					continue;
				}
				this.threatlevel = C.assess_threat( this, this.lasercolor );

				if ( !( this.threatlevel != 0 ) ) {
					continue;
				} else if ( this.threatlevel >= 4 ) {
					this.target = C;
					this.oldtarget_name = C.name;
					this.f_speak( "Level " + this.threatlevel + " infraction alert!" );
					GlobalFuncs.playsound( this.loc, Rand13.Pick(new object [] { "sound/voice/ed209_20sec.ogg", "sound/voice/EDPlaceholder.ogg" }), 50, 0 );
					this.visible_message( "<b>" + this + "</b> points at " + C.name + "!" );
					this.v_mode = 1;
					Task13.Schedule( 0, (Task13.Closure)(() => {
						this.handle_automated_action();
						return;
					}));
					break;
				} else {
					continue;
				}
			}
			return;
		}

		// Function from file: ed209bot.dm
		public void back_to_hunt(  ) {
			this.anchored = 0;
			this.frustration = 0;
			this.v_mode = 1;
			Task13.Schedule( 0, (Task13.Closure)(() => {
				this.handle_automated_action();
				return;
			}));
			return;
		}

		// Function from file: ed209bot.dm
		public void back_to_idle(  ) {
			this.anchored = 0;
			this.v_mode = 0;
			this.target = null;
			this.last_found = Game13.time;
			this.frustration = 0;
			Task13.Schedule( 0, (Task13.Closure)(() => {
				this.handle_automated_action();
				return;
			}));
			return;
		}

		// Function from file: ed209bot.dm
		public void retaliate( dynamic H = null ) {
			this.threatlevel = ((Mob)H).assess_threat( this );
			this.threatlevel += 6;

			if ( this.threatlevel >= 4 ) {
				this.target = H;
				this.v_mode = 1;
			}
			return;
		}

		// Function from file: ed209bot.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			Mob H = null;

			
			if ( Lang13.Bool( this.lasercolor ) && Task13.User is Mob_Living_Carbon_Human ) {
				H = Task13.User;

				if ( this.lasercolor == "b" && ((dynamic)H).wear_suit is Obj_Item_Clothing_Suit_Redtag ) {
					return null;
				} else if ( this.lasercolor == "r" && ((dynamic)H).wear_suit is Obj_Item_Clothing_Suit_Bluetag ) {
					return null;
				}
			}

			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return 1;
			}

			dynamic _a = href_list["operation"]; // Was a switch-case, sorry for the mess.
			if ( _a=="idcheck" ) {
				this.idcheck = !this.idcheck;
				this.update_controls();
			} else if ( _a=="weaponscheck" ) {
				this.weaponscheck = !this.weaponscheck;
				this.update_controls();
			} else if ( _a=="ignorerec" ) {
				this.check_records = !this.check_records;
				this.update_controls();
			} else if ( _a=="switchmode" ) {
				this.arrest_type = !this.arrest_type;
				this.update_controls();
			} else if ( _a=="declarearrests" ) {
				this.declare_arrests = !this.declare_arrests;
				this.update_controls();
			}
			return null;
		}

		// Function from file: ed209bot.dm
		public override string get_controls( dynamic M = null ) {
			dynamic dat = null;

			dat += this.hack( M );
			dat += this.showpai( M );
			dat += "\n<TT><B>Security Unit v2.6 controls</B></TT><BR><BR>\nStatus: " + new Txt( "<A href='?src=" ).Ref( this ).str( ";power=1'>" ).item( ( Lang13.Bool( this.on ) ? "On" : "Off" ) ).str( "</A>" ).ToString() + "<BR>\nBehaviour controls are " + ( this.locked ? "locked" : "unlocked" ) + "<BR>\nMaintenance panel panel is " + ( this.open ? "opened" : "closed" ) + "<BR>";

			if ( !this.locked || M is Mob_Living_Silicon || Lang13.Bool( GlobalFuncs.IsAdminGhost( M ) ) ) {
				
				if ( !Lang13.Bool( this.lasercolor ) ) {
					dat += "<BR>\nArrest Unidentifiable Persons: " + new Txt( "<A href='?src=" ).Ref( this ).str( ";operation=idcheck'>" ).item( ( this.idcheck ? "Yes" : "No" ) ).str( "</A>" ).ToString() + "<BR>\nArrest for Unauthorized Weapons: " + new Txt( "<A href='?src=" ).Ref( this ).str( ";operation=weaponscheck'>" ).item( ( this.weaponscheck ? "Yes" : "No" ) ).str( "</A>" ).ToString() + "<BR>\nArrest for Warrant: " + new Txt( "<A href='?src=" ).Ref( this ).str( ";operation=ignorerec'>" ).item( ( this.check_records ? "Yes" : "No" ) ).str( "</A>" ).ToString() + "<BR>\n<BR>\nOperating Mode: " + new Txt( "<A href='?src=" ).Ref( this ).str( ";operation=switchmode'>" ).item( ( this.arrest_type ? "Detain" : "Arrest" ) ).str( "</A>" ).ToString() + "<BR>\nReport Arrests" + new Txt( "<A href='?src=" ).Ref( this ).str( ";operation=declarearrests'>" ).item( ( this.declare_arrests ? "Yes" : "No" ) ).str( "</A>" ).ToString() + "<BR>\nAuto Patrol" + new Txt( "<A href='?src=" ).Ref( this ).str( ";operation=patrol'>" ).item( ( this.auto_patrol ? "On" : "Off" ) ).str( "</A>" ).ToString();
				}
			}
			return dat;
		}

		// Function from file: ed209bot.dm
		public override void set_custom_texts(  ) {
			this.text_hack = "You disable " + this.name + "'s combat inhibitor.";
			this.text_dehack = "You restore " + this.name + "'s combat inhibitor.";
			this.text_dehack_fail = "" + this.name + " ignores your attempts to restrict him!";
			return;
		}

		// Function from file: ed209bot.dm
		public override void bot_reset(  ) {
			base.bot_reset();
			this.target = null;
			this.oldtarget_name = null;
			this.anchored = 0;
			Map13.WalkTowards( this, 0, 0, 0 );
			this.last_found = Game13.time;
			this.set_weapon();
			return;
		}

		// Function from file: ed209bot.dm
		public override void turn_off(  ) {
			base.turn_off();
			this.icon_state = "" + this.lasercolor + "ed209" + this.on;
			return;
		}

		// Function from file: ed209bot.dm
		public override bool turn_on(  ) {
			bool _default = false;

			_default = base.turn_on();
			this.icon_state = "" + this.lasercolor + "ed209" + this.on;
			this.v_mode = 0;
			return _default;
		}

	}

}