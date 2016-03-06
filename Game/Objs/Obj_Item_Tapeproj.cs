// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Tapeproj : Obj_Item {

		public dynamic start = null;
		public dynamic end = null;
		public Type tape_type = typeof(Obj_Item_Holotape);
		public string icon_base = null;
		public bool charging = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 2;
			this.origin_tech = "materials=1;engineering=1";
			this.icon = "icons/obj/holotape.dmi";
			this.icon_state = "rollstart";
		}

		public Obj_Item_Tapeproj ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: holotape.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			dynamic turf = null;
			dynamic W = null;
			dynamic tape = null;

			
			if ( this.charging ) {
				return false;
			}

			if ( proximity_flag == false ) {
				return false;
			}

			if ( target is Obj_Machinery_Door_Airlock || target is Obj_Machinery_Door_Firedoor || target is Obj_Structure_Window ) {
				turf = GlobalFuncs.get_turf( target );

				if ( Lang13.Bool( Lang13.FindIn( this.tape_type, turf ) ) ) {
					return false;
				}

				if ( target is Obj_Structure_Window ) {
					W = target;

					if ( !( Convert.ToInt32( W.dir ) == 5 ) || !W.fulltile ) {
						return false;
					}
				}
				user.WriteMsg( "<span class='notice'>You start projecting the " + this.icon_base + " holotape onto " + target + "...</span>" );

				if ( !GlobalFuncs.do_mob( user, target, 30 ) ) {
					return false;
				}
				tape = Lang13.Call( this.tape_type, turf );
				tape.icon_state = "" + this.icon_base + "_door";
				tape.layer = 3.2;
				user.WriteMsg( "<span class='notice'>You project the " + this.icon_base + " holotape onto " + target + ".</span>" );
				this.charging = true;
				Task13.Schedule( 40, (Task13.Closure)(() => {
					this.charging = false;
					return;
				}));
			}
			return false;
		}

		// Function from file: holotape.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			dynamic cur = null;
			string dir = null;
			double d = 0;
			double d2 = 0;
			bool can_place = false;
			Obj O = null;
			bool tapetest = false;
			Obj_Item_Holotape Ptest = null;
			dynamic P = null;

			
			if ( this.charging ) {
				Task13.User.WriteMsg( "<span class='warning'>" + this + " is recharging!</span>" );
				return null;
			}

			if ( this.icon_state == "" + this.icon_base + "_start" ) {
				this.start = GlobalFuncs.get_turf( this );
				Task13.User.WriteMsg( "<span class='notice'>You project the start of the " + this.icon_base + " holotape.</span>" );
				this.icon_state = "" + this.icon_base + "_stop";
			} else {
				this.icon_state = "" + this.icon_base + "_start";
				this.end = GlobalFuncs.get_turf( this );

				if ( this.start.y != this.end.y && this.start.x != this.end.x || this.start.z != this.end.z ) {
					Task13.User.WriteMsg( "<span class='warning'>" + this + " can only be projected horizontally or vertically.</span>" );
					return null;
				}

				if ( Map13.GetDistance( this.start, this.end ) >= 3 ) {
					Task13.User.WriteMsg( "<span class='warning'>Your holotape segment is too long! It must be " + 3 + " tiles long or shorter!</span>" );
					return null;
				}
				cur = this.start;

				if ( this.start.x == this.end.x ) {
					d = Convert.ToDouble( this.end.y - this.start.y );

					if ( d != 0 ) {
						d = d / Math.Abs( d );
					}
					this.end = GlobalFuncs.get_turf( Map13.GetTile( Convert.ToInt32( this.end.x ), Convert.ToInt32( this.end.y + d ), Convert.ToInt32( this.end.z ) ) );
					dir = "v";
				} else {
					d2 = Convert.ToDouble( this.end.x - this.start.x );

					if ( d2 != 0 ) {
						d2 = d2 / Math.Abs( d2 );
					}
					this.end = GlobalFuncs.get_turf( Map13.GetTile( Convert.ToInt32( this.end.x + d2 ), Convert.ToInt32( this.end.y ), Convert.ToInt32( this.end.z ) ) );
					dir = "h";
				}
				can_place = true;

				while (cur != this.end && can_place) {
					
					if ( cur.density ) {
						can_place = false;
					} else if ( cur is Tile_Space ) {
						can_place = false;
					} else {
						
						foreach (dynamic _a in Lang13.Enumerate( cur, typeof(Obj) )) {
							O = _a;
							

							if ( !( O is Obj_Item_Holotape ) && O.density ) {
								can_place = false;
								break;
							}
						}
					}
					cur = Map13.GetStepTowardsSimple( cur, this.end );
				}

				if ( !can_place ) {
					Task13.User.WriteMsg( "<span class='warning'>You can't project the " + this.icon_base + " holotape through that!</span>" );
					return null;
				}
				cur = this.start;
				tapetest = false;

				while (cur != this.end) {
					
					foreach (dynamic _b in Lang13.Enumerate( cur, typeof(Obj_Item_Holotape) )) {
						Ptest = _b;
						

						if ( Ptest.icon_state == "" + Ptest.icon_base + "_" + dir ) {
							tapetest = true;
						}
					}

					if ( !tapetest ) {
						P = Lang13.Call( this.tape_type, cur );
						P.icon_state = "" + P.icon_base + "_" + dir;
					}
					cur = Map13.GetStepTowardsSimple( cur, this.end );
				}
				((Ent_Static)user).visible_message( "" + user + " finishes projecting the length of " + this.icon_base + " holotape.", "<span class='notice'>You finish projecting the length of " + this.icon_base + " holotape.</span>" );
				this.charging = true;
				Task13.Schedule( 40, (Task13.Closure)(() => {
					this.charging = false;
					return;
				}));
			}
			return null;
		}

		// Function from file: holotape.dm
		public void reset(  ) {
			
			if ( this.icon_state == "" + this.icon_base + "_stop" ) {
				this.icon_state = "" + this.icon_base + "_start";
				this.start = null;
				return;
			}
			return;
		}

		// Function from file: holotape.dm
		public override void equipped( Mob user = null, dynamic slot = null ) {
			this.reset();
			return;
		}

		// Function from file: holotape.dm
		public override bool dropped( dynamic user = null ) {
			this.reset();
			return false;
		}

	}

}