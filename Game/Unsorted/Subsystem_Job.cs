// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Subsystem_Job : Subsystem {

		public ByTable occupations = new ByTable();
		public dynamic unassigned = new ByTable();
		public ByTable job_debug = new ByTable();
		public int initial_players_to_assign = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Jobs";
			this.priority = 5;
		}

		// Function from file: jobs.dm
		public Subsystem_Job (  ) {
			
			if ( GlobalVars.SSjob != this ) {
				
				if ( GlobalVars.SSjob is Subsystem_Job ) {
					this.Recover();
					GlobalFuncs.qdel( GlobalVars.SSjob );
				}
				GlobalVars.SSjob = this;
			}
			return;
		}

		// Function from file: jobs.dm
		public void RejectPlayer( Mob_NewPlayer player = null ) {
			
			if ( player.mind != null && Lang13.Bool( player.mind.special_role ) ) {
				return;
			}
			this.Debug( "Popcap overflow Check observer located, Player: " + player );
			player.WriteMsg( "<b>You have failed to qualify for any job you desired.</b>" );
			this.unassigned -= player;
			player.ready = 0;
			return;
		}

		// Function from file: jobs.dm
		public bool PopcapReached(  ) {
			int relevent_cap = 0;

			
			if ( Lang13.Bool( GlobalVars.config.hard_popcap ) || Lang13.Bool( GlobalVars.config.extreme_popcap ) ) {
				relevent_cap = Num13.MaxInt( ((int)( GlobalVars.config.hard_popcap ??0 )), ((int)( GlobalVars.config.extreme_popcap ??0 )) );

				if ( this.initial_players_to_assign - this.unassigned.len >= relevent_cap ) {
					return true;
				}
			}
			return false;
		}

		// Function from file: jobs.dm
		public void HandleFeedbackGathering(  ) {
			Job job = null;
			string tmp_str = null;
			int level1 = 0;
			int level2 = 0;
			int level3 = 0;
			int level4 = 0;
			int level5 = 0;
			int level6 = 0;
			Mob_NewPlayer player = null;

			
			foreach (dynamic _b in Lang13.Enumerate( this.occupations, typeof(Job) )) {
				job = _b;
				
				tmp_str = "|" + job.title + "|";
				level1 = 0;
				level2 = 0;
				level3 = 0;
				level4 = 0;
				level5 = 0;
				level6 = 0;

				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_NewPlayer) )) {
					player = _a;
					

					if ( !( Lang13.Bool( player.ready ) && player.mind != null && !Lang13.Bool( player.mind.assigned_role ) ) ) {
						continue;
					}

					if ( GlobalFuncs.jobban_isbanned( player, job.title ) ) {
						level5++;
						continue;
					}

					if ( !job.player_old_enough( player.client ) ) {
						level6++;
						continue;
					}

					if ( Lang13.Bool( player.client.prefs.GetJobDepartment( job, 1 ) & job.flag ) ) {
						level1++;
					} else if ( Lang13.Bool( player.client.prefs.GetJobDepartment( job, 2 ) & job.flag ) ) {
						level2++;
					} else if ( Lang13.Bool( player.client.prefs.GetJobDepartment( job, 3 ) & job.flag ) ) {
						level3++;
					} else {
						level4++;
					}
				}
				tmp_str += "HIGH=" + level1 + "|MEDIUM=" + level2 + "|LOW=" + level3 + "|NEVER=" + level4 + "|BANNED=" + level5 + "|YOUNG=" + level6 + "|-";
				GlobalFuncs.feedback_add_details( "job_preferences", tmp_str );
			}
			return;
		}

		// Function from file: jobs.dm
		public void LoadJobs(  ) {
			string jobstext = null;
			Job J = null;
			Regex jobs = null;

			jobstext = GlobalFuncs.return_file_text( "config/jobs.txt" );

			foreach (dynamic _a in Lang13.Enumerate( this.occupations, typeof(Job) )) {
				J = _a;
				
				jobs = new Regex( "" + J.title + "=(-1|\\d+),(-1|\\d+)" );
				jobs.Find( jobstext );
				J.total_positions = String13.ParseNumber( jobs.group[2] );
				J.spawn_positions = String13.ParseNumber( jobs.group[3] );
			}
			return;
		}

		// Function from file: jobs.dm
		public void setup_officer_positions(  ) {
			Job J = null;
			int officer_positions = 0;
			dynamic equip_needed = null;
			dynamic i = null;
			dynamic spawnloc = null;

			J = GlobalVars.SSjob.GetJob( "Security Officer" );

			if ( !( J != null ) ) {
				throw new Exception( "setup_officer_positions(): Security officer job is missing" );
			}

			if ( ( GlobalVars.config.security_scaling_coeff ??0) > 0 ) {
				
				if ( ( J.spawn_positions ??0) > 0 ) {
					officer_positions = Num13.MinInt( 12, Num13.MaxInt( ((int)( J.spawn_positions ??0 )), Num13.Floor( this.unassigned.len / ( GlobalVars.config.security_scaling_coeff ??0) ) ) );
					this.Debug( "Setting open security officer positions to " + officer_positions );
					J.total_positions = officer_positions;
					J.spawn_positions = officer_positions;
				}
			}
			equip_needed = J.total_positions;

			if ( Convert.ToDouble( equip_needed ) < 0 ) {
				equip_needed = 12;
			}
			i = null;
			i = equip_needed - 5;

			while (Convert.ToDouble( i ) > 0) {
				
				if ( GlobalVars.secequipment.len != 0 ) {
					spawnloc = GlobalVars.secequipment[1];
					new Obj_Structure_Closet_SecureCloset_Security( spawnloc );
					GlobalVars.secequipment.Remove( spawnloc );
				} else {
					break;
				}
				i--;
			}
			return;
		}

		// Function from file: jobs.dm
		public bool EquipRank( dynamic H = null, dynamic rank = null, bool? joined_late = null ) {
			joined_late = joined_late ?? false;

			Job job = null;
			dynamic S = null;
			Obj_Effect_Landmark_Start sloc = null;
			dynamic T = null;
			bool clear = false;
			Obj O = null;
			dynamic new_mob = null;

			job = this.GetJob( rank );
			H.job = rank;

			if ( !( joined_late == true ) ) {
				S = null;

				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.start_landmarks_list, typeof(Obj_Effect_Landmark_Start) )) {
					sloc = _a;
					

					if ( sloc.name != rank ) {
						S = sloc;
						continue;
					}

					if ( Lang13.Bool( Lang13.FindIn( typeof(Mob_Living), sloc.loc ) ) ) {
						continue;
					}
					S = sloc;
					break;
				}

				if ( !Lang13.Bool( S ) ) {
					Game13.log.WriteMsg( "Couldn't find a round start spawn point for " + rank );
					S = Rand13.PickFromTable( GlobalVars.latejoin );
				}

				if ( !Lang13.Bool( S ) ) {
					Game13.log.WriteMsg( "Couldn't find a round start latejoin spawn point." );

					foreach (dynamic _c in Lang13.Enumerate( GlobalFuncs.get_area_turfs( typeof(Zone_Shuttle_Arrival) ) )) {
						T = _c;
						

						if ( !T.density ) {
							clear = true;

							foreach (dynamic _b in Lang13.Enumerate( T, typeof(Obj) )) {
								O = _b;
								

								if ( O.density ) {
									clear = false;
									break;
								}
							}

							if ( clear ) {
								S = T;
								continue;
							}
						}
					}
				}

				if ( S is Obj_Effect_Landmark && S.loc is Tile ) {
					H.loc = S.loc;
				}
			}

			if ( Lang13.Bool( H.mind ) ) {
				H.mind.assigned_role = rank;
			}

			if ( job != null ) {
				new_mob = job.equip( H );

				if ( new_mob is Mob ) {
					H = new_mob;
				}
				job.apply_fingerprints( H );
			}
			H.WriteMsg( "<b>You are the " + rank + ".</b>" );
			H.WriteMsg( "<b>As the " + rank + " you answer directly to " + job.supervisors + ". Special circumstances may change this.</b>" );
			H.WriteMsg( "<b>To speak on your departments radio, use the :h button. To see others, look closely at your headset.</b>" );

			if ( job.req_admin_notify ) {
				H.WriteMsg( "<b>You are playing a job that is important for Game Progression. If you have to disconnect, please notify the admins via adminhelp.</b>" );
			}

			if ( Lang13.Bool( GlobalVars.config.minimal_access_threshold ) ) {
				H.WriteMsg( "<FONT color='blue'><B>As this station was initially staffed with a " + ( GlobalVars.config.jobs_have_minimal_access ? "full crew, only your job's necessities" : "skeleton crew, additional access may" ) + " have been added to your ID card.</B></font>" );
			}
			return true;
		}

		// Function from file: jobs.dm
		public bool DivideOccupations(  ) {
			Job_Ai A = null;
			Mob_NewPlayer player = null;
			Job_Assistant assist = null;
			ByTable assistant_candidates = null;
			Mob_NewPlayer player2 = null;
			dynamic shuffledoccupations = null;
			double level = 0;
			Mob_NewPlayer player3 = null;
			Job job = null;
			Mob_NewPlayer player4 = null;
			Mob_NewPlayer player5 = null;
			Mob_NewPlayer player6 = null;

			this.Debug( "Running DO" );

			if ( GlobalVars.ticker != null ) {
				
				foreach (dynamic _a in Lang13.Enumerate( this.occupations, typeof(Job_Ai) )) {
					A = _a;
					

					if ( GlobalVars.ticker.triai ) {
						A.spawn_positions = 3;
					}
				}
			}

			foreach (dynamic _b in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_NewPlayer) )) {
				player = _b;
				

				if ( Lang13.Bool( player.ready ) && player.mind != null && !Lang13.Bool( player.mind.assigned_role ) ) {
					this.unassigned += player;
				}
			}
			this.initial_players_to_assign = this.unassigned.len;
			this.Debug( "DO, Len: " + this.unassigned.len );

			if ( this.unassigned.len == 0 ) {
				return false;
			}
			this.setup_officer_positions();

			if ( Lang13.Bool( GlobalVars.config.minimal_access_threshold ) ) {
				
				if ( ( GlobalVars.config.minimal_access_threshold ??0) > this.unassigned.len ) {
					GlobalVars.config.jobs_have_minimal_access = false;
				} else {
					GlobalVars.config.jobs_have_minimal_access = true;
				}
			}
			this.unassigned = GlobalFuncs.shuffle( this.unassigned );
			this.HandleFeedbackGathering();
			this.Debug( "DO, Running Assistant Check 1" );
			assist = new Job_Assistant();
			assistant_candidates = this.FindOccupationCandidates( assist, 3 );
			this.Debug( "AC1, Candidates: " + assistant_candidates.len );

			foreach (dynamic _c in Lang13.Enumerate( assistant_candidates, typeof(Mob_NewPlayer) )) {
				player2 = _c;
				
				this.Debug( "AC1 pass, Player: " + player2 );
				this.AssignRole( player2, "Assistant" );
				assistant_candidates.Remove( player2 );
			}
			this.Debug( "DO, AC1 end" );
			this.Debug( "DO, Running Head Check" );
			this.FillHeadPosition();
			this.Debug( "DO, Head Check end" );
			this.Debug( "DO, Running AI Check" );
			this.FillAIPosition();
			this.Debug( "DO, AI Check end" );
			this.Debug( "DO, Running Standard Check" );
			shuffledoccupations = GlobalFuncs.shuffle( this.occupations );

			foreach (dynamic _f in Lang13.IterateRange( 1, 3 )) {
				level = _f;
				
				this.CheckHeadPositions( level );

				foreach (dynamic _e in Lang13.Enumerate( this.unassigned, typeof(Mob_NewPlayer) )) {
					player3 = _e;
					

					if ( this.PopcapReached() ) {
						this.RejectPlayer( player3 );
					}

					foreach (dynamic _d in Lang13.Enumerate( shuffledoccupations, typeof(Job) )) {
						job = _d;
						

						if ( !( job != null ) ) {
							continue;
						}

						if ( GlobalFuncs.jobban_isbanned( player3, job.title ) ) {
							this.Debug( "DO isbanned failed, Player: " + player3 + ", Job:" + job.title );
							continue;
						}

						if ( !job.player_old_enough( player3.client ) ) {
							this.Debug( "DO player not old enough, Player: " + player3 + ", Job:" + job.title );
							continue;
						}

						if ( player3.mind.restricted_roles.Contains( player3.mind != null && Lang13.Bool( job.title ) ) ) {
							this.Debug( "DO incompatible with antagonist role, Player: " + player3 + ", Job:" + job.title );
							continue;
						}

						if ( GlobalVars.config.enforce_human_authority && !((Species)player3.client.prefs.pref_species).qualifies_for_rank( job.title, player3.client.prefs.features ) ) {
							this.Debug( "DO non-human failed, Player: " + player3 + ", Job:" + job.title );
							continue;
						}

						if ( Lang13.Bool( player3.client.prefs.GetJobDepartment( job, level ) & job.flag ) ) {
							
							if ( ( job.current_positions ??0) < ( job.spawn_positions ??0) || job.spawn_positions == -1 ) {
								this.Debug( "DO pass, Player: " + player3 + ", Level:" + level + ", Job:" + job.title );
								this.AssignRole( player3, job.title );
								this.unassigned -= player3;
								break;
							}
						}
					}
				}
			}

			foreach (dynamic _g in Lang13.Enumerate( this.unassigned, typeof(Mob_NewPlayer) )) {
				player4 = _g;
				

				if ( this.PopcapReached() ) {
					this.RejectPlayer( player4 );
				} else if ( GlobalFuncs.jobban_isbanned( player4, "Assistant" ) ) {
					this.GiveRandomJob( player4 );
				}
			}

			foreach (dynamic _h in Lang13.Enumerate( this.unassigned, typeof(Mob_NewPlayer) )) {
				player5 = _h;
				

				if ( this.PopcapReached() ) {
					this.RejectPlayer( player5 );
				} else if ( Lang13.Bool( player5.client.prefs.userandomjob ) ) {
					this.GiveRandomJob( player5 );
				}
			}
			this.Debug( "DO, Standard Check end" );
			this.Debug( "DO, Running AC2" );

			foreach (dynamic _i in Lang13.Enumerate( this.unassigned, typeof(Mob_NewPlayer) )) {
				player6 = _i;
				

				if ( this.PopcapReached() ) {
					this.RejectPlayer( player6 );
				}
				this.Debug( "AC2 Assistant located, Player: " + player6 );
				this.AssignRole( player6, "Assistant" );
			}
			return true;
		}

		// Function from file: jobs.dm
		public bool FillAIPosition(  ) {
			int ai_selected = 0;
			Job job = null;
			dynamic i = null;
			double level = 0;
			ByTable candidates = null;
			dynamic candidate = null;

			ai_selected = 0;
			job = this.GetJob( "AI" );

			if ( !( job != null ) ) {
				return false;
			}
			i = null;
			i = job.total_positions;

			while (Convert.ToDouble( i ) > 0) {
				
				foreach (dynamic _a in Lang13.IterateRange( 1, 3 )) {
					level = _a;
					
					candidates = new ByTable();
					candidates = this.FindOccupationCandidates( job, level );

					if ( candidates.len != 0 ) {
						candidate = Rand13.PickFromTable( candidates );

						if ( this.AssignRole( candidate, "AI" ) ) {
							ai_selected++;
							break;
						}
					}
				}
				i--;
			}

			if ( ai_selected != 0 ) {
				return true;
			}
			return false;
		}

		// Function from file: jobs.dm
		public void CheckHeadPositions( double level = 0 ) {
			dynamic command_position = null;
			Job job = null;
			ByTable candidates = null;
			dynamic candidate = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.command_positions )) {
				command_position = _a;
				
				job = this.GetJob( command_position );

				if ( !( job != null ) ) {
					continue;
				}

				if ( ( job.current_positions ??0) >= Convert.ToDouble( job.total_positions ) && job.total_positions != -1 ) {
					continue;
				}
				candidates = this.FindOccupationCandidates( job, level );

				if ( !( candidates.len != 0 ) ) {
					continue;
				}
				candidate = Rand13.PickFromTable( candidates );
				this.AssignRole( candidate, command_position );
			}
			return;
		}

		// Function from file: jobs.dm
		public bool FillHeadPosition(  ) {
			double level = 0;
			dynamic command_position = null;
			Job job = null;
			ByTable candidates = null;
			dynamic candidate = null;

			
			foreach (dynamic _b in Lang13.IterateRange( 1, 3 )) {
				level = _b;
				

				foreach (dynamic _a in Lang13.Enumerate( GlobalVars.command_positions )) {
					command_position = _a;
					
					job = this.GetJob( command_position );

					if ( !( job != null ) ) {
						continue;
					}

					if ( ( job.current_positions ??0) >= Convert.ToDouble( job.total_positions ) && job.total_positions != -1 ) {
						continue;
					}
					candidates = this.FindOccupationCandidates( job, level );

					if ( !( candidates.len != 0 ) ) {
						continue;
					}
					candidate = Rand13.PickFromTable( candidates );

					if ( this.AssignRole( candidate, command_position ) ) {
						return true;
					}
				}
			}
			return false;
		}

		// Function from file: jobs.dm
		public void ResetOccupations(  ) {
			Mob_NewPlayer player = null;

			
			foreach (dynamic _a in Lang13.Enumerate( GlobalVars.player_list, typeof(Mob_NewPlayer) )) {
				player = _a;
				

				if ( player != null && player.mind != null ) {
					player.mind.assigned_role = null;
					player.mind.special_role = null;
				}
			}
			this.SetupOccupations();
			this.unassigned = new ByTable();
			return;
		}

		// Function from file: jobs.dm
		public void GiveRandomJob( Mob_NewPlayer player = null ) {
			Job job = null;

			this.Debug( "GRJ Giving random job, Player: " + player );

			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.shuffle( this.occupations ), typeof(Job) )) {
				job = _a;
				

				if ( !( job != null ) ) {
					continue;
				}

				if ( Lang13.Bool( ((dynamic)this.GetJob( "Assistant" )).IsInstanceOfType( job ) ) ) {
					continue;
				}

				if ( GlobalVars.command_positions.Contains( job ) ) {
					continue;
				}

				if ( GlobalFuncs.jobban_isbanned( player, job.title ) ) {
					this.Debug( "GRJ isbanned failed, Player: " + player + ", Job: " + job.title );
					continue;
				}

				if ( !job.player_old_enough( player.client ) ) {
					this.Debug( "GRJ player not old enough, Player: " + player );
					continue;
				}

				if ( player.mind.restricted_roles.Contains( player.mind != null && Lang13.Bool( job.title ) ) ) {
					this.Debug( "GRJ incompatible with antagonist role, Player: " + player + ", Job: " + job.title );
					continue;
				}

				if ( GlobalVars.config.enforce_human_authority && !((Species)player.client.prefs.pref_species).qualifies_for_rank( job.title, player.client.prefs.features ) ) {
					this.Debug( "GRJ non-human failed, Player: " + player );
					continue;
				}

				if ( ( job.current_positions ??0) < ( job.spawn_positions ??0) || job.spawn_positions == -1 ) {
					this.Debug( "GRJ Random job given, Player: " + player + ", Job: " + job );
					this.AssignRole( player, job.title );
					this.unassigned -= player;
					break;
				}
			}
			return;
		}

		// Function from file: jobs.dm
		public ByTable FindOccupationCandidates( Job job = null, double level = 0, dynamic flag = null ) {
			ByTable candidates = null;
			Mob_NewPlayer player = null;

			this.Debug( "Running FOC, Job: " + job + ", Level: " + level + ", Flag: " + flag );
			candidates = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( this.unassigned, typeof(Mob_NewPlayer) )) {
				player = _a;
				

				if ( GlobalFuncs.jobban_isbanned( player, job.title ) ) {
					this.Debug( "FOC isbanned failed, Player: " + player );
					continue;
				}

				if ( !job.player_old_enough( player.client ) ) {
					this.Debug( "FOC player not old enough, Player: " + player );
					continue;
				}

				if ( Lang13.Bool( flag ) && !player.client.prefs.be_special.Contains( flag ) ) {
					this.Debug( "FOC flag failed, Player: " + player + ", Flag: " + flag + ", " );
					continue;
				}

				if ( player.mind.restricted_roles.Contains( player.mind != null && Lang13.Bool( job.title ) ) ) {
					this.Debug( "FOC incompatible with antagonist role, Player: " + player );
					continue;
				}

				if ( GlobalVars.config.enforce_human_authority && !((Species)player.client.prefs.pref_species).qualifies_for_rank( job.title, player.client.prefs.features ) ) {
					this.Debug( "FOC non-human failed, Player: " + player );
					continue;
				}

				if ( Lang13.Bool( player.client.prefs.GetJobDepartment( job, level ) & job.flag ) ) {
					this.Debug( "FOC pass, Player: " + player + ", Level:" + level );
					candidates.Add( player );
				}
			}
			return candidates;
		}

		// Function from file: jobs.dm
		public bool AssignRole( dynamic player = null, dynamic rank = null, bool? latejoin = null ) {
			latejoin = latejoin ?? false;

			Job job = null;
			dynamic position_limit = null;

			this.Debug( "Running AR, Player: " + player + ", Rank: " + rank + ", LJ: " + latejoin );

			if ( Lang13.Bool( player ) && Lang13.Bool( player.mind ) && Lang13.Bool( rank ) ) {
				job = this.GetJob( rank );

				if ( !( job != null ) ) {
					return false;
				}

				if ( GlobalFuncs.jobban_isbanned( player, rank ) ) {
					return false;
				}

				if ( !job.player_old_enough( player.client ) ) {
					return false;
				}
				position_limit = job.total_positions;

				if ( !( latejoin == true ) ) {
					position_limit = job.spawn_positions;
				}
				this.Debug( "Player: " + player + " is now Rank: " + rank + ", JCP:" + job.current_positions + ", JPL:" + position_limit );
				player.mind.assigned_role = rank;
				this.unassigned -= player;
				job.current_positions++;
				return true;
			}
			this.Debug( "AR has failed, Player: " + player + ", Rank: " + rank );
			return false;
		}

		// Function from file: jobs.dm
		public Job GetJob( dynamic rank = null ) {
			Job J = null;

			
			if ( !Lang13.Bool( rank ) ) {
				return null;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.occupations, typeof(Job) )) {
				J = _a;
				

				if ( !( J != null ) ) {
					continue;
				}

				if ( J.title == rank ) {
					return J;
				}
			}
			return null;
		}

		// Function from file: jobs.dm
		public bool Debug( string text = null ) {
			
			if ( !GlobalVars.Debug2 ) {
				return false;
			}
			this.job_debug.Add( text );
			return true;
		}

		// Function from file: jobs.dm
		public bool SetupOccupations( string faction = null ) {
			faction = faction ?? "Station";

			dynamic all_jobs = null;
			dynamic J = null;
			dynamic job = null;

			this.occupations = new ByTable();
			all_jobs = Lang13.GetTypes( typeof(Job) ) - typeof(Job);

			if ( !( all_jobs.len != 0 ) ) {
				Game13.WriteMsg( "<span class='boldannounce'>Error setting up jobs, no job datums found</span>" );
				return false;
			}

			foreach (dynamic _a in Lang13.Enumerate( all_jobs )) {
				J = _a;
				
				job = Lang13.Call( J );

				if ( !Lang13.Bool( job ) ) {
					continue;
				}

				if ( job.faction != faction ) {
					continue;
				}

				if ( !((Job)job).config_check() ) {
					continue;
				}
				this.occupations.Add( job );
			}
			return true;
		}

		// Function from file: jobs.dm
		public override double Initialize( int start_timeofday = 0, double? zlevel = null ) {
			
			if ( Lang13.Bool( zlevel ) ) {
				return base.Initialize( start_timeofday, zlevel );
			}
			this.SetupOccupations();

			if ( GlobalVars.config.load_jobs_from_txt ) {
				this.LoadJobs();
			}
			base.Initialize( start_timeofday, zlevel );
			return 0;
		}

	}

}