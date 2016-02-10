// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Bookcase : Obj_Structure {

		public double health = 50;
		public bool busy = false;
		public ByTable valid_types = new ByTable(new object [] { typeof(Obj_Item_Weapon_Book), typeof(Obj_Item_Weapon_Tome), typeof(Obj_Item_Weapon_Spellbook), typeof(Obj_Item_Weapon_Storage_Bible) });

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.autoignition_temperature = 573.1500244140625;
			this.fire_fuel = 10;
			this.icon = "icons/obj/library.dmi";
			this.icon_state = "book-0";
		}

		public Obj_Structure_Bookcase ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: lib_items.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( this.contents.len < 5 ) {
				this.icon_state = "book-" + this.contents.len;
			} else {
				this.icon_state = "book-5";
			}
			return null;
		}

		// Function from file: lib_items.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			Obj_Item I = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj_Item) )) {
				I = _a;
				

				if ( GlobalFuncs.is_type_in_list( I, this.valid_types ) ) {
					I.forceMove( GlobalFuncs.get_turf( this ) );
				}
			}
			base.Destroy( (object)(brokenup) );
			return null;
		}

		// Function from file: lib_items.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			Obj_Item I = null;
			Obj_Item I2 = null;

			
			switch ((int?)( severity )) {
				case 1:
					
					foreach (dynamic _a in Lang13.Enumerate( this.contents, typeof(Obj_Item) )) {
						I = _a;
						
						GlobalFuncs.qdel( I );
					}
					GlobalFuncs.qdel( this );
					return false;
					break;
				case 2:
					
					foreach (dynamic _b in Lang13.Enumerate( this.contents, typeof(Obj_Item) )) {
						I2 = _b;
						

						if ( Rand13.PercentChance( 50 ) ) {
							GlobalFuncs.qdel( I2 );
						}
					}
					GlobalFuncs.qdel( this );
					return false;
					break;
				case 3:
					
					if ( Rand13.PercentChance( 50 ) ) {
						GlobalFuncs.qdel( this );
					}
					return false;
					break;
			}
			return false;
		}

		// Function from file: lib_items.dm
		public override dynamic attack_ghost( Mob_Dead_Observer user = null ) {
			dynamic choice = null;

			
			if ( this.contents.len != 0 && GlobalFuncs.in_range( user, this ) ) {
				choice = Interface13.Input( "Which book would you like to read?", null, null, null, this.contents, InputType.Obj | InputType.Null );

				if ( Lang13.Bool( choice ) ) {
					
					if ( !( choice is Obj_Item_Weapon_Book ) ) {
						GlobalFuncs.to_chat( user, "A mysterious force is keeping you from reading that." );
						return null;
					}
					((Obj_Item_Weapon_Book)choice).read_a_motherfucking_book( user );
				}
			}
			return null;
		}

		// Function from file: lib_items.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic choice = null;

			
			if ( this.contents.len != 0 ) {
				choice = Interface13.Input( new Txt( "Which book would you like to remove from " ).the( this ).item().str( "?" ).ToString(), null, null, null, this.contents, InputType.Obj | InputType.Null );

				if ( Lang13.Bool( choice ) ) {
					
					if ( ((Mob)a).incapacitated() || a.lying == true || Map13.GetDistance( a, this ) > 1 ) {
						return null;
					}

					if ( !Lang13.Bool( ((Mob)a).get_active_hand() ) ) {
						((Mob)a).put_in_hands( choice );
					} else {
						((Ent_Dynamic)choice).forceMove( GlobalFuncs.get_turf( this ) );
					}
					this.update_icon();
				}
			}
			return null;
		}

		// Function from file: lib_items.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic newname = null;

			
			if ( this.busy ) {
				return null;
			}

			if ( GlobalFuncs.is_type_in_list( a, this.valid_types ) ) {
				b.drop_item( a, this );
				this.update_icon();
			} else if ( a is Obj_Item_Weapon_Screwdriver && b.a_intent == "help" ) {
				GlobalFuncs.to_chat( b, new Txt( "<span class='notice'>There are no screws on " ).the( this ).item().str( ", it appears to be nailed together. You could probably disassemble it with just a crowbar.</span>" ).ToString() );
				return null;
			} else if ( a is Obj_Item_Weapon_Crowbar && b.a_intent == "help" ) {
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Crowbar.ogg", 75, 1 );
				((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " starts disassembling " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You start disassembling " ).the( this ).item().str( ".</span>" ).ToString() );
				this.busy = true;

				if ( GlobalFuncs.do_after( b, this, 50 ) ) {
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Deconstruct.ogg", 75, 1 );
					((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " disassembles " ).the( this ).item().str( ".</span>" ).ToString(), new Txt( "<span class='notice'>You disassemble " ).the( this ).item().str( ".</span>" ).ToString() );
					this.busy = false;
					GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Sheet_Wood), GlobalFuncs.get_turf( this ), 5 );
					GlobalFuncs.qdel( this );
					return null;
				} else {
					this.busy = false;
				}
				return null;
			} else if ( a is Obj_Item_Weapon_Wrench ) {
				this.anchored = !Lang13.Bool( this.anchored );
				GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Ratchet.ogg", 50, 1 );
				((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).item( b ).str( " " ).item( ( Lang13.Bool( this.anchored ) ? "" : "un" ) ).str( "anchors " ).the( this ).item().str( " " ).item( ( Lang13.Bool( this.anchored ) ? "to" : "from" ) ).str( " the floor.</span>" ).ToString(), "<span class='notice'>You " + ( Lang13.Bool( this.anchored ) ? "" : "un" ) + "anchor the " + this + " " + ( Lang13.Bool( this.anchored ) ? "to" : "from" ) + " the floor.</span>" );
			} else if ( a is Obj_Item_Weapon_Pen ) {
				newname = GlobalFuncs.stripped_input( b, "What category title would you like to give to this " + this.name + "?" );

				if ( !Lang13.Bool( newname ) ) {
					return null;
				} else {
					this.name = "bookcase (" + GlobalFuncs.sanitize( newname ) + ")";
				}
			} else if ( a.damtype == "brute" || a.damtype == "fire" ) {
				((Mob)b).delayNextAttack( 10 );
				this.health -= Convert.ToDouble( a.force );
				((Ent_Static)b).visible_message( new Txt( "<span class='warning'>" ).The( b ).item().str( " hits " ).the( this ).item().str( " with " ).the( a ).item().str( ".</span>" ).ToString(), new Txt( "<span class='warning'>You hit " ).the( this ).item().str( " with " ).the( a ).item().str( ".</span>" ).ToString() );
				this.healthcheck();
			} else {
				return base.attackby( (object)(a), (object)(b), (object)(c) );
			}
			return null;
		}

		// Function from file: lib_items.dm
		public void healthcheck(  ) {
			
			if ( this.health <= 0 ) {
				this.visible_message( new Txt( "<span class='warning'>" ).The( this ).item().str( " breaks apart!</span>" ).ToString() );
				GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Sheet_Wood), GlobalFuncs.get_turf( this ), 3 );
				GlobalFuncs.qdel( this );
			}
			return;
		}

		// Function from file: lib_items.dm
		public override bool initialize( bool? suppress_icon_check = null ) {
			Obj_Item I = null;

			
			foreach (dynamic _a in Lang13.Enumerate( this.loc, typeof(Obj_Item) )) {
				I = _a;
				

				if ( GlobalFuncs.is_type_in_list( I, this.valid_types ) ) {
					I.forceMove( this );
				}
			}
			this.update_icon();
			return false;
		}

		// Function from file: lib_items.dm
		public override dynamic cultify(  ) {
			return null;
		}

	}

}