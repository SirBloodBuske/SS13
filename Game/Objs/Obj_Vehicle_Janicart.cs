// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Vehicle_Janicart : Obj_Vehicle {

		public dynamic mybag = null;
		public bool floorbuffer = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.keytype = typeof(Obj_Item_Key_Janitor);
			this.icon_state = "pussywagon";
		}

		public Obj_Vehicle_Janicart ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: pimpin_ride.dm
		public override dynamic attack_hand( dynamic a = null, bool? b = null, bool? c = null ) {
			
			if ( Lang13.Bool( base.attack_hand( (object)(a), b, c ) ) ) {
				return 1;
			} else if ( Lang13.Bool( this.mybag ) ) {
				this.mybag.loc = GlobalFuncs.get_turf( a );
				((Mob)a).put_in_hands( this.mybag );
				this.mybag = null;
				this.update_icon();
			}
			return null;
		}

		// Function from file: pimpin_ride.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			this.overlays.Cut();

			if ( Lang13.Bool( this.mybag ) ) {
				this.overlays.Add( "cart_garbage" );
			}

			if ( this.floorbuffer ) {
				this.overlays.Add( "cart_buffer" );
			}
			return false;
		}

		// Function from file: pimpin_ride.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			
			if ( A is Obj_Item_Weapon_Storage_Bag_Trash ) {
				
				if ( this.keytype == typeof(Obj_Item_Key_Janitor) ) {
					
					if ( !Lang13.Bool( user.drop_item() ) ) {
						return null;
					}
					user.WriteMsg( new Txt( "<span class='notice'>You hook the trashbag onto " ).the( this.name ).item().str( ".</span>" ).ToString() );
					A.loc = this;
					this.mybag = A;
				}
			} else if ( A is Obj_Item_Janiupgrade ) {
				
				if ( this.keytype == typeof(Obj_Item_Key_Janitor) ) {
					this.floorbuffer = true;
					GlobalFuncs.qdel( A );
					user.WriteMsg( new Txt( "<span class='notice'>You upgrade " ).the( this.name ).item().str( " with the floor buffer.</span>" ).ToString() );
				}
			}
			this.update_icon();
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

		// Function from file: pimpin_ride.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );

			if ( this.floorbuffer ) {
				user.WriteMsg( "It has been upgraded with a floor buffer." );
			}
			return 0;
		}

		// Function from file: pimpin_ride.dm
		public override bool Moved( Ent_Static OldLoc = null, int? Dir = null ) {
			Ent_Static tile = null;
			dynamic A = null;

			
			if ( this.floorbuffer ) {
				tile = this.loc;

				if ( tile is Tile ) {
					tile.clean_blood();

					foreach (dynamic _a in Lang13.Enumerate( tile )) {
						A = _a;
						

						if ( A is Obj_Effect_Decal_Cleanable || A is Obj_Effect_Rune ) {
							GlobalFuncs.qdel( A );
						}
					}
				}
			}
			return false;
		}

		// Function from file: pimpin_ride.dm
		public override void handle_vehicle_offsets(  ) {
			base.handle_vehicle_offsets();

			if ( Lang13.Bool( this.buckled_mob ) ) {
				
				dynamic _a = this.buckled_mob.dir; // Was a switch-case, sorry for the mess.
				if ( _a==1 ) {
					this.buckled_mob.pixel_x = 0;
					this.buckled_mob.pixel_y = 4;
				} else if ( _a==4 ) {
					this.buckled_mob.pixel_x = -12;
					this.buckled_mob.pixel_y = 7;
				} else if ( _a==2 ) {
					this.buckled_mob.pixel_x = 0;
					this.buckled_mob.pixel_y = 7;
				} else if ( _a==8 ) {
					this.buckled_mob.pixel_x = 12;
					this.buckled_mob.pixel_y = 7;
				}
			}
			return;
		}

	}

}