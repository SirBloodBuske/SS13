// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Power_Solar : Obj_Machinery_Power {

		public string id;
		public double health = 10;
		public bool obscured = false;
		public double sunfrac = 0;
		public double? adir = 2;
		public int ndir = 2;
		public bool turn_angle = false;
		public Obj_Machinery_Power_SolarControl control = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "sp_base";
		}

		// Function from file: solar.dm
		public Obj_Machinery_Power_Solar ( dynamic loc = null, Obj_Item_SolarAssembly S = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.Make( S );
			this.connect_to_network();
			return;
		}

		// Function from file: solar.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			base.ex_act( severity, (object)(target) );

			if ( !Lang13.Bool( this.gc_destroyed ) ) {
				
				switch ((int?)( severity )) {
					case 2:
						
						if ( Rand13.PercentChance( 50 ) ) {
							this.set_broken();
						}
						break;
					case 3:
						
						if ( Rand13.PercentChance( 25 ) ) {
							this.set_broken();
						}
						break;
				}
			}
			return false;
		}

		// Function from file: solar.dm
		public override int? process( dynamic seconds = null ) {
			double sgen = 0;

			
			if ( ( this.stat & 1 ) != 0 ) {
				return null;
			}

			if ( !( this.control != null ) ) {
				return null;
			}

			if ( Lang13.Bool( this.powernet ) ) {
				
				if ( this.powernet == this.control.powernet ) {
					
					if ( this.obscured ) {
						return null;
					}
					sgen = this.sunfrac * 1500;
					this.add_avail( sgen );
					this.control.gen += sgen;
				} else {
					this.unset_control();
				}
			}
			return null;
		}

		// Function from file: solar.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			base.update_icon( (object)(new_state), (object)(new_icon), new_px, new_py );
			this.overlays.Cut();

			if ( ( this.stat & 1 ) != 0 ) {
				this.overlays.Add( new Image( "icons/obj/power.dmi", null, "solar_panel-b", GlobalVars.FLY_LAYER ) );
			} else {
				this.overlays.Add( new Image( "icons/obj/power.dmi", null, "solar_panel", GlobalVars.FLY_LAYER ) );
				this.dir = ((int)( GlobalFuncs.angle2dir( this.adir ) ??0 ));
			}
			return false;
		}

		// Function from file: solar.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			dynamic S = null;

			
			if ( A is Obj_Item_Weapon_Crowbar ) {
				GlobalFuncs.playsound( this.loc, "sound/machines/click.ogg", 50, 1 );
				((Ent_Static)user).visible_message( "" + user + " begins to take the glass off the solar panel.", "<span class='notice'>You begin to take the glass off the solar panel...</span>" );

				if ( GlobalFuncs.do_after( user, 50 / A.toolspeed, null, this ) ) {
					S = Lang13.FindIn( typeof(Obj_Item_SolarAssembly), this );

					if ( Lang13.Bool( S ) ) {
						S.loc = this.loc;
						((Obj_Item_SolarAssembly)S).give_glass( this.stat & 1 );
					}
					GlobalFuncs.playsound( this.loc, "sound/items/Deconstruct.ogg", 50, 1 );
					((Ent_Static)user).visible_message( "" + user + " takes the glass off the solar panel.", "<span class='notice'>You take the glass off the solar panel.</span>" );
					GlobalFuncs.qdel( this );
				}
				return null;
			} else if ( Lang13.Bool( A ) ) {
				this.add_fingerprint( user );
				this.health -= Convert.ToDouble( A.force );
				this.healthcheck();
			}
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );
			return null;
		}

		// Function from file: solar.dm
		public void occlusion(  ) {
			double ax = 0;
			double ay = 0;
			Tile T = null;
			double dx = 0;
			double dy = 0;
			double i = 0;

			ax = this.x;
			ay = this.y;
			T = null;
			dx = GlobalVars.SSsun.dx;
			dy = GlobalVars.SSsun.dy;

			foreach (dynamic _a in Lang13.IterateRange( 1, 20 )) {
				i = _a;
				
				ax += dx;
				ay += dy;
				T = Map13.GetTile( ((int)( Num13.Round( ax, 0.5 ) )), ((int)( Num13.Round( ay, 0.5 ) )), this.z );

				if ( T.x == 1 || T.x == Game13.map_size_x || T.y == 1 || T.y == Game13.map_size_y ) {
					break;
				}

				if ( T.density ) {
					this.obscured = true;
					return;
				}
			}
			this.obscured = false;
			this.update_solar_exposure();
			return;
		}

		// Function from file: solar.dm
		public bool set_broken(  ) {
			bool _default = false;

			_default = !( ( this.stat & 1 ) != 0 );
			this.stat |= 1;
			this.unset_control();
			this.update_icon();
			return _default;
		}

		// Function from file: solar.dm
		public void update_solar_exposure(  ) {
			double p_angle = 0;

			
			if ( this.obscured ) {
				this.sunfrac = 0;
				return;
			}
			p_angle = Num13.MinInt( ((int)( Math.Abs( ( this.adir ??0) - GlobalVars.SSsun.angle ) )), ((int)( 360 - Math.Abs( ( this.adir ??0) - GlobalVars.SSsun.angle ) )) );

			if ( p_angle > 90 ) {
				this.sunfrac = 0;
				return;
			}
			this.sunfrac = Math.Pow( Math.Cos( p_angle ), 2 );
			return;
		}

		// Function from file: solar.dm
		public void healthcheck(  ) {
			
			if ( this.health <= 0 ) {
				
				if ( !( ( this.stat & 1 ) != 0 ) ) {
					this.set_broken();
				} else {
					new Obj_Item_Weapon_Shard( this.loc );
					new Obj_Item_Weapon_Shard( this.loc );
					GlobalFuncs.qdel( this );
					return;
				}
			}
			return;
		}

		// Function from file: solar.dm
		public void Make( Obj_Item_SolarAssembly S = null ) {
			
			if ( !( S != null ) ) {
				S = new Obj_Item_SolarAssembly( this );
				S.glass_type = typeof(Obj_Item_Stack_Sheet_Glass);
				S.anchored = 1;
			}
			S.loc = this;

			if ( S.glass_type == typeof(Obj_Item_Stack_Sheet_Rglass) ) {
				this.health *= 2;
			}
			this.update_icon();
			return;
		}

		// Function from file: solar.dm
		public void unset_control(  ) {
			
			if ( this.control != null ) {
				this.control.connected_panels.Remove( this );
			}
			this.control = null;
			return;
		}

		// Function from file: solar.dm
		public bool set_control( Obj_Machinery_Power_SolarControl SC = null ) {
			
			if ( !( SC != null ) || Map13.GetDistance( this, SC ) > 40 ) {
				return false;
			}
			this.control = SC;
			SC.connected_panels.Or( this );
			return true;
		}

		// Function from file: solar.dm
		public override dynamic Destroy(  ) {
			this.unset_control();
			return base.Destroy();
		}

	}

}