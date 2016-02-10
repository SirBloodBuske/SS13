// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Bed_Chair_Vehicle_Clowncart : Obj_Structure_Bed_Chair_Vehicle {

		public bool activated = false;
		public int mode = 0;
		public double max_health_top = 1000;
		public string printing_text = "nothing";
		public double printing_pos = 0;
		public int trail = 0;
		public string colour1 = "#000000";
		public string colour2 = "#3D3D3D";
		public bool emagged = false;
		public int honk = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.nick = "honkin' ride";
			this.flags = 4096;
			this.icon_state = "clowncart0";
		}

		// Function from file: clowncart.dm
		public Obj_Structure_Bed_Chair_Vehicle_Clowncart ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.create_reagents( 5000 );
			((Reagents)this.reagents).add_reagent( "banana", 175 );
			GlobalVars.processing_objects.Or( this );
			return;
		}

		// Function from file: clowncart.dm
		public int feed( dynamic W = null, dynamic user = null ) {
			Reagents R = null;
			bool added_banana = false;
			int modifier = 0;

			R = W.reagents;

			if ( !( R != null ) ) {
				return 0;
			}

			if ( R.has_reagent( "banana" ) ) {
				added_banana = R.get_reagent_amount( "banana" );

				if ( ( this.reagents.total_volume ??0) + ( added_banana ?1:0) > 5000 ) {
					GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>" ).The( this ).item().str( " can't hold any more banana essence!</span>" ).ToString() );
					return 0;
				}
				modifier = 50;

				if ( this.max_health >= 200 ) {
					modifier = 75;

					if ( this.max_health >= 400 ) {
						modifier = 100;
					}
				}
				((Reagents)this.reagents).add_reagent( "banana", ( added_banana ?1:0) * modifier );

				if ( W is Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie ) {
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/effects/bubbles.ogg", 50, 1 );
					GlobalFuncs.to_chat( user, new Txt( "<span class='warning'>" ).item( W ).str( " starts boiling inside " ).the( this ).item().str( "!</span>" ).ToString() );
					this.trail += 5;
				}
				return ( added_banana ?1:0) * modifier;
			} else {
				GlobalFuncs.to_chat( user, new Txt( "<span class='notice'>" ).The( W ).item().str( " doesn't contain any banana essence!</span>" ).ToString() );
				return 0;
			}
		}

		// Function from file: clowncart.dm
		public void draw_graffiti( dynamic pos = null ) {
			int graffiti_amount = 0;
			Obj_Effect_Decal_Cleanable_Crayon C = null;
			dynamic T = null;
			string ind = null;
			Icon overlay = null;

			graffiti_amount = 0;

			foreach (dynamic _a in Lang13.Enumerate( pos, typeof(Obj_Effect_Decal_Cleanable_Crayon) )) {
				C = _a;
				
				graffiti_amount++;

				if ( graffiti_amount > ( this.emagged ?1:0) * 3 + 3 ) {
					
					if ( this.printing_text != "paint" ) {
						return;
					}
				}
			}

			if ( !( pos is Tile_Simulated_Floor ) ) {
				return;
			}

			if ( this.printing_text == "nothing" || this.printing_text == "" ) {
				return;
			}
			((Reagents)this.reagents).remove_reagent( "banana", 2 );

			if ( this.printing_text == "graffiti" || this.printing_text == "rune" ) {
				new Obj_Effect_Decal_Cleanable_Crayon( pos, this.colour1, this.colour2, this.printing_text );
			} else if ( this.printing_text == "paint" ) {
				T = pos;
				ind = "" + Lang13.Initial( T, "icon" ) + this.colour1;

				if ( !Lang13.Bool( GlobalVars.cached_icons[ind] ) ) {
					overlay = new Icon( Lang13.Initial( T, "icon" ) );
					overlay.Blend( this.colour1, 0 );
					overlay.SetIntensity( 0.41 );
					T.icon = overlay;
					GlobalVars.cached_icons[ind] = T.icon;
				} else {
					T.icon = GlobalVars.cached_icons[ind];
					return;
				}
			} else {
				
				if ( this.dir == GlobalVars.WEST || this.dir == GlobalVars.NORTH ) {
					
					if ( this.printing_pos >= 0 ) {
						this.printing_pos = -Lang13.Length( this.printing_text ) - 1;
					}
				}
				this.printing_pos++;
				new Obj_Effect_Decal_Cleanable_Crayon( pos, this.colour1, this.colour2, String13.SubStr( this.printing_text, ((int)( Math.Abs( this.printing_pos ) )), ((int)( Math.Abs( this.printing_pos ) + 1 )) ) );

				if ( this.printing_pos > Lang13.Length( this.printing_text ) - 1 || this.printing_pos == -1 ) {
					this.printing_text = "";
					this.printing_pos = 0;
				}
			}
			return;
		}

		// Function from file: clowncart.dm
		public override void die(  ) {
			int? a = null;

			this.destroyed = true;
			this.density = false;
			this.visible_message( "<span class='warning'>" + this.nick + " explodes in a puff of pure potassium!</span>" );
			GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/bikehorn.ogg", 75, 1 );
			GlobalFuncs.explosion( this.loc, -1, 0, 3, 7, 10 );
			a = null;
			a = 0;

			while (( a ??0) < Num13.Floor( ( this.reagents.total_volume ??0) * 0.25 )) {
				new Obj_Item_Weapon_Bananapeel( GlobalFuncs.get_turf( this ) );
				a++;
			}
			GlobalFuncs.qdel( this );
			return;
		}

		// Function from file: clowncart.dm
		public override dynamic relaymove( Mob M = null, double? direction = null ) {
			dynamic old_pos = null;

			
			if ( Lang13.Bool( M.stat ) || M.stunned != 0 || M.weakened != 0 || M.paralysis != 0 || this.destroyed ) {
				this.unlock_atom( M );
				return null;
			}

			if ( this.empstun > 0 ) {
				
				if ( M != null ) {
					GlobalFuncs.to_chat( M, "<span class='warning'>" + this + "'s banana essence battery has been shorted out.</span>" );
				}
				return null;
			}

			if ( ( this.reagents.total_volume ??0) <= 0 ) {
				
				if ( M != null ) {
					GlobalFuncs.to_chat( M, "<span class='warning'>" + this + " has no fuel, it activates its ejection seat as soon as you jam down the pedal!</span>" );
					this.unlock_atom( M );
					this.activated = false;
					M.Weaken( 5 );
				}
				return null;
			}

			if ( this.activated ) {
				old_pos = GlobalFuncs.get_turf( this );
				Map13.Step( this, ((int)( direction ??0 )) );

				if ( GlobalFuncs.get_turf( this ) == old_pos ) {
					return null;
				}

				if ( this.max_health < 300 ) {
					((Reagents)this.reagents).remove_reagent( "banana", 1 );
				}

				if ( this.trail > 0 ) {
					new Obj_Effect_Decal_Cleanable_PieSmudge( old_pos );
					this.trail--;
				}

				if ( this.mode == 1 ) {
					this.draw_graffiti( old_pos );
				} else if ( this.mode == 2 ) {
					
					if ( !this.emagged ) {
						new Obj_Item_Weapon_Bananapeel( old_pos );
						((Reagents)this.reagents).remove_reagent( "banana", 4 );
					} else {
						new Obj_Item_Weapon_Bananapeel_Traitorpeel( old_pos );
						((Reagents)this.reagents).remove_reagent( "banana", 8 );
					}
				}
			} else {
				GlobalFuncs.to_chat( M, "<span class='notice'>You have to honk to be able to ride " + this + ".</span>" );
			}
			return null;
		}

		// Function from file: clowncart.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			int ate_anything = 0;
			dynamic B = null;
			Obj_Item I = null;
			dynamic ST = null;
			bool bananas = false;

			
			if ( a is Obj_Item_Weapon_Bikehorn ) {
				
				if ( this.destroyed ) {
					GlobalFuncs.to_chat( b, "<span class='danger'>" + this + " is completely wrecked, it's over.</span>" );
					return null;
				}

				if ( this.honk + 20 > Game13.timeofday ) {
					return null;
				}
				this.add_fingerprint( b );
				((Ent_Static)b).visible_message( "<span class='notice'>" + b + " honks at " + this + ".</span>", "<span class='notice'>You honk at " + this + ".</span>", "<span class='notice'>You hear honking.</span>" );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), a.hitsound, 50, 1 );

				if ( ( ((Reagents)this.reagents).get_reagent_amount( "banana" ) ?1:0) <= 5 ) {
					
					if ( this.activated ) {
						this.visible_message( "<span class='warning'>" + this.nick + " lets out a last honk before running out of fuel and activating its ejection seat.</span>" );

						if ( b is Mob_Living_Carbon_Human ) {
							((Mob)b).Weaken( 5 );
						}
						GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/bikehorn.ogg", 50, 1 );
						this.activated = false;
						((Reagents)this.reagents).remove_reagent( "banana", 5 );
					} else {
						GlobalFuncs.to_chat( b, "<span class='warning'>" + this + " doesn't have enough banana essence!</span>" );
					}
				} else {
					Task13.Schedule( 5, (Task13.Closure)(() => {
						this.activated = true;
						this.visible_message( "<span class='notice'>" + this.nick + " honks back happily.</span>" );
						GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/bikehorn.ogg", 50, 1 );
						return;
					}));
				}
				this.honk = Game13.timeofday;
			} else if ( a is Obj_Item_Weapon_ReagentContainers ) {
				
				if ( this.feed( a, b ) != 0 ) {
					this.visible_message( "<span class='notice'>" + b + " puts " + a + " into " + this + ".</span>" );
					GlobalFuncs.qdel( a );
				}
			} else if ( a is Obj_Item_Weapon_Storage_Bag_Plants ) {
				ate_anything = 0;
				B = a;

				foreach (dynamic _a in Lang13.Enumerate( a.contents, typeof(Obj_Item) )) {
					I = _a;
					

					if ( this.feed( I, b ) != 0 ) {
						ate_anything += 1;
						((Obj_Item_Weapon_Storage)B).remove_from_storage( I, null );
						GlobalFuncs.qdel( I );
					}
				}

				if ( ate_anything != 0 ) {
					this.visible_message( new Txt( "<span class='notice'>" ).item( b ).str( " empties " ).the( a ).item().str( " into " ).item( this ).str( ".</span>" ).ToString() );
					GlobalFuncs.to_chat( b, new Txt( "Added " ).item( ate_anything ).str( " item" ).s().str( " to " ).the( this ).item().str( "." ).ToString() );
				}
			} else if ( a is Obj_Item_Weapon_Bananapeel ) {
				this.visible_message( new Txt( "<span class='notice'>" ).item( b ).str( " applies " ).item( a ).str( " to " ).the( this ).item().str( ".</span>" ).ToString() );
				this.health += 10;
				this.empstun -= 1;

				if ( this.health > this.max_health ) {
					this.health = this.max_health;
				}

				if ( this.empstun == 0 ) {
					this.visible_message( new Txt( "<span class='danger'>" ).The( this ).item().str( " comes back to life!</span>" ).ToString() );
				}

				if ( this.empstun < 0 ) {
					this.empstun = 0;
				}
				GlobalFuncs.qdel( a );
			} else if ( a is Obj_Item_Seeds_Bananaseed ) {
				this.visible_message( new Txt( "<span class='notice'>" ).item( b ).str( " applies " ).item( a ).str( " to " ).the( this ).item().str( ".</span>" ).ToString() );
				this.health += 50;

				if ( this.health > this.max_health ) {
					this.health = this.max_health;
				}

				if ( this.empstun != 0 ) {
					this.empstun = 0;
					this.visible_message( new Txt( "<span class='danger'>" ).The( this ).item().str( " comes back to life!</span>" ).ToString() );
				}
				GlobalFuncs.qdel( a );
			} else if ( a is Obj_Item_Stack_Sheet_Mineral_Clown ) {
				
				if ( this.max_health >= this.max_health_top ) {
					GlobalFuncs.to_chat( b, "<span class='notice'>You fail to reinforce " + this + " any further.</span>" );
					return null;
				}
				this.visible_message( "<span class='notice'>" + b + " reinforces " + this + " with " + a + ".</span>" );
				this.max_health += 20;
				this.health += 20;

				switch ((double)( this.max_health )) {
					case 120:
						GlobalFuncs.to_chat( b, "You can now recharge your water flower using " + this + "'s HONKTech pump." );
						break;
					case 200:
						GlobalFuncs.to_chat( b, new Txt().The( this ).item().str( " will now convert food into banana essence a bit more effectively." ).ToString() );
						break;
					case 400:
						GlobalFuncs.to_chat( b, new Txt().The( this ).item().str( " will now convert food into banana essence much more effectively." ).ToString() );
						break;
					case 300:
						GlobalFuncs.to_chat( b, new Txt().The( this ).item().str( " will no longer use banana essence for powering its engine." ).ToString() );
						break;
				}
				ST = a;
				ST.use( 1 );
			} else if ( a is Obj_Item_Weapon_Coin_Clown ) {
				((Ent_Static)b).visible_message( "<span class='warning'>" + b + " inserts a bananium coin into " + this + ".</span>", "<span class='notice'>You insert a bananium coin into " + this + ".</span>" );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/machines/Ping.ogg", 50, 1 );
				this.mode += 1;

				if ( this.mode > 2 ) {
					this.mode = 0;
				}

				switch ((int)( this.mode )) {
					case 0:
						Task13.Schedule( 5, (Task13.Closure)(() => {
							this.visible_message( "<span class='warning'>" + this + "'s SynthPeel Generator turns off with a buzz.</span>" );
							GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/machines/buzz-sigh.ogg", 50, 1 );
							return;
						}));
						break;
					case 1:
						this.visible_message( "<span class='notice'>" + this + "'s SmartCrayon Mk.II deploys, ready to draw!</span>" );
						GlobalFuncs.to_chat( b, "<span class='notice'>Use a crayon to decide what you want to draw.<br>\n				Use stamps to change the colour of SmartCrayon Mk.II.</span>" );
						break;
					case 2:
						this.visible_message( "<span class='warning'>" + this + "'s SmartCrayon Mk.II disappears in a puff of art!</span>" );
						Task13.Schedule( 5, (Task13.Closure)(() => {
							GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/machines/Ping.ogg", 50, 1 );
							this.visible_message( "<span class='notice'>You hear a ping as " + this + "'s SynthPeel Generator starts transforming banana juice into slippery peels.</span>" );
							GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/machines/Ping.ogg", 50, 1 );
							return;
						}));
						break;
				}
				GlobalFuncs.qdel( a );
				a = null;
			} else if ( a is Obj_Item_Toy_Crayon ) {
				
				if ( this.mode == 1 ) {
					this.printing_text = String13.ToLower( Interface13.Input( b, "Enter a message to print. Possible options: 'rune', 'graffiti', 'paint', 'nothing'", "Message", this.printing_text, null, InputType.Any ) );
					this.printing_pos = 0;

					switch ((string)( this.printing_text )) {
						case "graffiti":
							GlobalFuncs.to_chat( b, "<span class='notice'>Set to draw graffiti!</span>" );
							break;
						case "rune":
							GlobalFuncs.to_chat( b, "<span class='notice'>Set to draw runes!</span>" );
							break;
						case "nothing":
							GlobalFuncs.to_chat( b, "<span class='warning'>No longer drawing anything.</span>" );
							break;
						case "paint":
							GlobalFuncs.to_chat( b, "<span class='notice'>Set to paint the floor!</span>" );
							break;
						default:
							GlobalFuncs.to_chat( b, "<span class='notice'>Set to print the following text: " + this.printing_text + ".</span>" );
							break;
					}
				}
			} else if ( a is Obj_Item_Toy_Waterflower ) {
				GlobalFuncs.to_chat( b, "<span class='notice'>You plug " + a + " into " + this + "!</span>" );

				if ( this.max_health >= 120 ) {
					
					if ( GlobalFuncs.do_after( b, this, 5 ) ) {
						((Reagents)a.reagents).remove_any( 10 );
						bananas = ((Reagents)this.reagents).get_reagent_amount( "banana" );
						((Reagents)this.reagents).remove_reagent( "banana", bananas );

						if ( ( this.reagents.total_volume ??0) >= 10 ) {
							this.visible_message( "<span class='notice'>The HONKTech pump has recharged " + a + ".</span>" );
							((Reagents)this.reagents).trans_to( a, 10 );
						} else {
							GlobalFuncs.to_chat( b, "<span class='warning'>There doesn't seem to be anything other than banana juice in " + this + "!</span>" );
						}
						((Reagents)this.reagents).add_reagent( "banana", bananas );
					}
				} else {
					GlobalFuncs.to_chat( b, "<span class='warning'>The HONKTech pump is not strong enough to do that yet. Reinforce it with more bananium sheets first.</span>" );
				}
			} else if ( a is Obj_Item_Weapon_Card_Emag ) {
				
				if ( !this.emagged ) {
					this.emagged = true;
					this.visible_message( "<span class='warning'>" + this + "'s eyes glow eerily red for a second.</span>" );
				}
			} else if ( a is Obj_Item_Weapon_Stamp ) {
				
				if ( this.mode == 1 ) {
					
					if ( a is Obj_Item_Weapon_Stamp_Captain ) {
						this.colour1 = "#004B8F";
						this.colour2 = "#0060B8";
						GlobalFuncs.to_chat( b, "Selected color: Condom Blue" );
					} else if ( a is Obj_Item_Weapon_Stamp_Ce ) {
						this.colour1 = "#FF6A00";
						this.colour2 = "#FF8432";
						GlobalFuncs.to_chat( b, "Selected color: Powerful Orange" );
					} else if ( a is Obj_Item_Weapon_Stamp_Clown ) {
						this.colour1 = "#FFFF00";
						this.colour2 = "#FFD000";
						GlobalFuncs.to_chat( b, "Selected color: Banana Yellow" );
					} else if ( a is Obj_Item_Weapon_Stamp_Cmo ) {
						this.colour1 = "#FFFFFF";
						this.colour2 = "#ECECEC";
						GlobalFuncs.to_chat( b, "Selected color: Sanitary White" );
					} else if ( a is Obj_Item_Weapon_Stamp_Denied ) {
						this.colour1 = "#FF0000";
						this.colour2 = "#E22C00";
						GlobalFuncs.to_chat( b, "Selected color: Red Denial" );
					} else if ( a is Obj_Item_Weapon_Stamp_Hop ) {
						this.colour1 = "#1CA800";
						this.colour2 = "#238E0E";
						GlobalFuncs.to_chat( b, "Selected color: Green Access" );
					} else if ( a is Obj_Item_Weapon_Stamp_Hos ) {
						this.colour1 = "#7F4D21";
						this.colour2 = "#B24611";
						GlobalFuncs.to_chat( b, "Selected color: Shitcurity Brown" );
					} else if ( a is Obj_Item_Weapon_Stamp_Rd ) {
						this.colour1 = "#D22EF7";
						this.colour2 = "#D312E5";
						GlobalFuncs.to_chat( b, "Selected color: Plasma Purple" );
					} else {
						this.colour1 = "#000000";
						this.colour2 = "#6D6D6D";
						GlobalFuncs.to_chat( b, "Selected color: Boring Black" );
					}
				}
			}
			return null;
		}

		// Function from file: clowncart.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );

			if ( this.max_health > 100 ) {
				GlobalFuncs.to_chat( user, "<span class='info'>It is reinforced with " + ( this.max_health - 100 ) / 20 + " bananium sheets.</span>" );
			}

			switch ((int)( this.mode )) {
				case 1:
					GlobalFuncs.to_chat( user, "Currently in drawing mode." );
					break;
				case 2:
					GlobalFuncs.to_chat( user, "Currently in banana mode." );
					break;
			}

			dynamic _b = this.health; // Was a switch-case, sorry for the mess.
			if ( Double.NegativeInfinity<=_b&&_b<=0 ) {
				GlobalFuncs.to_chat( user, "<span class='notice'>It appears slightly dented.</span>" );
			} else if ( 1<=_b&&_b<=0 ) {
				GlobalFuncs.to_chat( user, "<span class='warning'>It appears heavily dented.</span>" );
			} else if ( Double.NegativeInfinity<=_b&&_b<=0 ) {
				GlobalFuncs.to_chat( user, "<span class='danger'>It appears completely unsalvageable.</span>" );
			}
			return null;
		}

		// Function from file: clowncart.dm
		public override dynamic process(  ) {
			this.icon_state = "clowncart0";

			if ( this.empstun > 0 ) {
				this.empstun--;
			}

			if ( this.empstun < 0 ) {
				this.empstun = 0;
			}

			if ( this.activated ) {
				this.icon_state = "clowncart1";

				if ( !Lang13.Bool( this.occupant ) ) {
					this.activated = false;
					this.icon_state = "clowncart0";
				}
			}

			if ( this.trail < 0 ) {
				this.trail = 0;
			}
			return null;
		}

	}

}