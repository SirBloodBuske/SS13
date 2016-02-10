// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Cable : Obj_Structure {

		public Powernet powernet = null;
		public double? d1 = 0;
		public double? d2 = 1;
		public Ent_Static attached = null;
		public string _color = "red";
		public bool build_status = false;
		public double oldavail = 0;
		public double oldnewavail = 0;
		public double oldload = 0;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.level = 1;
			this.anchored = 1;
			this.icon = "icons/obj/power_cond_white.dmi";
			this.icon_state = "0-1";
			this.layer = 2.44;
		}

		// Function from file: cable.dm
		public Obj_Structure_Cable ( dynamic loc = null ) : base( (object)(loc) ) {
			int dash = 0;
			Ent_Static T = null;
			dynamic Catwalk = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.cableColor( this._color );
			dash = String13.FindIgnoreCase( this.icon_state, "-", 1, 0 );
			this.d1 = String13.ParseNumber( String13.SubStr( this.icon_state, 1, dash ) );
			this.d2 = String13.ParseNumber( String13.SubStr( this.icon_state, dash + 1, 0 ) );
			T = this.loc;
			Catwalk = Lang13.FindIn( typeof(Obj_Structure_Catwalk), GlobalFuncs.get_turf( T ) );

			if ( !( T is Tile ) ) {
				
				if ( !Lang13.Bool( Catwalk ) ) {
					return;
				}
			}

			if ( this.level == 1 ) {
				this.hide( Lang13.BoolNullable( ((dynamic)T).intact ) );
			}
			GlobalVars.cable_list.Add( this );
			return;
		}

		// Function from file: cable.dm
		public override bool ex_act( double? severity = null, dynamic child = null ) {
			
			switch ((double?)( severity )) {
				case 1:
					GlobalFuncs.returnToPool( this );
					break;
				case 2:
					
					if ( Rand13.PercentChance( 50 ) ) {
						GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_CableCoil), this.loc, ( Lang13.Bool( this.d1 ) ? 2 : 1 ), this.light_color );
						GlobalFuncs.returnToPool( this );
					}
					break;
				case 3:
					
					if ( Rand13.PercentChance( 25 ) ) {
						GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_CableCoil), this.loc, ( Lang13.Bool( this.d1 ) ? 2 : 1 ), this.light_color );
						GlobalFuncs.returnToPool( this );
					}
					break;
			}
			return false;
		}

		// Function from file: cable.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Ent_Static T = null;
			string message = null;
			dynamic A = null;
			dynamic Z = null;
			dynamic my_area = null;
			dynamic M = null;
			dynamic coil = null;
			dynamic R = null;

			T = this.loc;

			if ( Lang13.Bool( ((dynamic)T).intact ) ) {
				return null;
			}

			if ( a is Obj_Item_Weapon_Wirecutters ) {
				
				if ( this.shock( b, 50 ) ) {
					return null;
				}

				if ( Lang13.Bool( this.d1 ) ) {
					GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_CableCoil), T, 2, this.light_color );
				} else {
					GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_CableCoil), T, 1, this.light_color );
				}
				((Ent_Static)b).visible_message( "<span class='warning'>" + b + " cuts the cable.</span>", "<span class='info'>You cut the cable.</span>" );
				message = "A wire has been cut ";
				A = b;

				if ( Lang13.Bool( A ) ) {
					Z = GlobalFuncs.get_turf( A );
					my_area = GlobalFuncs.get_area( Z );
					message += new Txt( "in " ).item( my_area.name ).str( ". (<A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" ).item( T.x ).str( ";Y=" ).item( T.y ).str( ";Z=" ).item( T.z ).str( "'>JMP</A>) (<A HREF='?_src_=vars;Vars=" ).Ref( A ).str( "'>VV</A>)" ).ToString();
					M = GlobalFuncs.get( A, typeof(Mob) );

					if ( Lang13.Bool( M ) ) {
						message += new Txt( " - Cut By: " ).item( M.real_name ).str( " (" ).item( M.key ).str( ") (<A HREF='?_src_=holder;adminplayeropts=" ).Ref( M ).str( "'>PP</A>) (<A HREF='?_src_=holder;adminmoreinfo=" ).Ref( M ).str( "'>?</A>)" ).ToString();
						GlobalVars.diary.WriteMsg( String13.HtmlDecode( "[" + GlobalFuncs.time_stamp() + "]GAME: " + ( "" + M.real_name + " (" + M.key + ") cut a wire in " + my_area.name + " (" + T.x + "," + T.y + "," + T.z + ")" ) ) );
					}
				}
				GlobalFuncs.message_admins( message );
				GlobalFuncs.returnToPool( this );
				return null;
			} else if ( a is Obj_Item_Stack_CableCoil ) {
				coil = a;
				((Obj_Item_Stack_CableCoil)coil).cable_join( this, b );
			} else if ( a is Obj_Item_Weapon_Rcl ) {
				R = a;

				if ( Lang13.Bool( R.loaded ) ) {
					((Obj_Item_Stack_CableCoil)R.loaded).cable_join( this, b );
					R.is_empty();
				}
			} else if ( a is Obj_Item_Device_Multitool ) {
				
				if ( this.powernet != null && this.powernet.avail > 0 ) {
					GlobalFuncs.to_chat( b, "<SPAN CLASS='warning'>" + this.powernet.avail + "W in power network.</SPAN>" );
				} else {
					GlobalFuncs.to_chat( b, "<SPAN CLASS='notice'>The cable is not powered.</SPAN>" );
				}
				this.shock( b, 5, 0.2 );
			} else if ( ((Obj)a).is_conductor() ) {
				this.shock( b, 50, 061 );
			}
			this.add_fingerprint( b );
			return null;
		}

		// Function from file: cable.dm
		public override void attack_tk( Mob user = null ) {
			return;
		}

		// Function from file: powernet.dm
		public bool rebuild_from(  ) {
			Game_Data NewPN = null;
			Obj_Structure_Cable C = null;
			Obj_Machinery_Power P = null;
			PowerConnection C2 = null;

			
			if ( !( this.powernet != null ) ) {
				NewPN = GlobalFuncs.getFromPool( typeof(Powernet) );
				((dynamic)NewPN).add_cable( this );
				GlobalFuncs.propagate_network( this, this.powernet );
				((dynamic)NewPN).load = this.oldload;
				((dynamic)NewPN).avail = this.oldavail;
				((dynamic)NewPN).newavail = this.oldnewavail;

				foreach (dynamic _a in Lang13.Enumerate( ((dynamic)NewPN).cables, typeof(Obj_Structure_Cable) )) {
					C = _a;
					
					C.oldload = 0;
					C.oldavail = 0;
					C.oldnewavail = 0;
					C.build_status = false;
				}

				foreach (dynamic _b in Lang13.Enumerate( ((dynamic)NewPN).nodes, typeof(Obj_Machinery_Power) )) {
					P = _b;
					
					P.build_status = false;
				}

				foreach (dynamic _c in Lang13.Enumerate( ((dynamic)NewPN).components, typeof(PowerConnection) )) {
					C2 = _c;
					
					C2.build_status = false;
				}
				return true;
			}
			return false;
		}

		// Function from file: cable.dm
		public void denode(  ) {
			Ent_Static T1 = null;
			ByTable powerlist = null;
			Game_Data PN = null;

			T1 = this.loc;

			if ( !( T1 != null ) ) {
				return;
			}
			powerlist = GlobalFuncs.power_list( T1, this, 0, false );

			if ( powerlist.len > 0 ) {
				PN = GlobalFuncs.getFromPool( typeof(Powernet) );
				GlobalFuncs.propagate_network( powerlist[1], PN );

				if ( Lang13.Bool( ((dynamic)PN).is_empty() ) ) {
					GlobalFuncs.returnToPool( PN );
				}
			}
			return;
		}

		// Function from file: cable.dm
		public ByTable get_connections( bool? powernetless_only = null ) {
			powernetless_only = powernetless_only ?? false;

			ByTable _default = null;

			Tile T = null;

			_default = new ByTable();

			if ( Lang13.Bool( this.d1 ) ) {
				T = Map13.GetStep( this, ((int)( this.d1 ??0 )) );

				if ( T != null ) {
					_default.Add( GlobalFuncs.power_list( T, this, Num13.Rotate( this.d1, 180 ), powernetless_only ) );
				}
			}

			if ( ( ((int)( this.d1 ??0 )) & ((int)( ( this.d1 ??0) - 1 )) ) != 0 ) {
				T = Map13.GetStep( this, ((int)( this.d1 ??0 )) & 3 );

				if ( T != null ) {
					_default.Add( GlobalFuncs.power_list( T, this, ((int)( this.d1 ??0 )) ^ 3, powernetless_only ) );
				}
				T = Map13.GetStep( this, ((int)( this.d1 ??0 )) & 12 );

				if ( T != null ) {
					_default.Add( GlobalFuncs.power_list( T, this, ((int)( this.d1 ??0 )) ^ 12, powernetless_only ) );
				}
			}
			_default.Add( GlobalFuncs.power_list( this.loc, this, this.d1, powernetless_only ) );
			T = Map13.GetStep( this, ((int)( this.d2 ??0 )) );

			if ( T != null ) {
				_default.Add( GlobalFuncs.power_list( T, this, Num13.Rotate( this.d2, 180 ), powernetless_only ) );
			}

			if ( ( ((int)( this.d2 ??0 )) & ((int)( ( this.d2 ??0) - 1 )) ) != 0 ) {
				T = Map13.GetStep( this, ((int)( this.d2 ??0 )) & 3 );

				if ( T != null ) {
					_default.Add( GlobalFuncs.power_list( T, this, ((int)( this.d2 ??0 )) ^ 3, powernetless_only ) );
				}
				T = Map13.GetStep( this, ((int)( this.d2 ??0 )) & 12 );

				if ( T != null ) {
					_default.Add( GlobalFuncs.power_list( T, this, ((int)( this.d2 ??0 )) ^ 12, powernetless_only ) );
				}
			}
			_default.Add( GlobalFuncs.power_list( this.loc, this, this.d2, powernetless_only ) );
			return _default;
		}

		// Function from file: cable.dm
		public void mergeConnectedNetworksOnTurf(  ) {
			ByTable to_connect = null;
			ByTable connections = null;
			Game_Data newPN = null;
			PowerConnection C = null;
			dynamic AM = null;
			dynamic C2 = null;
			dynamic N = null;
			dynamic M = null;
			Obj_Machinery_Power PM = null;
			PowerConnection PC = null;

			to_connect = new ByTable();
			connections = new ByTable();

			if ( !( this.powernet != null ) ) {
				newPN = GlobalFuncs.getFromPool( typeof(Powernet) );
				((dynamic)newPN).add_cable( this );
			}

			foreach (dynamic _a in Lang13.Enumerate( GlobalFuncs.get_turf( this ), typeof(PowerConnection) )) {
				C = _a;
				

				if ( C.powernet == this.powernet ) {
					continue;
				}
				connections.Add( C );
			}

			foreach (dynamic _b in Lang13.Enumerate( this.loc )) {
				AM = _b;
				

				if ( AM is Obj_Structure_Cable ) {
					C2 = AM;

					if ( C2.powernet == this.powernet ) {
						continue;
					}

					if ( Lang13.Bool( C2.powernet ) ) {
						GlobalFuncs.merge_powernets( this.powernet, C2.powernet );
					} else {
						this.powernet.add_cable( C2 );
					}
				} else if ( AM is Obj_Machinery_Power_Apc ) {
					N = AM;

					if ( !Lang13.Bool( N.terminal ) ) {
						continue;
					}

					if ( N.terminal.powernet == this.powernet ) {
						continue;
					}
					to_connect.Add( N.terminal );
				} else if ( AM is Obj_Machinery_Power ) {
					M = AM;

					if ( M.powernet == this.powernet ) {
						continue;
					}
					to_connect.Add( M );
				}
			}

			foreach (dynamic _c in Lang13.Enumerate( to_connect, typeof(Obj_Machinery_Power) )) {
				PM = _c;
				

				if ( !PM.connect_to_network() ) {
					PM.disconnect_from_network();
				}
			}

			foreach (dynamic _d in Lang13.Enumerate( connections, typeof(PowerConnection) )) {
				PC = _d;
				

				if ( !PC.connect() ) {
					PC.disconnect();
				}
			}
			return;
		}

		// Function from file: cable.dm
		public void mergeConnectedNetworks( double? direction = null ) {
			double? fdir = null;
			Tile TB = null;
			Obj_Structure_Cable C = null;
			Game_Data newPN = null;

			fdir = ( !Lang13.Bool( direction ) ? 0 : Num13.Rotate( direction, 180 ) );

			if ( !( this.d1 == direction || this.d2 == direction ) ) {
				return;
			}
			TB = Map13.GetStep( this, ((int)( direction ??0 )) );

			foreach (dynamic _a in Lang13.Enumerate( TB, typeof(Obj_Structure_Cable) )) {
				C = _a;
				

				if ( !( C != null ) ) {
					continue;
				}

				if ( this == C ) {
					continue;
				}

				if ( C.d1 == fdir || C.d2 == fdir ) {
					
					if ( !( C.powernet != null ) ) {
						newPN = GlobalFuncs.getFromPool( typeof(Powernet) );
						((dynamic)newPN).add_cable( C );
					}

					if ( this.powernet != null ) {
						GlobalFuncs.merge_powernets( this.powernet, C.powernet );
					} else {
						C.powernet.add_cable( this );
					}
				}
			}
			return;
		}

		// Function from file: cable.dm
		public void mergeDiagonalsNetworks( double? direction = null ) {
			Tile T = null;
			Obj_Structure_Cable C = null;
			Game_Data newPN = null;
			Obj_Structure_Cable C2 = null;
			Game_Data newPN2 = null;

			T = Map13.GetStep( this, ((int)( direction ??0 )) & 3 );

			foreach (dynamic _a in Lang13.Enumerate( T, typeof(Obj_Structure_Cable) )) {
				C = _a;
				

				if ( !( C != null ) ) {
					continue;
				}

				if ( this == C ) {
					continue;
				}

				if ( C.d1 == ( ((int)( direction ??0 )) ^ 3 ) || C.d2 == ( ((int)( direction ??0 )) ^ 3 ) ) {
					
					if ( !( C.powernet != null ) ) {
						newPN = GlobalFuncs.getFromPool( typeof(Powernet) );
						((dynamic)newPN).add_cable( C );
					}

					if ( this.powernet != null ) {
						GlobalFuncs.merge_powernets( this.powernet, C.powernet );
					} else {
						C.powernet.add_cable( this );
					}
				}
			}
			T = Map13.GetStep( this, ((int)( direction ??0 )) & 12 );

			foreach (dynamic _b in Lang13.Enumerate( T, typeof(Obj_Structure_Cable) )) {
				C2 = _b;
				

				if ( !( C2 != null ) ) {
					continue;
				}

				if ( this == C2 ) {
					continue;
				}

				if ( C2.d1 == ( ((int)( direction ??0 )) ^ 12 ) || C2.d2 == ( ((int)( direction ??0 )) ^ 12 ) ) {
					
					if ( !( C2.powernet != null ) ) {
						newPN2 = GlobalFuncs.getFromPool( typeof(Powernet) );
						((dynamic)newPN2).add_cable( C2 );
					}

					if ( this.powernet != null ) {
						GlobalFuncs.merge_powernets( this.powernet, C2.powernet );
					} else {
						C2.powernet.add_cable( this );
					}
				}
			}
			return;
		}

		// Function from file: cable.dm
		public dynamic check_rebuild(  ) {
			
			if ( !this.build_status ) {
				return null;
			}
			this.rebuild_from();
			return null;
		}

		// Function from file: cable.dm
		public double avail(  ) {
			
			if ( this.get_powernet() != null ) {
				return this.powernet.avail;
			} else {
				return 0;
			}
		}

		// Function from file: cable.dm
		public double surplus(  ) {
			
			if ( this.get_powernet() != null ) {
				return this.powernet.avail - this.powernet.load;
			} else {
				return 0;
			}
		}

		// Function from file: cable.dm
		public void add_load( dynamic amount = null ) {
			
			if ( this.get_powernet() != null ) {
				this.powernet.load += Convert.ToDouble( amount );
			}
			return;
		}

		// Function from file: cable.dm
		public void add_avail( dynamic amount = null ) {
			
			if ( this.get_powernet() != null ) {
				this.powernet.newavail += Convert.ToDouble( amount );
			}
			return;
		}

		// Function from file: cable.dm
		public virtual void cableColor( dynamic colorC = null ) {
			colorC = colorC ?? "red";

			this.light_color = colorC;

			dynamic _a = colorC; // Was a switch-case, sorry for the mess.
			if ( _a=="pink" ) {
				this.color = "#CA00B6";
			} else if ( _a=="orange" ) {
				this.color = "#CA6900";
			} else {
				this.color = colorC;
			}
			return;
		}

		// Function from file: cable.dm
		public bool shock( dynamic user = null, int prb = 0, double? siemens_coeff = null ) {
			siemens_coeff = siemens_coeff ?? 1;

			Effect_Effect_System_SparkSpread s = null;

			
			if ( this.get_powernet() != null && this.powernet.avail > 1000 ) {
				
				if ( !Rand13.PercentChance( prb ) ) {
					return false;
				}

				if ( Lang13.Bool( GlobalFuncs.electrocute_mob( user, this.powernet, this, siemens_coeff ) ) ) {
					s = new Effect_Effect_System_SparkSpread();
					s.set_up( 5, 1, this );
					s.start();
					return true;
				}
			}
			return false;
		}

		// Function from file: cable.dm
		public Powernet get_powernet(  ) {
			this.check_rebuild();
			return this.powernet;
		}

		// Function from file: cable.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( this.invisibility != 0 ) {
				this.icon_state = "" + this.d1 + "-" + this.d2 + "-f";
			} else {
				this.icon_state = "" + this.d1 + "-" + this.d2;
			}
			return null;
		}

		// Function from file: cable.dm
		public override void hide( bool? h = null ) {
			
			if ( this.level == 1 && this.loc is Tile ) {
				this.invisibility = ( h == true ? 101 : 0 );
			}
			this.update_icon();
			return;
		}

		// Function from file: cable.dm
		public override void shuttle_rotate( double? angle = null ) {
			double? oldD2 = null;

			
			if ( Lang13.Bool( this.d1 ) ) {
				this.d1 = Num13.Rotate( this.d1, -( angle ??0) );
			}

			if ( Lang13.Bool( this.d2 ) ) {
				this.d2 = Num13.Rotate( this.d2, -( angle ??0) );
			}

			if ( ( this.d1 ??0) > ( this.d2 ??0) ) {
				oldD2 = this.d2;
				this.d2 = this.d1;
				this.d1 = oldD2;
			}
			this.update_icon();
			return;
		}

		// Function from file: cable.dm
		public override bool forceMove( dynamic destination = null, int? no_tp = null ) {
			bool _default = false;

			_default = base.forceMove( (object)(destination), no_tp );

			if ( this.powernet != null ) {
				this.powernet.set_to_build();
			}
			return _default;
		}

		// Function from file: cable.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			
			if ( this.powernet != null ) {
				this.powernet.set_to_build();
			}
			GlobalVars.cable_list.Remove( this );

			if ( this.attached is Obj_Item_Device_Powersink ) {
				this.attached.set_light( 0 );
				this.attached.icon_state = "powersink0";
				((dynamic)this.attached).mode = 0;
				GlobalVars.processing_objects.Remove( this.attached );
				((dynamic)this.attached).anchored = 0;
				((dynamic)this.attached).attached = null;
			}
			this.attached = null;
			base.Destroy( (object)(brokenup) );
			return null;
		}

	}

}