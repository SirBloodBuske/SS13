// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Dead : Mob {

		public Mob_Dead ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: observer.dm
		public bool assess_targets( ByTable target_list = null, Mob_Dead_Observer U = null ) {
			string tempHud = null;
			Mob_Living target = null;
			Mob_Living silicon_target = null;

			tempHud = "icons/mob/hud.dmi";

			foreach (dynamic _b in Lang13.Enumerate( target_list, typeof(Mob_Living) )) {
				target = _b;
				

				if ( target is Mob_Living_Carbon ) {
					
					switch ((string)( target.mind.special_role )) {
						case "traitor":
						case "Syndicate":
							U.client.images.Add( new Image( tempHud, target, "hudsyndicate" ) );
							break;
						case "Revolutionary":
							U.client.images.Add( new Image( tempHud, target, "hudrevolutionary" ) );
							break;
						case "Head Revolutionary":
							U.client.images.Add( new Image( tempHud, target, "hudheadrevolutionary" ) );
							break;
						case "Cultist":
							U.client.images.Add( new Image( tempHud, target, "hudcultist" ) );
							break;
						case "Changeling":
							U.client.images.Add( new Image( tempHud, target, "hudchangeling" ) );
							break;
						case "Wizard":
						case "Fake Wizard":
							U.client.images.Add( new Image( tempHud, target, "hudwizard" ) );
							break;
						case "Hunter":
						case "Sentinel":
						case "Drone":
						case "Queen":
							U.client.images.Add( new Image( tempHud, target, "hudalien" ) );
							break;
						case "Death Commando":
							U.client.images.Add( new Image( tempHud, target, "huddeathsquad" ) );
							break;
						case "Vampire":
							U.client.images.Add( new Image( tempHud, target, "vampire" ) );
							break;
						case "VampThrall":
							U.client.images.Add( new Image( tempHud, target, "vampthrall" ) );
							break;
						default:
							U.client.images.Add( new Image( tempHud, target, "hudunknown1" ) );
							break;
					}
				} else if ( target is Mob_Living_Silicon ) {
					silicon_target = target;

					if ( !Lang13.Bool( ((dynamic)silicon_target).laws ) || Lang13.Bool( ((dynamic)silicon_target).laws ) && ( Lang13.Bool( ((dynamic)silicon_target).laws.zeroth ) || !( ((dynamic)silicon_target).laws.inherent.len != 0 ) ) || silicon_target.mind.special_role == "traitor" ) {
						
						if ( silicon_target is Mob_Living_Silicon_Robot ) {
							U.client.images.Add( new Image( tempHud, silicon_target, "hudmalborg" ) );
						} else {
							U.client.images.Add( new Image( tempHud, silicon_target, "hudmalai" ) );
						}
					}
				}
			}
			return true;
		}

		// Function from file: observer.dm
		public void process_medHUD( Mob_Dead_Observer M = null ) {
			Client C = null;
			dynamic holder = null;
			Mob_Living_Carbon_Human patient = null;
			bool foundVirus = false;
			dynamic B = null;

			C = M.client;

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInViewExcludeThis( null, M ), typeof(Mob_Living_Carbon_Human) )) {
				patient = _a;
				
				foundVirus = false;

				if ( patient != null && patient.virus2 != null && patient.virus2.len != 0 ) {
					foundVirus = true;
				}

				if ( !( C != null ) ) {
					return;
				}
				holder = patient.hud_list[1];

				if ( Lang13.Bool( holder ) ) {
					
					if ( patient.stat == 2 ) {
						holder.icon_state = "hudhealth-100";
					} else {
						holder.icon_state = "hud" + this.RoundHealth( patient.health );
					}
					C.images.Add( holder );
				}
				holder = patient.hud_list[2];

				if ( Lang13.Bool( holder ) ) {
					
					if ( patient.stat == 2 ) {
						holder.icon_state = "huddead";
					} else if ( ( patient.status_flags & 32768 ) != 0 ) {
						holder.icon_state = "hudxeno";
					} else if ( foundVirus ) {
						holder.icon_state = "hudill";
					} else if ( Lang13.Bool( patient.has_brain_worms() ) ) {
						B = patient.has_brain_worms();

						if ( B.controlling ) {
							holder.icon_state = "hudbrainworm";
						} else {
							holder.icon_state = "hudhealthy";
						}
					} else {
						holder.icon_state = "hudhealthy";
					}
					C.images.Add( holder );
				}
			}
			return;
		}

		// Function from file: observer.dm
		public string RoundHealth( dynamic health = null ) {
			
			dynamic _a = health; // Was a switch-case, sorry for the mess.
			if ( 100<=_a&&_a<=Double.PositiveInfinity ) {
				return "health100";
			} else if ( 70<=_a&&_a<=100 ) {
				return "health80";
			} else if ( 50<=_a&&_a<=70 ) {
				return "health60";
			} else if ( 30<=_a&&_a<=50 ) {
				return "health40";
			} else if ( 18<=_a&&_a<=30 ) {
				return "health25";
			} else if ( 5<=_a&&_a<=18 ) {
				return "health10";
			} else if ( 1<=_a&&_a<=5 ) {
				return "health1";
			} else if ( -99<=_a&&_a<=0 ) {
				return "health0";
			} else {
				return "health-100";
			}
			return "0";
		}

		// Function from file: observer.dm
		public override bool CanPass( dynamic mover = null, dynamic target = null, double? height = null, bool? air_group = null ) {
			height = height ?? 1.5;
			air_group = air_group ?? false;

			return true;
		}

		// Function from file: observer.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Mob_Dead M = null;
			Mob_Dead M2 = null;

			
			if ( a is Obj_Item_Weapon_Tome ) {
				M = this;

				if ( this.invisibility != 0 ) {
					M.invisibility = 0;
					((Ent_Static)b).visible_message( "<span class='warning'>" + b + " drags ghost, " + M + ", to our plane of reality!</span>", "<span class='warning'>You drag " + M + " to our plane of reality!</span>" );
				} else {
					((Ent_Static)b).visible_message( "<span class='warning'>" + b + " just tried to smash his book into that ghost!  It's not very effective</span>", "<span class='warning'>You get the feeling that the ghost can't become any more visible.</span>" );
				}
			}

			if ( a is Obj_Item_Weapon_Storage_Bible || a is Obj_Item_Weapon_Nullrod ) {
				M2 = this;

				if ( this.invisibility == 0 ) {
					M2.invisibility = 60;
					((Ent_Static)b).visible_message( "<span class='warning'>" + b + " banishes the ghost from our plane of reality!</span>", "<span class='warning'>You banish the ghost from our plane of reality!</span>" );
				}
			}
			return null;
		}

		// Function from file: vgstation13.dme
		public override bool update_canmove(  ) {
			return false;
		}

		// Function from file: death.dm
		public override bool singuloCanEat(  ) {
			return false;
		}

		// Function from file: death.dm
		public override dynamic cultify(  ) {
			dynamic H = null;

			
			if ( this.icon_state != "ghost-narsie" ) {
				this.icon = "icons/mob/mob.dmi";
				this.icon_state = "ghost-narsie";
				this.overlays = 0;

				if ( this.mind != null && Lang13.Bool( this.mind.current ) ) {
					
					if ( this.mind.current is Mob_Living_Carbon_Human ) {
						H = this.mind.current;
						this.overlays.Add( H.obj_overlays[14] );
						this.overlays.Add( H.obj_overlays[9] );
						this.overlays.Add( H.obj_overlays[6] );
						this.overlays.Add( H.obj_overlays[10] );
						this.overlays.Add( H.obj_overlays[16] );
						this.overlays.Add( H.obj_overlays[11] );
						this.overlays.Add( H.obj_overlays[13] );
						this.overlays.Add( H.obj_overlays[18] );
						this.overlays.Add( H.obj_overlays[19] );
					}
				}
				this.invisibility = 0;
				GlobalFuncs.to_chat( this, "<span class='sinister'>Even as a non-corporal being, you can feel Nar-Sie's presence altering you. You are now visible to everyone.</span>" );
			}
			return null;
		}

		// Function from file: death.dm
		public override dynamic gib( bool? animation = null, bool? meat = null ) {
			return null;
		}

		// Function from file: death.dm
		public override void dust(  ) {
			return;
		}

		// Function from file: observer.dm
		[Verb]
		[VerbInfo( name: "Write in blood", desc: "If the round is sufficiently spooky, write a short message in blood on the floor or a wall. Remember, no IC in OOC or OOC in IC.", group: "Ghost" )]
		public bool bloody_doodle(  ) {
			bool ghosts_can_write = false;
			dynamic C = null;
			ByTable choices = null;
			Obj_Effect_Decal_Cleanable_Blood B = null;
			dynamic choice = null;
			dynamic direction = null;
			Ent_Static T = null;
			string doodle_color = null;
			int num_doodles = 0;
			Obj_Effect_Decal_Cleanable_Blood_Writing W = null;
			int max_length = 0;
			dynamic message = null;
			Game_Data W2 = null;

			
			if ( !GlobalVars.config.cult_ghostwriter ) {
				GlobalFuncs.to_chat( this, "<span class='warning'>That verb is not currently permitted.</span>" );
				return false;
			}

			if ( !Lang13.Bool( this.stat ) ) {
				return false;
			}

			if ( Task13.User != this ) {
				return false;
			}

			if ( GlobalVars.ticker.mode.name == "cult" ) {
				C = GlobalVars.ticker.mode;

				if ( C.cult.len > Convert.ToDouble( GlobalVars.config.cult_ghostwriter_req_cultists ) ) {
					ghosts_can_write = true;
				}
			}

			if ( !ghosts_can_write ) {
				GlobalFuncs.to_chat( this, "<span class='warning'>The veil is not thin enough for you to do that.</span>" );
				return false;
			}
			choices = new ByTable();

			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchInView( this, 1 ), typeof(Obj_Effect_Decal_Cleanable_Blood) )) {
				B = _a;
				

				if ( ( B.amount ??0) > 0 ) {
					choices.Add( B );
				}
			}

			if ( !( choices.len != 0 ) ) {
				GlobalFuncs.to_chat( this, "<span class = 'warning'>There is no blood to use nearby.</span>" );
				return false;
			}
			choice = Interface13.Input( this, "What blood would you like to use?", null, null, null | choices, InputType.Any );
			direction = Interface13.Input( this, "Which way?", "Tile selection", null, new ByTable(new object [] { "Here", "North", "South", "East", "West" }), InputType.Any );
			T = this.loc;

			if ( direction != "Here" ) {
				T = Map13.GetStep( T, GlobalFuncs.text2dir( direction ) );
			}

			if ( !( T is Tile_Simulated ) ) {
				GlobalFuncs.to_chat( this, "<span class='warning'>You cannot doodle there.</span>" );
				return false;
			}

			if ( !Lang13.Bool( choice ) || Lang13.Bool( choice.amount ) == false || !this.Adjacent( choice ) ) {
				return false;
			}
			doodle_color = ( Lang13.Bool( choice.basecolor ) ? choice.basecolor : "#A10808" );
			num_doodles = 0;

			foreach (dynamic _b in Lang13.Enumerate( T, typeof(Obj_Effect_Decal_Cleanable_Blood_Writing) )) {
				W = _b;
				
				num_doodles++;
			}

			if ( num_doodles > 4 ) {
				GlobalFuncs.to_chat( this, "<span class='warning'>There is no space to write on!</span>" );
				return false;
			}
			max_length = 50;
			message = GlobalFuncs.stripped_input( this, "Write a message. It cannot be longer than " + max_length + " characters.", "Blood writing", "" );

			if ( Lang13.Bool( message ) ) {
				
				if ( Lang13.Length( message ) > max_length ) {
					message += "-";
					GlobalFuncs.to_chat( this, "<span class='warning'>You ran out of blood to write with!</span>" );
				}
				W2 = GlobalFuncs.getFromPool( typeof(Obj_Effect_Decal_Cleanable_Blood_Writing), T );
				((dynamic)W2).New( T );
				((dynamic)W2).basecolor = doodle_color;
				((dynamic)W2).update_icon();
				((dynamic)W2).message = message;
				((Ent_Static)W2).add_hiddenprint( this );
				((Ent_Static)W2).visible_message( "<span class='warning'>Invisible fingers crudely paint something in blood on " + T + "...</span>" );
			}
			return false;
		}

	}

}