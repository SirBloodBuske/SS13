// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Wall_RWall : Tile_Simulated_Wall {

		public int d_state = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.explosion_resistance = 25;
			this.walltype = "rwall";
			this.hardness = 90;
			this.explosion_block = 2;
			this.girder_type = typeof(Obj_Structure_Girder_Reinforced);
			this.penetration_dampening = 20;
			this.icon_state = "r_wall";
		}

		public Tile_Simulated_Wall_RWall ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: walls_reinforced.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			
			if ( this.rotting ) {
				severity = 1;
			}

			switch ((int?)(severity)) {
				case 1:
					
					if ( Rand13.PercentChance( 66 ) ) {
						this.dismantle_wall( false, true );
					} else {
						this.dismantle_wall( true, true );
					}
					break;
				case 2:
					
					if ( Rand13.PercentChance( 75 ) && this.d_state == 0 ) {
						this.d_state = 4;
						this.update_icon();
						GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Sheet_Plasteel), GlobalFuncs.get_turf( this ) );
					} else {
						this.dismantle_wall( false, true );
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 15 ) ) {
						this.dismantle_wall( false, true );
					} else {
						this.d_state = 1;
						this.update_icon();
					}
					break;
			}
			return false;
		}

		// Function from file: walls_reinforced.dm
		public override void dismantle_wall( bool? devastated = null, bool? explode = null ) {
			devastated = devastated ?? false;
			explode = explode ?? false;

			Obj O = null;
			Obj P = null;

			
			if ( !( devastated == true ) ) {
				GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Sheet_Plasteel), this );
			} else {
				GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Rods), this, 2 );
				GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Sheet_Plasteel), this );
			}

			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj) )) {
				O = _a;
				

				if ( O is Obj_Structure_Sign_Poster ) {
					P = O;
					((dynamic)P).roll_and_drop( this );
				}
			}
			this.ChangeTurf( this.dismantle_type );
			return;
		}

		// Function from file: walls_reinforced.dm
		public override bool singularity_pull( Obj S = null, double? current_size = null, int? radiations = null ) {
			
			if ( ( current_size ??0) >= 9 ) {
				
				if ( Rand13.PercentChance( 30 ) ) {
					this.dismantle_wall();
				}
			}
			return false;
		}

		// Function from file: walls_reinforced.dm
		public override bool attack_construct( Mob_Living_SimpleAnimal_Construct user = null, dynamic dist = null ) {
			return false;
		}

		// Function from file: walls_reinforced.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic S = null;
			Obj_Effect E = null;
			Obj_Effect E2 = null;
			double pdiff = 0;
			dynamic WT = null;
			dynamic WT2 = null;
			dynamic WT3 = null;
			dynamic P = null;
			dynamic WT4 = null;
			dynamic WT5 = null;
			dynamic PK = null;

			
			if ( !Lang13.Bool( b.dexterity_check() ) ) {
				GlobalFuncs.to_chat( b, "<span class='warning'>You don't have the dexterity to do this!</span>" );
				return null;
			}

			if ( a is Obj_Item_Weapon_Solder && this.bullet_marks ) {
				S = a;

				if ( !Lang13.Bool( S.remove_fuel( ( this.bullet_marks ?1:0) * 2, b ) ) ) {
					return null;
				}
				GlobalFuncs.playsound( this.loc, "sound/items/welder.ogg", 100, 1 );
				GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>You remove the bullet marks with " ).the( a ).item().str( ".</span>" ).ToString() );
				this.bullet_marks = false;
				this.icon = Lang13.Initial( this, "icon" );
				return null;
			}

			if ( !( b.loc is Tile ) ) {
				return null;
			}

			if ( this.rotting ) {
				
				if ( Lang13.Bool( ((Obj)a).is_hot() ) ) {
					((Ent_Static)b).visible_message( new Txt( "<span class='notice'>" ).item( b ).str( " burns the fungi away with " ).the( a ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You burn the fungi away with " ).the( a ).item().str( ".</span>" ).ToString() );
					GlobalFuncs.playsound( this, "sound/items/welder.ogg", 10, 1 );

					foreach (dynamic _a in Lang13.Enumerate( this, typeof(Obj_Effect) )) {
						E = _a;
						

						if ( E.name == "Wallrot" ) {
							GlobalFuncs.qdel( E );
						}
					}
					this.rotting = false;
					return null;
				}

				if ( a is Obj_Item_Weapon_Soap ) {
					((Ent_Static)b).visible_message( new Txt( "<span class='notice'>" ).item( b ).str( " forcefully scrubs the fungi away with " ).the( a ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You forcefully scrub the fungi away with " ).the( a ).item().str( ".</span>" ).ToString() );

					foreach (dynamic _b in Lang13.Enumerate( this, typeof(Obj_Effect) )) {
						E2 = _b;
						

						if ( E2.name == "Wallrot" ) {
							GlobalFuncs.qdel( E2 );
						}
					}
					this.rotting = false;
					return null;
				} else if ( !Lang13.Bool( ((Obj)a).is_sharp() ) && Convert.ToDouble( a.force ) >= 10 || Convert.ToDouble( a.force ) >= 20 ) {
					((Ent_Static)b).visible_message( new Txt( "<span class='warning'>With one strong swing, " ).item( b ).str( " destroys the rotting " ).item( this ).str( " with " ).the( a ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>With one strong swing, the rotting " ).item( this ).str( " crumbles away under " ).the( a ).item().str( ".</span>" ).ToString() );
					this.dismantle_wall();
					pdiff = GlobalFuncs.performWallPressureCheck( this.loc );

					if ( pdiff != 0 ) {
						GlobalFuncs.message_admins( "" + b.real_name + " (" + GlobalFuncs.formatPlayerPanel( b, b.ckey ) + ") broke a rotting reinforced wall with a pdiff of " + pdiff + " at " + GlobalFuncs.formatJumpTo( this.loc ) + "!" );
					}
					return null;
				}
			}

			if ( this.thermite && this.can_thermite ) {
				
				if ( Lang13.Bool( ((Obj)a).is_hot() ) ) {
					((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " applies " ).the( a ).item().str( " to the thermite coating " ).the( this ).item().str( " and waits.</span>" ).ToString(), new Txt( "<span class='warning'>You apply " ).the( a ).item().str( " to the thermite coating " ).the( this ).item().str( " and wait...</span>" ).ToString() );

					if ( GlobalFuncs.do_after( b, this, 100 ) && Lang13.Bool( ((Obj)a).is_hot() ) ) {
						this.thermitemelt( b );
						((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " sets " ).the( this ).item().str( " ablaze with " ).the( a ).item().str( "!</span>" ).ToString(), new Txt( "<span class='warning'>You set " ).the( this ).item().str( " ablaze with " ).the( a ).item().str( "!</span>" ).ToString() );
						return null;
					}
				}
			}

			switch ((int)( this.d_state )) {
				case 0:
					
					if ( a is Obj_Item_Weapon_Wirecutters ) {
						GlobalFuncs.playsound( this, "sound/items/Wirecutter.ogg", 100, 1 );
						this.d_state = 1;
						this.update_icon();
						((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " cuts out " ).the( this ).item().str( "'s outer grille.</span>" ).ToString(), new Txt( "<span class='notice'>You cut out " ).the( this ).item().str( "'s outer grille, exposing the external cover.</span>" ).ToString() );
						return null;
					}
					break;
				case 1:
					
					if ( a is Obj_Item_Weapon_Screwdriver ) {
						((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " begins unsecuring " ).the( this ).item().str( "'s external cover.</span>" ).ToString(), new Txt( "<span class='notice'>You begin unsecuring " ).the( this ).item().str( "'s external cover.</span>" ).ToString() );
						GlobalFuncs.playsound( this, "sound/items/Screwdriver.ogg", 100, 1 );

						if ( GlobalFuncs.do_after( b, this, 40 ) && this.d_state == 1 ) {
							this.d_state = 2;
							this.update_icon();
							((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " unsecures " ).the( this ).item().str( "'s external cover.</span>" ).ToString(), new Txt( "<span class='notice'>You unsecure " ).the( this ).item().str( "'s external cover.</span>" ).ToString() );
						}
						return null;
					} else if ( a is Obj_Item_Weapon_Weldingtool ) {
						WT = a;

						if ( ((Obj_Item_Weapon_Weldingtool)WT).remove_fuel( 0, b ) ) {
							((Ent_Static)b).visible_message( new Txt( "<span class='notice'>" ).item( b ).str( " begins mending the damage on " ).the( this ).item().str( "'s outer grille.</span>" ).ToString(), new Txt( "<span class='notice'>You begin mending the damage on " ).the( this ).item().str( "'s outer grille.</span>" ).ToString(), "<span class='warning'>You hear welding noises.</span>" );
							GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );

							if ( GlobalFuncs.do_after( b, this, 40 ) && this.d_state == 1 ) {
								GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );
								this.d_state = 0;
								this.update_icon();
								((Ent_Static)b).visible_message( new Txt( "<span class='notice'>" ).item( b ).str( " mends the damage on " ).the( this ).item().str( "'s outer grille.</span>" ).ToString(), new Txt( "<span class='notice'>You mend the damage on " ).the( this ).item().str( "'s outer grille.</span>" ).ToString(), "<span class='warning'>You hear welding noises.</span>" );
							}
						} else {
							GlobalFuncs.to_chat( b, "<span class='notice'>You need more welding fuel to complete this task.</span>" );
						}
						return null;
					}
					break;
				case 2:
					
					if ( a is Obj_Item_Weapon_Weldingtool ) {
						WT2 = a;

						if ( ((Obj_Item_Weapon_Weldingtool)WT2).remove_fuel( 0, b ) ) {
							((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " begins slicing through " ).the( this ).item().str( "'s external cover.</span>" ).ToString(), new Txt( "<span class='notice'>You begin slicing through " ).the( this ).item().str( "'s external cover.</span>" ).ToString(), "<span class='warning'>You hear welding noises.</span>" );
							GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );

							if ( GlobalFuncs.do_after( b, this, 60 ) && this.d_state == 2 ) {
								GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );
								this.d_state = 3;
								this.update_icon();
								((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " finishes weakening " ).the( this ).item().str( "'s external cover.</span>" ).ToString(), new Txt( "<span class='notice'>You finish weakening " ).the( this ).item().str( "'s external cover.</span>" ).ToString(), "<span class='warning'>You hear welding noises.</span>" );
							}
						} else {
							GlobalFuncs.to_chat( b, "<span class='notice'>You need more welding fuel to complete this task.</span>" );
						}
						return null;
					}

					if ( a is Obj_Item_Weapon_Pickaxe_Plasmacutter ) {
						((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " begins slicing through " ).the( this ).item().str( "'s external cover.</span>" ).ToString(), new Txt( "<span class='notice'>You begin slicing through " ).the( this ).item().str( "'s external cover.</span>" ).ToString(), "<span class='warning'>You hear welding noises.</span>" );
						GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );

						if ( GlobalFuncs.do_after( b, this, 40 ) && this.d_state == 2 ) {
							GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );
							this.d_state = 3;
							this.update_icon();
							((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " finishes weakening " ).the( this ).item().str( "'s external cover.</span>" ).ToString(), new Txt( "<span class='notice'>You finish weakening " ).the( this ).item().str( "'s external cover.</span>" ).ToString(), "<span class='warning'>You hear welding noises.</span>" );
						}
						return null;
					} else if ( a is Obj_Item_Weapon_Screwdriver ) {
						((Ent_Static)b).visible_message( new Txt( "<span class='notice'>" ).item( b ).str( " begins securing " ).the( this ).item().str( "'s external cover.</span>" ).ToString(), new Txt( "<span class='notice'>You begin securing " ).the( this ).item().str( "'s external cover.</span>" ).ToString() );
						GlobalFuncs.playsound( this, "sound/items/Screwdriver.ogg", 100, 1 );

						if ( GlobalFuncs.do_after( b, this, 40 ) && this.d_state == 2 ) {
							this.d_state = 1;
							this.update_icon();
							((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " secures " ).the( this ).item().str( "'s external cover.</span>" ).ToString(), new Txt( "<span class='notice'>You secure " ).the( this ).item().str( "'s external cover.</span>" ).ToString() );
						}
						return null;
					}
					break;
				case 3:
					
					if ( a is Obj_Item_Weapon_Crowbar ) {
						((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " starts prying off " ).the( this ).item().str( "'s external cover.</span>" ).ToString(), new Txt( "<span class='notice'>You struggle to pry off " ).the( this ).item().str( "'s external cover.</span>" ).ToString(), "<span class='warning'>You hear a crowbar.</span>" );
						GlobalFuncs.playsound( this, "sound/items/Crowbar.ogg", 100, 1 );

						if ( GlobalFuncs.do_after( b, this, 100 ) && this.d_state == 3 ) {
							GlobalFuncs.playsound( this, "sound/items/Deconstruct.ogg", 100, 1 );
							this.d_state = 4;
							this.update_icon();
							GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Sheet_Plasteel), GlobalFuncs.get_turf( this ) );
							((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " pries off " ).the( this ).item().str( "'s external cover.</span>" ).ToString(), new Txt( "<span class='notice'>You pry off " ).the( this ).item().str( "'s external cover.</span>" ).ToString() );
						}
						return null;
					} else if ( a is Obj_Item_Weapon_Weldingtool ) {
						WT3 = a;

						if ( ((Obj_Item_Weapon_Weldingtool)WT3).remove_fuel( 0, b ) ) {
							((Ent_Static)b).visible_message( new Txt( "<span class='notice'>" ).item( b ).str( " begins fixing the welding damage on " ).the( this ).item().str( "'s external cover.</span>" ).ToString(), new Txt( "<span class='notice'>You begin fixing the welding damage on " ).the( this ).item().str( "'s external cover.</span>" ).ToString(), "<span class='warning'>You hear welding noises.</span>" );
							GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );

							if ( GlobalFuncs.do_after( b, this, 60 ) && this.d_state == 3 ) {
								GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );
								this.d_state = 2;
								this.update_icon();
								((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " fixes the welding damage on " ).the( this ).item().str( "'s external cover.</span>" ).ToString(), new Txt( "<span class='notice'>You fix the welding damage on " ).the( this ).item().str( "'s external cover.</span>" ).ToString(), "<span class='warning'>You hear welding noises.</span>" );
							}
						} else {
							GlobalFuncs.to_chat( b, "<span class='notice'>You need more welding fuel to complete this task.</span>" );
						}
						return null;
					}
					break;
				case 4:
					
					if ( a is Obj_Item_Weapon_Wrench ) {
						((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " starts loosening the bolts anchoring " ).the( this ).item().str( "'s external support rods.</span>" ).ToString(), new Txt( "<span class='notice'>You start loosening the bolts anchoring " ).the( this ).item().str( "'s external support rods.</span>" ).ToString() );
						GlobalFuncs.playsound( this, "sound/items/Ratchet.ogg", 100, 1 );

						if ( GlobalFuncs.do_after( b, this, 40 ) && this.d_state == 4 ) {
							this.d_state = 5;
							this.update_icon();
							((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " loosens the bolts anchoring " ).the( this ).item().str( "'s external support rods.</span>" ).ToString(), new Txt( "<span class='notice'>You loosen the bolts anchoring " ).the( this ).item().str( "'s external support rods.</span>" ).ToString() );
						}
						return null;
					} else if ( a is Obj_Item_Stack_Sheet_Plasteel ) {
						P = a;
						((Ent_Static)b).visible_message( new Txt( "<span class='notice'>" ).item( b ).str( " starts installing an external cover to " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You start installing an external cover to " ).the( this ).item().str( ".</span>" ).ToString() );
						GlobalFuncs.playsound( this, "sound/items/Deconstruct.ogg", 100, 1 );

						if ( GlobalFuncs.do_after( b, this, 50 ) && this.d_state == 4 ) {
							((Obj_Item_Stack)P).use( 1 );
							this.d_state = 0;
							this.update_icon();
							((Ent_Static)b).visible_message( new Txt( "<span class='notice'>" ).item( b ).str( " finishes installing an external cover to " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You finish installing an external cover to " ).the( this ).item().str( ".</span>" ).ToString() );
						}
						return null;
					}
					break;
				case 5:
					
					if ( a is Obj_Item_Weapon_Weldingtool ) {
						WT4 = a;

						if ( ((Obj_Item_Weapon_Weldingtool)WT4).remove_fuel( 0, b ) ) {
							((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " begins slicing through " ).the( this ).item().str( "'s external support rods.</span>" ).ToString(), new Txt( "<span class='notice'>You begin slicing through " ).the( this ).item().str( "'s external support rods.</span>" ).ToString() );
							GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );

							if ( GlobalFuncs.do_after( b, this, 100 ) && this.d_state == 5 ) {
								GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );
								this.d_state = 6;
								this.update_icon();
								((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " slices through " ).the( this ).item().str( "'s external support rods.</span>" ).ToString(), new Txt( "<span class='notice'>You slice through " ).the( this ).item().str( "'s external support rods, exposing its internal cover.</span>" ).ToString() );
							}
						} else {
							GlobalFuncs.to_chat( b, "<span class='notice'>You need more welding fuel to complete this task.</span>" );
						}
						return null;
					}

					if ( a is Obj_Item_Weapon_Pickaxe_Plasmacutter ) {
						((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " begins slicing through " ).the( this ).item().str( "'s external support rods.</span>" ).ToString(), new Txt( "<span class='notice'>You begin slicing through " ).the( this ).item().str( "'s external support rods.</span>" ).ToString() );
						GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );

						if ( GlobalFuncs.do_after( b, this, 70 ) ) {
							GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );
							this.d_state = 6;
							this.update_icon();
							((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " slices through " ).the( this ).item().str( "'s external support rods.</span>" ).ToString(), new Txt( "<span class='notice'>You slice through " ).the( this ).item().str( "'s external support rods, exposing its internal cover.</span>" ).ToString() );
						}
						return null;
					} else if ( a is Obj_Item_Weapon_Wrench ) {
						((Ent_Static)b).visible_message( new Txt( "<span class='notice'>" ).item( b ).str( " starts tightening the bolts anchoring " ).the( this ).item().str( "'s external support rods.</span>" ).ToString(), new Txt( "<span class='notice'>You start tightening the bolts anchoring " ).the( this ).item().str( "'s external support rods.</span>" ).ToString() );
						GlobalFuncs.playsound( this, "sound/items/Ratchet.ogg", 100, 1 );

						if ( GlobalFuncs.do_after( b, this, 40 ) && this.d_state == 5 ) {
							this.d_state = 4;
							this.update_icon();
							((Ent_Static)b).visible_message( new Txt( "<span class='notice'>" ).item( b ).str( " tightens the bolts anchoring " ).the( this ).item().str( "'s external support rods.</span>" ).ToString(), new Txt( "<span class='notice'>You tighten the bolts anchoring " ).the( this ).item().str( "'s external support rods.</span>" ).ToString() );
						}
						return null;
					}
					break;
				case 6:
					
					if ( a is Obj_Item_Weapon_Crowbar ) {
						((Ent_Static)b).visible_message( "<span class='warning'>" + b + " starts prying off " + this + "'s internal cover.</span>", "<span class='notice'>You struggle to pry off " + this + "'s internal cover.</span>" );
						GlobalFuncs.playsound( this, "sound/items/Crowbar.ogg", 100, 1 );

						if ( GlobalFuncs.do_after( b, this, 100 ) && this.d_state == 6 ) {
							((Ent_Static)b).visible_message( "<span class='warning'>" + b + " pries off " + this + "'s internal cover.</span>", "<span class='notice'>You pry off " + this + "'s internal cover.</span>" );
							this.dismantle_wall();
							GlobalFuncs.playsound( this, "sound/items/Deconstruct.ogg", 100, 1 );
						}
						return null;
					} else if ( a is Obj_Item_Weapon_Weldingtool ) {
						WT5 = a;

						if ( ((Obj_Item_Weapon_Weldingtool)WT5).remove_fuel( 0, b ) ) {
							((Ent_Static)b).visible_message( new Txt( "<span class='notice'>" ).item( b ).str( " begins mending " ).the( this ).item().str( "'s external support rods.</span>" ).ToString(), new Txt( "<span class='notice'>You begin mending " ).the( this ).item().str( "'s external support rods.</span>" ).ToString() );
							GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );

							if ( GlobalFuncs.do_after( b, this, 100 ) && this.d_state == 6 ) {
								GlobalFuncs.playsound( this, "sound/items/welder.ogg", 100, 1 );
								this.d_state = 5;
								this.update_icon();
								((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " mends " ).the( this ).item().str( "'s external support rods.</span>" ).ToString(), new Txt( "<span class='notice'>You mend " ).the( this ).item().str( "'s external support rods.</span>" ).ToString() );
							}
						} else {
							GlobalFuncs.to_chat( b, "<span class='notice'>You need more welding fuel to complete this task.</span>" );
						}
						return null;
					}
					break;
			}

			if ( a is Obj_Item_Weapon_Pickaxe ) {
				PK = a;

				if ( !( ( PK.diggables & 8 ) != 0 ) ) {
					return null;
				}
				((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " begins " ).item( PK.drill_verb ).str( " straight into " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You begin " ).item( PK.drill_verb ).str( " straight into " ).the( this ).item().str( ".</span>" ).ToString() );
				GlobalFuncs.playsound( this, PK.drill_sound, 100, 1 );

				if ( GlobalFuncs.do_after( b, this, ( PK.digspeed ??0) * 50 ) ) {
					((Ent_Static)b).visible_message( new Txt( "<span class='notice'>" ).item( b ).str( "'s " ).item( PK ).str( " tears though the last of " ).the( this ).item().str( ", leaving nothing but a girder.</span>" ).ToString(), new Txt( "<span class='notice'>Your " ).item( PK ).str( " tears though the last of " ).the( this ).item().str( ", leaving nothing but a girder.</span>" ).ToString() );
					this.dismantle_wall();
				}
				return null;
			} else if ( a is Obj_Item_Mounted ) {
				return null;
			} else if ( !( this.d_state != 0 ) ) {
				return this.attack_hand( b );
			}
			return null;
		}

		// Function from file: walls_reinforced.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( !( this.d_state != 0 ) ) {
				this.relativewall();
				this.relativewall_neighbours();
				return null;
			}
			this.icon_state = "r_wall-" + this.d_state;
			return null;
		}

		// Function from file: walls_reinforced.dm
		public override void relativewall(  ) {
			
			if ( this.d_state != 0 ) {
				return;
			}
			base.relativewall();
			return;
		}

		// Function from file: walls_reinforced.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			base.examine( (object)(user), size );

			if ( this.d_state != 0 ) {
				
				switch ((int)( this.d_state )) {
					case 1:
						GlobalFuncs.to_chat( user, "It has no outer grille" );
						break;
					case 2:
						GlobalFuncs.to_chat( user, "It has no outer grille and the external reinforced cover is exposed" );
						break;
					case 3:
						GlobalFuncs.to_chat( user, "It has no outer grille and the external reinforced cover has been welded into" );
						break;
					case 4:
						GlobalFuncs.to_chat( user, "It has no outer grille or external reinforced cover and the external support rods are exposed" );
						break;
					case 5:
						GlobalFuncs.to_chat( user, "It has no outer grille or external reinforced cover and the external support rods are loose" );
						break;
					case 6:
						GlobalFuncs.to_chat( user, "It has no outer grille, external reinforced cover or external support rods and the inner reinforced cover is exposed" );
						break;
				}
			}
			return null;
		}

	}

}