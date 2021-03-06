// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Song : Game_Data {

		public string name = "Untitled";
		public ByTable lines = new ByTable();
		public double tempo = 5;
		public bool playing = false;
		public double help = 0;
		public double edit = 1;
		public int repeat = 0;
		public int max_repeats = 10;
		public string instrumentDir = "piano";
		public string instrumentExt = "ogg";
		public Obj instrumentObj = null;

		// Function from file: musician.dm
		public Song ( string dir = null, Obj obj = null ) {
			this.tempo = this.sanitize_tempo( this.tempo );
			this.instrumentDir = dir;
			this.instrumentObj = obj;
			return;
		}

		// Function from file: musician.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hsrc = null ) {
			string t = null;
			dynamic cont = null;
			int linenum = 0;
			dynamic l = null;
			string newline = null;
			int? num = null;
			double num2 = 0;
			string content = null;

			
			if ( !Task13.User.canUseTopic( this.instrumentObj ) ) {
				Interface13.Browse( Task13.User, null, "window=instrument" );
				Task13.User.unset_machine();
				return null;
			}
			this.instrumentObj.add_fingerprint( Task13.User );

			if ( Lang13.Bool( href_list["newsong"] ) ) {
				this.lines = new ByTable();
				this.tempo = this.sanitize_tempo( 5 );
				this.name = "";
			} else if ( Lang13.Bool( href_list["import"] ) ) {
				t = "";

				do {
					t = String13.HtmlEncode( Interface13.Input( Task13.User, "Please paste the entire song, formatted:", "" + this.name, t, null, InputType.StrMultiline ) );

					if ( !( Map13.GetDistance( this.instrumentObj, Task13.User ) <= 1 ) ) {
						return null;
					}

					if ( Lang13.Length( t ) >= 3072 ) {
						cont = Interface13.Input( Task13.User, "Your message is too long! Would you like to continue editing it?", "", "yes", new ByTable(new object [] { "yes", "no" }), InputType.Any );

						if ( cont == "no" ) {
							break;
						}
					}
				} while ( Lang13.Length( t ) > 3072 );
				Task13.Schedule( 0, (Task13.Closure)(() => {
					this.lines = GlobalFuncs.splittext( t, "\n" );

					if ( String13.SubStr( this.lines[1], 1, 6 ) == "BPM: " ) {
						this.tempo = this.sanitize_tempo( 600 / ( String13.ParseNumber( String13.SubStr( this.lines[1], 6, 0 ) ) ??0) );
						this.lines.Cut( 1, 2 );
					} else {
						this.tempo = this.sanitize_tempo( 5 );
					}

					if ( this.lines.len > 50 ) {
						Task13.User.WriteMsg( "Too many lines!" );
						this.lines.Cut( 51 );
					}
					linenum = 1;

					foreach (dynamic _a in Lang13.Enumerate( this.lines )) {
						l = _a;
						

						if ( Lang13.Length( l ) > 50 ) {
							Task13.User.WriteMsg( "Line " + linenum + " too long!" );
							this.lines.Remove( l );
						} else {
							linenum++;
						}
					}
					this.updateDialog( Task13.User );
					return;
				}));
			} else if ( Lang13.Bool( href_list["help"] ) ) {
				this.help = ( String13.ParseNumber( href_list["help"] ) ??0) - 1;
			} else if ( Lang13.Bool( href_list["edit"] ) ) {
				this.edit = ( String13.ParseNumber( href_list["edit"] ) ??0) - 1;
			}

			if ( Lang13.Bool( href_list["repeat"] ) ) {
				
				if ( this.playing ) {
					return null;
				}
				this.repeat += Num13.Floor( String13.ParseNumber( href_list["repeat"] ) ??0 );

				if ( this.repeat < 0 ) {
					this.repeat = 0;
				}

				if ( this.repeat > this.max_repeats ) {
					this.repeat = this.max_repeats;
				}
			} else if ( Lang13.Bool( href_list["tempo"] ) ) {
				this.tempo = this.sanitize_tempo( this.tempo + ( String13.ParseNumber( href_list["tempo"] ) ??0) );
			} else if ( Lang13.Bool( href_list["play"] ) ) {
				this.playing = true;
				Task13.Schedule( 0, (Task13.Closure)(() => {
					this.playsong( Task13.User );
					return;
				}));
			} else if ( Lang13.Bool( href_list["newline"] ) ) {
				newline = String13.HtmlEncode( Interface13.Input( "Enter your line: ", this.instrumentObj.name, null, null, null, InputType.Str | InputType.Null ) );

				if ( !Lang13.Bool( newline ) || !( Map13.GetDistance( this.instrumentObj, Task13.User ) <= 1 ) ) {
					return null;
				}

				if ( this.lines.len > 50 ) {
					return null;
				}

				if ( Lang13.Length( newline ) > 50 ) {
					newline = String13.SubStr( newline, 1, 50 );
				}
				this.lines.Add( newline );
			} else if ( Lang13.Bool( href_list["deleteline"] ) ) {
				num = Num13.Floor( String13.ParseNumber( href_list["deleteline"] ) ??0 );

				if ( ( num ??0) > this.lines.len || ( num ??0) < 1 ) {
					return null;
				}
				this.lines.Cut( num, ( num ??0) + 1 );
			} else if ( Lang13.Bool( href_list["modifyline"] ) ) {
				num2 = Num13.Round( String13.ParseNumber( href_list["modifyline"] ) ??0, 1 );
				content = String13.HtmlEncode( Interface13.Input( "Enter your line: ", this.instrumentObj.name, this.lines[num2], null, null, InputType.Str | InputType.Null ) );

				if ( !Lang13.Bool( content ) || !( Map13.GetDistance( this.instrumentObj, Task13.User ) <= 1 ) ) {
					return null;
				}

				if ( Lang13.Length( content ) > 50 ) {
					content = String13.SubStr( content, 1, 50 );
				}

				if ( num2 > this.lines.len || num2 < 1 ) {
					return null;
				}
				this.lines[num2] = content;
			} else if ( Lang13.Bool( href_list["stop"] ) ) {
				this.playing = false;
			}
			this.updateDialog( Task13.User );
			return null;
		}

		// Function from file: musician.dm
		public int sanitize_tempo( double new_tempo = 0 ) {
			new_tempo = Math.Abs( new_tempo );
			return Num13.MaxInt( ((int)( Num13.Round( new_tempo, Game13.tick_lag ) )), ((int)( Game13.tick_lag )) );
		}

		// Function from file: musician.dm
		public void interact( dynamic user = null ) {
			string dat = null;
			int bpm = 0;
			int linecount = 0;
			dynamic line = null;
			Browser popup = null;

			dat = "";

			if ( this.lines.len > 0 ) {
				dat += "<H3>Playback</H3>";

				if ( !this.playing ) {
					dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";play=1'>Play</A> <SPAN CLASS='linkOn'>Stop</SPAN><BR><BR>" ).ToString();
					dat += "Repeat Song: ";
					dat += ( this.repeat > 0 ? new Txt( "<A href='?src=" ).Ref( this ).str( ";repeat=-10'>-</A><A href='?src=" ).Ref( this ).str( ";repeat=-1'>-</A>" ).ToString() : "<SPAN CLASS='linkOff'>-</SPAN><SPAN CLASS='linkOff'>-</SPAN>" );
					dat += " " + this.repeat + " times ";
					dat += ( this.repeat < this.max_repeats ? new Txt( "<A href='?src=" ).Ref( this ).str( ";repeat=1'>+</A><A href='?src=" ).Ref( this ).str( ";repeat=10'>+</A>" ).ToString() : "<SPAN CLASS='linkOff'>+</SPAN><SPAN CLASS='linkOff'>+</SPAN>" );
					dat += "<BR>";
				} else {
					dat += new Txt( "<SPAN CLASS='linkOn'>Play</SPAN> <A href='?src=" ).Ref( this ).str( ";stop=1'>Stop</A><BR>" ).ToString();
					dat += "Repeats left: <B>" + this.repeat + "</B><BR>";
				}
			}

			if ( !( this.edit != 0 ) ) {
				dat += new Txt( "<BR><B><A href='?src=" ).Ref( this ).str( ";edit=2'>Show Editor</A></B><BR>" ).ToString();
			} else {
				dat += "<H3>Editing</H3>";
				dat += new Txt( "<B><A href='?src=" ).Ref( this ).str( ";edit=1'>Hide Editor</A></B>" ).ToString();
				dat += new Txt( " <A href='?src=" ).Ref( this ).str( ";newsong=1'>Start a New Song</A>" ).ToString();
				dat += new Txt( " <A href='?src=" ).Ref( this ).str( ";import=1'>Import a Song</A><BR><BR>" ).ToString();
				bpm = Num13.Floor( 600 / this.tempo );
				dat += new Txt( "Tempo: <A href='?src=" ).Ref( this ).str( ";tempo=" ).item( Game13.tick_lag ).str( "'>-</A> " ).item( bpm ).str( " BPM <A href='?src=" ).Ref( this ).str( ";tempo=-" ).item( Game13.tick_lag ).str( "'>+</A><BR><BR>" ).ToString();
				linecount = 0;

				foreach (dynamic _a in Lang13.Enumerate( this.lines )) {
					line = _a;
					
					linecount += 1;
					dat += new Txt( "Line " ).item( linecount ).str( ": <A href='?src=" ).Ref( this ).str( ";modifyline=" ).item( linecount ).str( "'>Edit</A> <A href='?src=" ).Ref( this ).str( ";deleteline=" ).item( linecount ).str( "'>X</A> " ).item( line ).str( "<BR>" ).ToString();
				}
				dat += new Txt( "<A href='?src=" ).Ref( this ).str( ";newline=1'>Add Line</A><BR><BR>" ).ToString();

				if ( this.help != 0 ) {
					dat += new Txt( "<B><A href='?src=" ).Ref( this ).str( ";help=1'>Hide Help</A></B><BR>" ).ToString();
					dat += @"
					Lines are a series of chords, separated by commas (,), each with notes seperated by hyphens (-).<br>
					Every note in a chord will play together, with chord timed by the tempo.<br>
					<br>
					Notes are played by the names of the note, and optionally, the accidental, and/or the octave number.<br>
					By default, every note is natural and in octave 3. Defining otherwise is remembered for each note.<br>
					Example: <i>C,D,E,F,G,A,B</i> will play a C major scale.<br>
					After a note has an accidental placed, it will be remembered: <i>C,C4,C,C3</i> is C3,C4,C4,C3</i><br>
					Chords can be played simply by seperating each note with a hyphon: <i>A-C#,Cn-E,E-G#,Gn-B</i><br>
					A pause may be denoted by an empty chord: <i>C,E,,C,G</i><br>
					To make a chord be a different time, end it with /x, where the chord length will be length<br>
					defined by tempo / x: <i>C,G/2,E/4</i><br>
					Combined, an example is: <i>E-E4/4,F#/2,G#/8,B/8,E3-E4/4</i>
					<br>
					Lines may be up to 50 characters.<br>
					A song may only contain up to 50 lines.<br>
					";
				} else {
					dat += new Txt( "<B><A href='?src=" ).Ref( this ).str( ";help=2'>Show Help</A></B><BR>" ).ToString();
				}
			}
			popup = new Browser( user, "instrument", this.instrumentObj.name, 700, 500 );
			popup.set_content( dat );
			popup.set_title_image( ((Mob)user).browse_rsc_icon( this.instrumentObj.icon, this.instrumentObj.icon_state ) );
			popup.open();
			return;
		}

		// Function from file: musician.dm
		public void playsong( Mob user = null ) {
			ByTable cur_oct = null;
			ByTable cur_acc = null;
			double i = 0;
			dynamic line = null;
			dynamic beat = null;
			ByTable notes = null;
			dynamic note = null;
			int cur_note = 0;
			double i2 = 0;
			string ni = null;

			
			while (this.repeat >= 0) {
				cur_oct = null;
				cur_oct = new ByTable( 7 );
				cur_acc = null;
				cur_acc = new ByTable( 7 );

				foreach (dynamic _a in Lang13.IterateRange( 1, 7 )) {
					i = _a;
					
					cur_oct[i] = 3;
					cur_acc[i] = "n";
				}

				foreach (dynamic _e in Lang13.Enumerate( this.lines )) {
					line = _e;
					

					foreach (dynamic _d in Lang13.Enumerate( GlobalFuncs.splittext( String13.ToLower( line ), "," ) )) {
						beat = _d;
						
						notes = GlobalFuncs.splittext( beat, "/" );

						foreach (dynamic _c in Lang13.Enumerate( GlobalFuncs.splittext( notes[1], "-" ) )) {
							note = _c;
							

							if ( !this.playing || this.shouldStopPlaying( user ) ) {
								this.playing = false;
								return;
							}

							if ( Lang13.Length( note ) == 0 ) {
								continue;
							}
							cur_note = String13.GetCharCode( note, null ) - 96;

							if ( cur_note < 1 || cur_note > 7 ) {
								continue;
							}

							foreach (dynamic _b in Lang13.IterateRange( 2, Lang13.Length( note ) )) {
								i2 = _b;
								
								ni = String13.SubStr( note, ((int)( i2 )), ((int)( i2 + 1 )) );

								if ( !Lang13.Bool( String13.ParseNumber( ni ) ) ) {
									
									if ( ni == "#" || ni == "b" || ni == "n" ) {
										cur_acc[cur_note] = ni;
									} else if ( ni == "s" ) {
										cur_acc[cur_note] = "#";
									}
								} else {
									cur_oct[cur_note] = String13.ParseNumber( ni );
								}
							}
							this.playnote( cur_note, cur_acc[cur_note], Convert.ToInt32( cur_oct[cur_note] ) );
						}

						if ( notes.len >= 2 && Lang13.Bool( String13.ParseNumber( notes[2] ) ) ) {
							Task13.Sleep( this.sanitize_tempo( this.tempo / ( String13.ParseNumber( notes[2] ) ??0) ) );
						} else {
							Task13.Sleep( ((int)( this.tempo )) );
						}
					}
				}
				this.repeat--;

				if ( this.repeat >= 0 ) {
					this.updateDialog( user );
				}
			}
			this.playing = false;
			this.repeat = 0;
			this.updateDialog( user );
			return;
		}

		// Function from file: musician.dm
		public virtual bool shouldStopPlaying( Mob user = null ) {
			
			if ( this.instrumentObj != null ) {
				
				if ( !user.canUseTopic( this.instrumentObj ) ) {
					return true;
				}
				return !Lang13.Bool( this.instrumentObj.anchored );
			} else {
				return true;
			}
		}

		// Function from file: musician.dm
		public virtual void updateDialog( Mob user = null ) {
			this.instrumentObj.updateDialog();
			return;
		}

		// Function from file: musician.dm
		public void playnote( int note = 0, string acc = null, int oct = 0 ) {
			dynamic soundfile = null;
			dynamic source = null;
			dynamic M = null;

			
			if ( acc == "b" && ( note == 3 || note == 6 ) ) {
				
				if ( note == 3 ) {
					oct--;
				}
				note--;
				acc = "n";
			} else if ( acc == "#" && ( note == 2 || note == 5 ) ) {
				
				if ( note == 2 ) {
					oct++;
				}
				note++;
				acc = "n";
			} else if ( acc == "#" && note == 7 ) {
				note = 1;
				acc = "b";
			} else if ( acc == "#" ) {
				acc = "b";
				note++;
			}

			if ( oct < 1 || ( note == 3 ? oct > 9 : oct > 8 ) ) {
				return;
			}
			soundfile = "sound/" + this.instrumentDir + "/" + String13.GetCharFromCode( note + 64 ) + acc + oct + "." + this.instrumentExt;
			soundfile = new File( soundfile );

			if ( !File13.Exists( soundfile ) ) {
				return;
			}
			source = GlobalFuncs.get_turf( this.instrumentObj );

			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_hearers_in_view( 15, source ) )) {
				M = _a;
				

				if ( !Lang13.Bool( M.client ) || !Lang13.Bool( M.client.prefs.toggles & 128 ) ) {
					continue;
				}
				((Ent_Static)M).playsound_local( source, soundfile, 100, null, null, 5 );
			}
			return;
		}

		// Function from file: musician.dm
		public override dynamic Destroy(  ) {
			this.instrumentObj = null;
			return base.Destroy();
		}

	}

}