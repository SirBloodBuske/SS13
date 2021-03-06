// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Gang : Game_Data {

		public dynamic name = "ERROR";
		public dynamic color = "white";
		public string color_hex = "#FFFFFF";
		public ByTable gangsters = new ByTable();
		public ByTable bosses = new ByTable();
		public ByTable gangtools = new ByTable();
		public dynamic style = null;
		public string fighting_style = "normal";
		public ByTable territory = new ByTable();
		public ByTable territory_new = new ByTable();
		public ByTable territory_lost = new ByTable();
		public dynamic dom_timer = "OFFLINE";
		public int dom_attempts = 2;
		public int points = 15;
		public AtomHud_Antag ganghud = null;

		// Function from file: gang_datum.dm
		public Gang ( dynamic loc = null, dynamic gangname = null ) {
			
			if ( !( GlobalVars.gang_colors_pool.len != 0 ) ) {
				GlobalFuncs.message_admins( "WARNING: Maximum number of gangs have been exceeded!" );
				throw new Exception( "Maximum number of gangs has been exceeded" );
				return;
			} else {
				this.color = Rand13.PickFromTable( GlobalVars.gang_colors_pool );
				GlobalVars.gang_colors_pool.Remove( this.color );

				dynamic _a = this.color; // Was a switch-case, sorry for the mess.
				if ( _a=="red" ) {
					this.color_hex = "#DA0000";
				} else if ( _a=="orange" ) {
					this.color_hex = "#FF9300";
				} else if ( _a=="yellow" ) {
					this.color_hex = "#FFF200";
				} else if ( _a=="green" ) {
					this.color_hex = "#A8E61D";
				} else if ( _a=="blue" ) {
					this.color_hex = "#00B7EF";
				} else if ( _a=="purple" ) {
					this.color_hex = "#DA00FF";
				}
			}
			this.name = ( Lang13.Bool( gangname ) ? gangname : Rand13.PickFromTable( GlobalVars.gang_name_pool ) );
			GlobalVars.gang_name_pool.Remove( this.name );
			this.ganghud = new AtomHud_Antag();
			GlobalFuncs.log_game( "The " + this.name + " Gang has been created. Their gang color is " + this.color + "." );
			return;
		}

		// Function from file: gang_datum.dm
		public void income(  ) {
			string added_names = null;
			string lost_names = null;
			ByTable reclaimed_territories = null;
			dynamic area = null;
			int uniformed = 0;
			Mind gangmind = null;
			dynamic gangster = null;
			dynamic outfit = null;
			dynamic gang_outfit = null;
			string message = null;
			int new_time = 0;
			int points_new = 0;
			dynamic area2 = null;
			double control = 0;
			Obj_Item_Device_Gangtool tool = null;

			
			if ( !( this.bosses.len != 0 ) ) {
				return;
			}
			added_names = "";
			lost_names = "";
			reclaimed_territories = this.territory_new & this.territory_lost;
			this.territory.Or( reclaimed_territories );
			this.territory_new.Remove( reclaimed_territories );
			this.territory_lost.Remove( reclaimed_territories );

			foreach (dynamic _a in Lang13.Enumerate( this.territory_lost )) {
				area = _a;
				

				if ( lost_names != "" ) {
					lost_names += ", ";
				}
				lost_names += "" + this.territory_lost[area];
				this.territory.Remove( area );
			}
			uniformed = 0;

			foreach (dynamic _b in Lang13.Enumerate( this.gangsters | this.bosses, typeof(Mind) )) {
				gangmind = _b;
				

				if ( gangmind.current is Mob_Living_Carbon_Human ) {
					gangster = gangmind.current;

					if ( Convert.ToInt32( gangster.stat ) == 2 || Convert.ToDouble( gangster.z ) > 1 ) {
						continue;
					}
					outfit = null;
					gang_outfit = null;

					if ( Lang13.Bool( gangster.w_uniform ) ) {
						outfit = gangster.w_uniform;

						if ( outfit.gang == this ) {
							gang_outfit = outfit;
						}
					}

					if ( Lang13.Bool( gangster.wear_suit ) ) {
						outfit = gangster.wear_suit;

						if ( outfit.gang == this ) {
							gang_outfit = outfit;
						}
					}

					if ( Lang13.Bool( gang_outfit ) ) {
						gangster.WriteMsg( "<span class='notice'>The " + this + " Gang's influence grows as you wear " + gang_outfit + ".</span>" );
						uniformed++;
					}
				}
			}
			message = "<b>" + this + " Gang Status Report:</b><BR>*---------*<br>";

			if ( Lang13.Bool( Lang13.IsNumber( this.dom_timer ) ) ) {
				new_time = Num13.MaxInt( 180, Convert.ToInt32( this.dom_timer - uniformed * 4 - this.territory.len * 2 ) );

				if ( new_time < Convert.ToDouble( this.dom_timer ) ) {
					message += "Takeover shortened by " + ( this.dom_timer - new_time ) + " seconds for defending " + this.territory.len + " territories and " + uniformed + " uniformed gangsters.<BR>";
					this.dom_timer = new_time;
				}
				message += "<b>" + this.dom_timer + " seconds remain</b> in hostile takeover.<BR>";
			} else {
				points_new = Num13.MinInt( 999, this.points + uniformed * 2 + this.territory.len + 15 );

				if ( points_new != this.points ) {
					message += "Gang influence has increased by " + ( points_new - this.points ) + " for defending " + this.territory.len + " territories and " + uniformed + " uniformed gangsters.<BR>";
				}
				this.points = points_new;
				message += "Your gang now has <b>" + this.points + " influence</b>.<BR>";
			}

			foreach (dynamic _c in Lang13.Enumerate( this.territory_new )) {
				area2 = _c;
				

				if ( added_names != "" ) {
					added_names += ", ";
				}
				added_names += "" + this.territory_new[area2];
				this.territory.Add( area2 );
			}
			message += "<b>" + this.territory_new.len + " new territories:</b><br><i>" + added_names + "</i><br>";
			message += "<b>" + this.territory_lost.len + " territories lost:</b><br><i>" + lost_names + "</i><br>";
			this.territory_new = new ByTable();
			this.territory_lost = new ByTable();
			control = Num13.Round( this.territory.len / GlobalVars.start_state.num_territories * 100, 1 );
			message += "Your gang now has <b>" + control + "% control</b> of the station.<BR>*---------*";
			this.message_gangtools( message );

			foreach (dynamic _d in Lang13.Enumerate( this.gangtools, typeof(Obj_Item_Device_Gangtool) )) {
				tool = _d;
				
				tool.outfits = Num13.MinInt( tool.outfits + 1, 5 );
			}
			return;
		}

		// Function from file: gang_datum.dm
		public void message_gangtools( string message = null, bool? beep = null, bool? warning = null ) {
			beep = beep ?? true;

			Obj_Item_Device_Gangtool tool = null;
			dynamic mob = null;

			
			if ( !( this.gangtools.len != 0 ) || !Lang13.Bool( message ) ) {
				return;
			}

			foreach (dynamic _a in Lang13.Enumerate( this.gangtools, typeof(Obj_Item_Device_Gangtool) )) {
				tool = _a;
				
				mob = GlobalFuncs.get( tool.loc, typeof(Mob_Living) );

				if ( Lang13.Bool( mob ) && Lang13.Bool( mob.mind ) && Lang13.Bool( mob.stat ) == false ) {
					
					if ( mob.mind.gang_datum == this ) {
						mob.WriteMsg( new Txt( "<span class='" ).item( ( warning == true ? "warning" : "notice" ) ).str( "'>" ).icon( tool ).str( " " ).item( message ).str( "</span>" ).ToString() );

						if ( beep == true ) {
							GlobalFuncs.playsound( mob.loc, "sound/machines/twobeep.ogg", 50, 1 );
						}
					}
				}
			}
			return;
		}

		// Function from file: gang_datum.dm
		public bool gang_outfit( Mob user = null, Obj_Item_Device_Gangtool gangtool = null ) {
			ByTable gang_style_list = null;
			Type outfit_path = null;
			dynamic outfit = null;

			
			if ( !( user != null ) || !( gangtool != null ) ) {
				return false;
			}

			if ( !gangtool.can_use( user ) ) {
				return false;
			}
			gang_style_list = new ByTable(new object [] { "Gang Colors", "Black Suits", "White Suits", "Leather Jackets", "Leather Overcoats", "Puffer Jackets", "Military Jackets", "Tactical Turtlenecks", "Soviet Uniforms" });

			if ( !Lang13.Bool( this.style ) && ((GameMode)GlobalVars.ticker.mode).get_gang_bosses().Contains( user.mind ) ) {
				this.style = Interface13.Input( "Pick an outfit style.", "Pick Style", null, null, gang_style_list, InputType.Null | InputType.Any );
			}

			if ( gangtool.can_use( user ) && gangtool.outfits >= 1 ) {
				
				dynamic _a = this.style; // Was a switch-case, sorry for the mess.
				if ( _a=="Gang Colors" ) {
					outfit_path = Lang13.FindClass( "/obj/item/clothing/under/color/" + this.color );
				} else if ( _a=="Black Suits" ) {
					outfit_path = typeof(Obj_Item_Clothing_Under_SuitJacket_Charcoal);
				} else if ( _a=="White Suits" ) {
					outfit_path = typeof(Obj_Item_Clothing_Under_SuitJacket_White);
				} else if ( _a=="Puffer Jackets" ) {
					outfit_path = typeof(Obj_Item_Clothing_Suit_Jacket_Puffer);
				} else if ( _a=="Leather Jackets" ) {
					outfit_path = typeof(Obj_Item_Clothing_Suit_Jacket_Leather);
				} else if ( _a=="Leather Overcoats" ) {
					outfit_path = typeof(Obj_Item_Clothing_Suit_Jacket_Leather_Overcoat);
				} else if ( _a=="Military Jackets" ) {
					outfit_path = typeof(Obj_Item_Clothing_Suit_Jacket_Miljacket);
				} else if ( _a=="Soviet Uniforms" ) {
					outfit_path = typeof(Obj_Item_Clothing_Under_Soviet);
				} else if ( _a=="Tactical Turtlenecks" ) {
					outfit_path = typeof(Obj_Item_Clothing_Under_Syndicate);
				}

				if ( outfit_path != null ) {
					outfit = Lang13.Call( outfit_path, user.loc );
					outfit.armor = new ByTable().Set( "melee", 20 ).Set( "bullet", 30 ).Set( "laser", 10 ).Set( "energy", 10 ).Set( "bomb", 20 ).Set( "bio", 0 ).Set( "rad", 0 );
					outfit.desc += " Tailored for the " + this.name + " Gang to offer the wearer moderate protection against ballistics and physical trauma.";
					outfit.gang = this;
					user.put_in_hands( outfit );
					return true;
				}
			}
			return false;
		}

		// Function from file: gang_datum.dm
		public void domination( double? modifier = null ) {
			modifier = modifier ?? 1;

			this.dom_timer = GlobalFuncs.get_domination_time( this ) * ( modifier ??0);
			GlobalFuncs.set_security_level( "delta" );
			GlobalVars.SSshuttle.emergencyNoEscape = true;
			return;
		}

		// Function from file: gang_datum.dm
		public void remove_gang_hud( Mind defector_mind = null ) {
			this.ganghud.leave_hud( defector_mind.current );
			((GameMode)GlobalVars.ticker.mode).set_antag_hud( defector_mind.current, null );
			return;
		}

		// Function from file: gang_datum.dm
		public void add_gang_hud( Mind recruit_mind = null ) {
			this.ganghud.join_hud( recruit_mind.current );
			((GameMode)GlobalVars.ticker.mode).set_antag_hud( recruit_mind.current, ( this.bosses.Contains( recruit_mind ) ? "gang_boss" : "gangster" ) );
			return;
		}

	}

}