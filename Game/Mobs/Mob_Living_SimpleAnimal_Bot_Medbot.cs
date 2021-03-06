// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_SimpleAnimal_Bot_Medbot : Mob_Living_SimpleAnimal_Bot {

		public dynamic reagent_glass = null;
		public string skin = null;
		public dynamic patient = null;
		public dynamic oldpatient = null;
		public dynamic oldloc = null;
		public int last_found = 0;
		public int last_newpatient_speak = 0;
		public double? injection_amount = 15;
		public double heal_threshold = 10;
		public bool use_beaker = false;
		public bool declare_crit = true;
		public bool declare_cooldown = false;
		public bool stationary_mode = false;
		public string treatment_brute = "bicaridine";
		public string treatment_oxy = "dexalin";
		public string treatment_fire = "kelotane";
		public string treatment_tox = "antitoxin";
		public string treatment_virus = "spaceacillin";
		public bool treat_virus = true;
		public bool shut_up = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.pass_flags = 16;
			this.radio_key = typeof(Obj_Item_Device_Encryptionkey_HeadsetMed);
			this.radio_channel = "Medical";
			this.bot_type = 16;
			this.model = "Medibot";
			this.bot_core_type = typeof(Obj_Machinery_BotCore_Medbot);
			this.window_id = "automed";
			this.window_name = "Automatic Medical Unit v1.1";
			this.icon_state = "medibot0";
		}

		// Function from file: medbot.dm
		public Mob_Living_SimpleAnimal_Bot_Medbot ( dynamic loc = null ) : base( (object)(loc) ) {
			Job_Doctor J = null;
			AtomHud medsensor = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.update_icon();
			Task13.Schedule( 4, (Task13.Closure)(() => {
				
				if ( Lang13.Bool( this.skin ) ) {
					this.overlays.Add( new Image( "icons/obj/aibots.dmi", "medskin_" + this.skin ) );
				}
				J = new Job_Doctor();
				this.access_card.access += J.get_access();
				this.prev_access = this.access_card.access;
				return;
			}));
			medsensor = GlobalVars.huds[4];
			medsensor.add_hud_to( this );
			return;
		}

		// Function from file: medbot.dm
		public override void explode(  ) {
			dynamic Tsec = null;
			EffectSystem_SparkSpread s = null;

			this.on = 0;
			this.visible_message( "<span class='boldannounce'>" + this + " blows apart!</span>" );
			Tsec = GlobalFuncs.get_turf( this );
			new Obj_Item_Weapon_Storage_Firstaid( Tsec );
			new Obj_Item_Device_Assembly_ProxSensor( Tsec );
			new Obj_Item_Device_Healthanalyzer( Tsec );

			if ( Lang13.Bool( this.reagent_glass ) ) {
				this.reagent_glass.loc = Tsec;
				this.reagent_glass = null;
			}

			if ( Rand13.PercentChance( 50 ) ) {
				new Obj_Item_RobotParts_LArm( Tsec );
			}
			s = new EffectSystem_SparkSpread();
			s.set_up( 3, 1, this );
			s.start();
			base.explode();
			return;
		}

		// Function from file: medbot.dm
		public override dynamic bullet_act( dynamic P = null, dynamic def_zone = null ) {
			
			if ( P.flag == "taser" ) {
				this.stunned = Num13.MinInt( ((int)( this.stunned + 10 )), 20 );
			}
			base.bullet_act( (object)(P), (object)(def_zone) );
			return null;
		}

		// Function from file: medbot.dm
		public override void UnarmedAttack( Ent_Static A = null, bool? proximity_flag = null ) {
			Ent_Static C = null;

			
			if ( A is Mob_Living_Carbon ) {
				C = A;
				this.patient = C;
				this.v_mode = 10;
				this.update_icon();
				this.medicate_patient( C );
				this.update_icon();
			} else {
				base.UnarmedAttack( A, proximity_flag );
			}
			return;
		}

		// Function from file: medbot.dm
		public override bool handle_automated_action(  ) {
			string message = null;
			int? scan_range = null;

			
			if ( !base.handle_automated_action() ) {
				return false;
			}

			if ( this.v_mode == 10 ) {
				return false;
			}

			if ( this.stunned != 0 ) {
				this.icon_state = "medibota";
				this.stunned--;
				this.oldpatient = this.patient;
				this.patient = null;
				this.v_mode = 0;

				if ( this.stunned <= 0 ) {
					this.update_icon();
					this.stunned = 0;
				}
				return false;
			}

			if ( this.frustration > 8 ) {
				this.oldpatient = this.patient;
				this.soft_reset();
			}

			if ( !Lang13.Bool( this.patient ) ) {
				
				if ( !this.shut_up && Rand13.PercentChance( 1 ) ) {
					message = Rand13.Pick(new object [] { "Radar, put a mask on!", "There's always a catch, and it's the best there is.", "I knew it, I should've been a plastic surgeon.", "What kind of medbay is this? Everyone's dropping like dead flies.", "Delicious!" });
					this.f_speak( message );
				}
				scan_range = ( this.stationary_mode ? 1 : 7 );
				this.patient = this.scan( typeof(Mob_Living_Carbon_Human), this.oldpatient, scan_range );
				this.oldpatient = this.patient;
			}

			if ( Lang13.Bool( this.patient ) && Map13.GetDistance( this, this.patient ) <= 1 ) {
				
				if ( this.v_mode != 10 ) {
					this.v_mode = 10;
					this.update_icon();
					this.frustration = 0;
					this.medicate_patient( this.patient );
				}
				return false;
			} else if ( Lang13.Bool( this.patient ) && this.path.len != 0 && Map13.GetDistance( this.patient, this.path[this.path.len] ) > 2 ) {
				this.path = new ByTable();
				this.v_mode = 0;
				this.last_found = Game13.time;
			} else if ( this.stationary_mode && Lang13.Bool( this.patient ) ) {
				this.soft_reset();
				return false;
			}

			if ( Lang13.Bool( this.patient ) && this.path.len == 0 && Map13.GetDistance( this, this.patient ) > 1 ) {
				this.path = GlobalFuncs.get_path_to( this, GlobalFuncs.get_turf( this.patient ), typeof(Tile).GetMethod( "Distance_cardinal" ), false, 30, null, null, this.access_card );
				this.v_mode = 9;

				if ( !( this.path.len != 0 ) ) {
					this.path = GlobalFuncs.get_path_to( this, GlobalFuncs.get_turf( this.patient ), typeof(Tile).GetMethod( "Distance_cardinal" ), false, 30, true, null, this.access_card );

					if ( !( this.path.len != 0 ) ) {
						this.soft_reset();
					}
				}
			}

			if ( this.path.len > 0 && Lang13.Bool( this.patient ) ) {
				
				if ( !this.bot_move( this.path[this.path.len] ) ) {
					this.oldpatient = this.patient;
					this.soft_reset();
				}
				return false;
			}

			if ( this.path.len > 8 && Lang13.Bool( this.patient ) ) {
				this.frustration++;
			}

			if ( this.auto_patrol && !this.stationary_mode && !Lang13.Bool( this.patient ) ) {
				
				if ( this.v_mode == 0 || this.v_mode == 4 ) {
					this.start_patrol();
				}

				if ( this.v_mode == 5 ) {
					this.bot_patrol();
				}
			}
			return false;
		}

		// Function from file: medbot.dm
		public override dynamic process_scan( dynamic scan_target = null ) {
			string message = null;

			
			if ( Convert.ToInt32( scan_target.stat ) == 2 ) {
				return null;
			}

			if ( scan_target == this.oldpatient && Game13.time < this.last_found + 200 ) {
				return null;
			}

			if ( this.assess_patient( scan_target ) ) {
				this.last_found = Game13.time;

				if ( this.last_newpatient_speak + 300 < Game13.time ) {
					message = Rand13.Pick(new object [] { "Hey, " + scan_target.name + "! Hold on, I'm coming.", "Wait " + scan_target.name + "! I want to help!", "" + scan_target.name + ", you appear to be injured!" });
					this.f_speak( message );
					this.last_newpatient_speak = Game13.time;
				}
				return scan_target;
			} else {
				return null;
			}
		}

		// Function from file: medbot.dm
		public override bool emag_act( dynamic user = null ) {
			base.emag_act( (object)(user) );

			if ( this.emagged == 2 ) {
				this.declare_crit = false;

				if ( Lang13.Bool( user ) ) {
					user.WriteMsg( "<span class='notice'>You short out " + this + "'s reagent synthesis circuits.</span>" );
				}
				this.audible_message( "<span class='danger'>" + this + " buzzes oddly!</span>" );
				Icon13.Flick( "medibot_spark", this );

				if ( Lang13.Bool( user ) ) {
					this.oldpatient = user;
				}
			}
			return false;
		}

		// Function from file: medbot.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic current_health = null;

			
			if ( A is Obj_Item_Weapon_ReagentContainers_Glass ) {
				
				if ( this.locked ) {
					user.WriteMsg( "<span class='warning'>You cannot insert a beaker because the panel is locked!</span>" );
					return null;
				}

				if ( !( this.reagent_glass == null ) ) {
					user.WriteMsg( "<span class='warning'>There is already a beaker loaded!</span>" );
					return null;
				}

				if ( !Lang13.Bool( user.drop_item() ) ) {
					return null;
				}
				A.loc = this;
				this.reagent_glass = A;
				user.WriteMsg( "<span class='notice'>You insert " + A + ".</span>" );
				this.show_controls( user );
				return null;
			} else {
				current_health = this.health;
				base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

				if ( Convert.ToDouble( this.health ) < Convert.ToDouble( current_health ) ) {
					Map13.StepTowards( this, Map13.GetStepAway( this, user, null ), 0 );
				}
			}
			return null;
		}

		// Function from file: medbot.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			double? adjust_num = null;
			double? adjust_num2 = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hsrc) ) ) ) {
				return 1;
			}

			if ( Lang13.Bool( href_list["adj_threshold"] ) ) {
				adjust_num = String13.ParseNumber( href_list["adj_threshold"] );
				this.heal_threshold += adjust_num ??0;

				if ( this.heal_threshold < 5 ) {
					this.heal_threshold = 5;
				}

				if ( this.heal_threshold > 75 ) {
					this.heal_threshold = 75;
				}
			} else if ( Lang13.Bool( href_list["adj_inject"] ) ) {
				adjust_num2 = String13.ParseNumber( href_list["adj_inject"] );
				this.injection_amount += adjust_num2 ??0;

				if ( ( this.injection_amount ??0) < 5 ) {
					this.injection_amount = 5;
				}

				if ( ( this.injection_amount ??0) > 15 ) {
					this.injection_amount = 15;
				}
			} else if ( Lang13.Bool( href_list["use_beaker"] ) ) {
				this.use_beaker = !this.use_beaker;
			} else if ( Lang13.Bool( href_list["eject"] ) && !( this.reagent_glass == null ) ) {
				this.reagent_glass.loc = GlobalFuncs.get_turf( this );
				this.reagent_glass = null;
			} else if ( Lang13.Bool( href_list["togglevoice"] ) ) {
				this.shut_up = !this.shut_up;
			} else if ( Lang13.Bool( href_list["critalerts"] ) ) {
				this.declare_crit = !this.declare_crit;
			} else if ( Lang13.Bool( href_list["stationary"] ) ) {
				this.stationary_mode = !this.stationary_mode;
				this.path = new ByTable();
				this.update_icon();
			} else if ( Lang13.Bool( href_list["virus"] ) ) {
				this.treat_virus = !this.treat_virus;
			}
			this.update_controls();
			return null;
		}

		// Function from file: medbot.dm
		public override string get_controls( dynamic M = null ) {
			dynamic dat = null;

			dat += this.hack( M );
			dat += this.showpai( M );
			dat += "<TT><B>Medical Unit Controls v1.1</B></TT><BR><BR>";
			dat += new Txt( "Status: <A href='?src=" ).Ref( this ).str( ";power=1'>" ).item( ( Lang13.Bool( this.on ) ? "On" : "Off" ) ).str( "</A><BR>" ).ToString();
			dat += "Maintenance panel panel is " + ( this.open ? "opened" : "closed" ) + "<BR>";
			dat += "Beaker: ";

			if ( Lang13.Bool( this.reagent_glass ) ) {
				dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";eject=1'>Loaded [" ).item( this.reagent_glass.reagents.total_volume ).str( "/" ).item( this.reagent_glass.reagents.maximum_volume ).str( "]</a>" ).ToString();
			} else {
				dat += "None Loaded";
			}
			dat += "<br>Behaviour controls are " + ( this.locked ? "locked" : "unlocked" ) + "<hr>";

			if ( !this.locked || M is Mob_Living_Silicon || Lang13.Bool( GlobalFuncs.IsAdminGhost( M ) ) ) {
				dat += "<TT>Healing Threshold: ";
				dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";adj_threshold=-10'>--</a> " ).ToString();
				dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";adj_threshold=-5'>-</a> " ).ToString();
				dat += "" + this.heal_threshold + " ";
				dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";adj_threshold=5'>+</a> " ).ToString();
				dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";adj_threshold=10'>++</a>" ).ToString();
				dat += "</TT><br>";
				dat += "<TT>Injection Level: ";
				dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";adj_inject=-5'>-</a> " ).ToString();
				dat += "" + this.injection_amount + " ";
				dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";adj_inject=5'>+</a> " ).ToString();
				dat += "</TT><br>";
				dat += "Reagent Source: ";
				dat += new Txt( "<a href='?src=" ).Ref( this ).str( ";use_beaker=1'>" ).item( ( this.use_beaker ? "Loaded Beaker (When available)" : "Internal Synthesizer" ) ).str( "</a><br>" ).ToString();
				dat += new Txt( "Treat Viral Infections: <a href='?src=" ).Ref( this ).str( ";virus=1'>" ).item( ( this.treat_virus ? "Yes" : "No" ) ).str( "</a><br>" ).ToString();
				dat += new Txt( "The speaker switch is " ).item( ( this.shut_up ? "off" : "on" ) ).str( ". <a href='?src=" ).Ref( this ).str( ";togglevoice=" ).item( 1 ).str( "'>Toggle</a><br>" ).ToString();
				dat += new Txt( "Critical Patient Alerts: <a href='?src=" ).Ref( this ).str( ";critalerts=1'>" ).item( ( this.declare_crit ? "Yes" : "No" ) ).str( "</a><br>" ).ToString();
				dat += new Txt( "Patrol Station: <a href='?src=" ).Ref( this ).str( ";operation=patrol'>" ).item( ( this.auto_patrol ? "Yes" : "No" ) ).str( "</a><br>" ).ToString();
				dat += new Txt( "Stationary Mode: <a href='?src=" ).Ref( this ).str( ";stationary=1'>" ).item( ( this.stationary_mode ? "Yes" : "No" ) ).str( "</a><br>" ).ToString();
			}
			return dat;
		}

		// Function from file: medbot.dm
		public override dynamic attack_paw( dynamic a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

		// Function from file: medbot.dm
		public override void set_custom_texts(  ) {
			this.text_hack = "You corrupt " + this.name + "'s reagent processor circuits.";
			this.text_dehack = "You reset " + this.name + "'s reagent processor circuits.";
			this.text_dehack_fail = "" + this.name + " seems damaged and does not respond to reprogramming!";
			return;
		}

		// Function from file: medbot.dm
		public void declare( dynamic crit_patient = null ) {
			dynamic location = null;

			
			if ( this.declare_cooldown ) {
				return;
			}
			location = GlobalFuncs.get_area( this );
			this.f_speak( "Medical emergency! " + ( Lang13.Bool( crit_patient ) ? "<b>" + crit_patient + "</b>" : "A patient" ) + " is in critical condition at " + location + "!", this.radio_channel );
			this.declare_cooldown = true;
			Task13.Schedule( 200, (Task13.Closure)(() => {
				this.declare_cooldown = false;
				return;
			}));
			return;
		}

		// Function from file: medbot.dm
		public bool check_overdose( dynamic patient = null, string reagent_id = null, double? injection_amount = null ) {
			Reagent R = null;
			bool current_volume = false;

			R = GlobalVars.chemical_reagents_list[reagent_id];
			current_volume = ((Reagents)patient.reagents).get_reagent_amount( reagent_id );

			if ( ( current_volume ?1:0) + ( injection_amount ??0) > R.overdose_threshold ) {
				return true;
			}
			return false;
		}

		// Function from file: medbot.dm
		public void medicate_patient( dynamic C = null ) {
			string death_message = null;
			string reagent_id = null;
			bool virus = false;
			Disease D = null;
			Reagent R = null;
			string message = null;
			double? fraction = null;

			
			if ( !Lang13.Bool( this.on ) ) {
				return;
			}

			if ( !( C is Mob_Living_Carbon ) ) {
				this.oldpatient = this.patient;
				this.soft_reset();
				return;
			}

			if ( Convert.ToInt32( C.stat ) == 2 ) {
				death_message = Rand13.Pick(new object [] { "No! NO!", "Live, damnit! LIVE!", "I...I've never lost a patient before. Not today, I mean." });
				this.f_speak( death_message );
				this.oldpatient = this.patient;
				this.soft_reset();
				return;
			}
			reagent_id = null;

			if ( this.emagged == 2 ) {
				reagent_id = "toxin";
			} else {
				
				if ( this.treat_virus ) {
					virus = false;

					foreach (dynamic _a in Lang13.Enumerate( C.viruses, typeof(Disease) )) {
						D = _a;
						

						if ( !( ( D.visibility_flags & 1 ) != 0 ) || !( ( D.visibility_flags & 2 ) != 0 ) ) {
							
							if ( D.severity != "No threat" ) {
								
								if ( ( D.stage ??0) > 1 || ( D.spread_flags & 64 ) != 0 ) {
									virus = true;
								}
							}
						}
					}

					if ( !Lang13.Bool( reagent_id ) && virus ) {
						
						if ( !Lang13.Bool( ((Reagents)C.reagents).has_reagent( this.treatment_virus ) ) ) {
							reagent_id = this.treatment_virus;
						}
					}
				}

				if ( !Lang13.Bool( reagent_id ) && ((Mob_Living)C).getBruteLoss() >= this.heal_threshold ) {
					
					if ( !Lang13.Bool( ((Reagents)C.reagents).has_reagent( this.treatment_brute ) ) ) {
						reagent_id = this.treatment_brute;
					}
				}

				if ( !Lang13.Bool( reagent_id ) && Convert.ToDouble( ((Mob_Living)C).getOxyLoss() ) >= this.heal_threshold + 15 ) {
					
					if ( !Lang13.Bool( ((Reagents)C.reagents).has_reagent( this.treatment_oxy ) ) ) {
						reagent_id = this.treatment_oxy;
					}
				}

				if ( !Lang13.Bool( reagent_id ) && ((Mob_Living)C).getFireLoss() >= this.heal_threshold ) {
					
					if ( !Lang13.Bool( ((Reagents)C.reagents).has_reagent( this.treatment_fire ) ) ) {
						reagent_id = this.treatment_fire;
					}
				}

				if ( !Lang13.Bool( reagent_id ) && Convert.ToDouble( ((Mob_Living)C).getToxLoss() ) >= this.heal_threshold ) {
					
					if ( !Lang13.Bool( ((Reagents)C.reagents).has_reagent( this.treatment_tox ) ) ) {
						reagent_id = this.treatment_tox;
					}
				}

				if ( Lang13.Bool( reagent_id ) && this.use_beaker && Lang13.Bool( this.reagent_glass ) && Lang13.Bool( this.reagent_glass.reagents.total_volume ) ) {
					
					foreach (dynamic _b in Lang13.Enumerate( this.reagent_glass.reagents.reagent_list, typeof(Reagent) )) {
						R = _b;
						

						if ( !Lang13.Bool( ((Reagents)C.reagents).has_reagent( R.id ) ) ) {
							reagent_id = "internal_beaker";
							break;
						}
					}
				}
			}

			if ( !Lang13.Bool( reagent_id ) ) {
				message = Rand13.Pick(new object [] { "All patched up!", "An apple a day keeps me away.", "Feel better soon!" });
				this.f_speak( message );
				this.bot_reset();
				return;
			} else {
				
				if ( !( this.emagged != 0 ) && this.check_overdose( this.patient, reagent_id, this.injection_amount ) ) {
					this.soft_reset();
					return;
				}
				((Ent_Static)C).visible_message( "<span class='danger'>" + this + " is trying to inject " + this.patient + "!</span>", "<span class='userdanger'>" + this + " is trying to inject you!</span>" );
				Task13.Schedule( 30, (Task13.Closure)(() => {
					
					if ( Map13.GetDistance( this, this.patient ) <= 1 && Lang13.Bool( this.on ) && this.assess_patient( this.patient ) ) {
						
						if ( reagent_id == "internal_beaker" ) {
							
							if ( this.use_beaker && Lang13.Bool( this.reagent_glass ) && Lang13.Bool( this.reagent_glass.reagents.total_volume ) ) {
								fraction = Num13.MinInt( ((int)( ( this.injection_amount ??0) / ( this.reagent_glass.reagents.total_volume ??0) )), 1 );
								((Reagents)this.reagent_glass.reagents).reaction( this.patient, GlobalVars.INJECT, fraction );
								((Reagents)this.reagent_glass.reagents).trans_to( this.patient, this.injection_amount );
							}
						} else {
							this.patient.reagents.add_reagent( reagent_id, this.injection_amount );
						}
						((Ent_Static)C).visible_message( "<span class='danger'>" + this + " injects " + this.patient + " with its syringe!</span>", "<span class='userdanger'>" + this + " injects you with its syringe!</span>" );
					} else {
						this.visible_message( "" + this + " retracts its syringe." );
					}
					this.update_icon();
					this.soft_reset();
					return;
					return;
				}));
			}
			reagent_id = null;
			return;
		}

		// Function from file: medbot.dm
		public bool assess_patient( dynamic C = null ) {
			Reagent R = null;
			Disease D = null;

			
			if ( Convert.ToInt32( C.stat ) == 2 ) {
				return false;
			}

			if ( Lang13.Bool( C.suiciding ) ) {
				return false;
			}

			if ( this.emagged == 2 ) {
				return true;
			}

			if ( this.declare_crit && Convert.ToDouble( C.health ) <= 0 ) {
				this.declare( C );
			}

			if ( Lang13.Bool( this.reagent_glass ) && this.use_beaker && ( ((Mob_Living)C).getBruteLoss() >= this.heal_threshold || Convert.ToDouble( ((Mob_Living)C).getToxLoss() ) >= this.heal_threshold || Convert.ToDouble( ((Mob_Living)C).getToxLoss() ) >= this.heal_threshold || Convert.ToDouble( ((Mob_Living)C).getOxyLoss() ) >= this.heal_threshold + 15 ) ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.reagent_glass.reagents.reagent_list, typeof(Reagent) )) {
					R = _a;
					

					if ( !Lang13.Bool( ((Reagents)C.reagents).has_reagent( R.id ) ) ) {
						return true;
					}
				}
			}

			if ( ((Mob_Living)C).getBruteLoss() >= this.heal_threshold && !Lang13.Bool( ((Reagents)C.reagents).has_reagent( this.treatment_brute ) ) ) {
				return true;
			}

			if ( Convert.ToDouble( ((Mob_Living)C).getOxyLoss() ) >= this.heal_threshold + 15 && !Lang13.Bool( ((Reagents)C.reagents).has_reagent( this.treatment_oxy ) ) ) {
				return true;
			}

			if ( ((Mob_Living)C).getFireLoss() >= this.heal_threshold && !Lang13.Bool( ((Reagents)C.reagents).has_reagent( this.treatment_fire ) ) ) {
				return true;
			}

			if ( Convert.ToDouble( ((Mob_Living)C).getToxLoss() ) >= this.heal_threshold && !Lang13.Bool( ((Reagents)C.reagents).has_reagent( this.treatment_tox ) ) ) {
				return true;
			}

			if ( this.treat_virus ) {
				
				foreach (dynamic _b in Lang13.Enumerate( C.viruses, typeof(Disease) )) {
					D = _b;
					

					if ( ( D.visibility_flags & 1 ) != 0 || ( D.visibility_flags & 2 ) != 0 ) {
						return false;
					}

					if ( D.severity == "No threat" ) {
						return false;
					}

					if ( ( D.stage ??0) > 1 || ( D.spread_flags & 64 ) != 0 ) {
						
						if ( !Lang13.Bool( ((Reagents)C.reagents).has_reagent( this.treatment_virus ) ) ) {
							return true;
						}
					}
				}
			}
			return false;
		}

		// Function from file: medbot.dm
		public void soft_reset(  ) {
			this.path = new ByTable();
			this.patient = null;
			this.v_mode = 0;
			this.last_found = Game13.time;
			this.update_icon();
			return;
		}

		// Function from file: medbot.dm
		public override void bot_reset(  ) {
			base.bot_reset();
			this.patient = null;
			this.oldpatient = null;
			this.oldloc = null;
			this.last_found = Game13.time;
			this.declare_cooldown = false;
			this.update_icon();
			return;
		}

		// Function from file: medbot.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			
			if ( !Lang13.Bool( this.on ) ) {
				this.icon_state = "medibot0";
				return false;
			}

			if ( this.v_mode == 10 ) {
				this.icon_state = "medibots" + this.stationary_mode;
				return false;
			} else if ( this.stationary_mode ) {
				this.icon_state = "medibot2";
			} else {
				this.icon_state = "medibot1";
			}
			return false;
		}

		// Function from file: medbot.dm
		[Verb]
		[VerbInfo( name: "Examine", group: "IC" )]
		[VerbArg( 1, InputType.Mob | InputType.Obj | InputType.Tile )]
		public override void examinate( Ent_Static A = null ) {
			Lang13.SuperCall( A );

			if ( !( GlobalFuncs.is_blind( this ) != 0 ) ) {
				GlobalFuncs.chemscan( this, A );
			}
			return;
		}

	}

}