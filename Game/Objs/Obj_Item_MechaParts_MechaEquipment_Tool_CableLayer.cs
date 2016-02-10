// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_MechaParts_MechaEquipment_Tool_CableLayer : Obj_Item_MechaParts_MechaEquipment_Tool {

		public Event v_event = null;
		public dynamic old_turf = null;
		public Game_Data last_piece = null;
		public Game_Data cable = null;
		public int max_cable = 1000;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "mecha_wire";
		}

		// Function from file: medical_tools.dm
		public Obj_Item_MechaParts_MechaEquipment_Tool_CableLayer ( dynamic loc = null ) : base( (object)(loc) ) {
			this.cable = new Obj_Item_Stack_CableCoil( this );
			((dynamic)this.cable).amount = 0;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: medical_tools.dm
		public bool layCable( Tile new_turf = null ) {
			double? fdirn = null;
			Obj_Structure_Cable LC = null;
			Game_Data NC = null;
			Powernet PN = null;

			
			if ( this.equip_ready || !( new_turf is Tile ) || !this.dismantleFloor( new_turf ) ) {
				this.reset(); return false;
			}
			fdirn = Num13.Rotate( this.chassis.dir, 180 );

			foreach (dynamic _a in Lang13.Enumerate( new_turf, typeof(Obj_Structure_Cable) )) {
				LC = _a;
				

				if ( LC.d1 == fdirn || LC.d2 == fdirn ) {
					this.reset(); return false;
				}
			}

			if ( !this.use_cable( 1 ) ) {
				this.reset(); return false;
			}
			NC = GlobalFuncs.getFromPool( typeof(Obj_Structure_Cable), new_turf );
			((dynamic)NC).cableColor( "red" );
			((dynamic)NC).d1 = 0;
			((dynamic)NC).d2 = fdirn;
			((dynamic)NC).update_icon();
			PN = null;

			if ( this.last_piece != null && Convert.ToInt32( ((dynamic)this.last_piece).d2 ) != this.chassis.dir ) {
				((dynamic)this.last_piece).d1 = Num13.MinInt( Convert.ToInt32( ((dynamic)this.last_piece).d2 ), this.chassis.dir );
				((dynamic)this.last_piece).d2 = Num13.MaxInt( Convert.ToInt32( ((dynamic)this.last_piece).d2 ), this.chassis.dir );
				((dynamic)this.last_piece).update_icon();
				PN = ((dynamic)this.last_piece).powernet;
			}

			if ( !( PN != null ) ) {
				PN = new Powernet();
			}
			((dynamic)NC).powernet = PN;
			PN.cables.Add( NC );
			((Obj_Structure_Cable)NC).mergeConnectedNetworks( Lang13.DoubleNullable( ((dynamic)NC).d2 ) );
			this.last_piece = NC;
			return true;
		}

		// Function from file: medical_tools.dm
		public bool dismantleFloor( Tile new_turf = null ) {
			Tile T = null;

			
			if ( new_turf is Tile_Simulated_Floor ) {
				T = new_turf;

				if ( !T.is_plating() ) {
					
					if ( !Lang13.Bool( ((dynamic)T).broken ) && !Lang13.Bool( ((dynamic)T).burnt ) ) {
						Lang13.Call( ((dynamic)T).floor_tile.type, T );
					}
					((Tile_Simulated_Floor)T).make_plating();
				}
			}
			return !( new_turf.intact == true );
		}

		// Function from file: medical_tools.dm
		public void reset(  ) {
			this.last_piece = null;
			return;
		}

		// Function from file: medical_tools.dm
		public bool use_cable( double? amount = null ) {
			
			if ( !( this.cable != null ) || Convert.ToDouble( ((dynamic)this.cable).amount ) < 1 ) {
				this.set_ready_state( true );
				this.occupant_message( "Cable depleted, " + this + " deactivated." );
				this.log_message( "Cable depleted, " + this + " deactivated." );
				return false;
			}

			if ( Convert.ToDouble( ((dynamic)this.cable).amount ) < ( amount ??0) ) {
				this.occupant_message( "No enough cable to finish the task." );
				return false;
			}
			((dynamic)this.cable).use( amount );
			this.update_equip_info();
			return true;
		}

		// Function from file: medical_tools.dm
		public int load_cable( dynamic CC = null ) {
			double? cur_amount = null;
			int to_load = 0;

			
			if ( CC is Obj_Item_Stack_CableCoil && Lang13.Bool( CC.amount ) ) {
				cur_amount = ( this.cable != null ? Lang13.Bool( ((dynamic)this.cable).amount ) : false ) ?1:0;
				to_load = Num13.MaxInt( ((int)( this.max_cable - ( cur_amount ??0) )), 0 );

				if ( to_load != 0 ) {
					to_load = Num13.MinInt( Convert.ToInt32( CC.amount ), to_load );

					if ( !( this.cable != null ) ) {
						this.cable = GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_CableCoil), this );
						((dynamic)this.cable).amount = 0;
					}
					((dynamic)this.cable).amount += to_load;
					CC.use( to_load );
					return to_load;
				} else {
					return 0;
				}
			}
			return 0;
		}

		// Function from file: medical_tools.dm
		public override string get_equip_info(  ) {
			string output = null;

			output = base.get_equip_info();

			if ( Lang13.Bool( output ) ) {
				return "" + output + " [Cable: " + ( this.cable != null ? Lang13.Bool( ((dynamic)this.cable).amount ) : false ) + " m]" + ( this.cable != null && Lang13.Bool( ((dynamic)this.cable).amount ) ? new Txt( "- <a href='?src=" ).Ref( this ).str( ";toggle=1'>" ).item( ( !this.equip_ready ? "Dea" : "A" ) ).str( "ctivate</a>|<a href='?src=" ).Ref( this ).str( ";cut=1'>Cut</a>" ).ToString() : null );
			}
			return null;
		}

		// Function from file: medical_tools.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			double? m = null;
			Game_Data CC = null;

			base.Topic( href, href_list, (object)(hclient) );

			if ( Lang13.Bool( href_list["toggle"] ) ) {
				this.set_ready_state( !this.equip_ready );
				this.occupant_message( "" + this + " " + ( this.equip_ready ? "dea" : "a" ) + "ctivated." );
				this.log_message( "" + ( this.equip_ready ? "Dea" : "A" ) + "ctivated." );
				return null;
			}

			if ( Lang13.Bool( href_list["cut"] ) ) {
				
				if ( this.cable != null && Lang13.Bool( ((dynamic)this.cable).amount ) ) {
					m = Num13.Round( Convert.ToDouble( Interface13.Input( this.chassis.occupant, "Please specify the length of cable to cut", "Cut cable", Num13.MinInt( Convert.ToInt32( ((dynamic)this.cable).amount ), 30 ), null, InputType.Num ) ), 1 );
					m = Num13.MinInt( ((int)( m ??0 )), Convert.ToInt32( ((dynamic)this.cable).amount ) );

					if ( Lang13.Bool( m ) ) {
						this.use_cable( m );
						CC = GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_CableCoil), GlobalFuncs.get_turf( this.chassis ) );
						((dynamic)CC).amount = m;
					}
				} else {
					this.occupant_message( "There's no more cable on the reel." );
				}
			}
			return null;
		}

		// Function from file: medical_tools.dm
		public override bool action( dynamic target = null ) {
			int? result = null;
			string message = null;

			
			if ( !this.action_checks( target ) ) {
				return false;
			}
			result = this.load_cable( target );

			if ( result == null ) {
				message = "<font color='red'>Unable to load " + target + " - no cable found.</font>";
			} else if ( !Lang13.Bool( result ) ) {
				message = "Reel is full.";
			} else {
				message = "" + result + " meters of cable successfully loaded.";
				GlobalFuncs.send_byjax( this.chassis.occupant, "exosuit.browser", new Txt().Ref( this ).ToString(), this.get_equip_info() );
			}
			this.occupant_message( message );
			return false;
		}

		// Function from file: medical_tools.dm
		public override void destroy(  ) {
			this.chassis.events.clearEvent( "onMove", this.v_event );
			base.destroy(); return;
		}

		// Function from file: medical_tools.dm
		public override void detach( dynamic moveto = null ) {
			this.chassis.events.clearEvent( "onMove", this.v_event );
			base.detach( (object)(moveto) ); return;
		}

		// Function from file: medical_tools.dm
		public override void attach( Obj_Mecha M = null ) {
			base.attach( M );
			this.v_event = this.chassis.events.addEvent( "onMove", this, "layCable" );
			return;
		}

		// Function from file: medical_tools.dm
		public override bool can_attach( Obj_Mecha M = null ) {
			
			if ( base.can_attach( M ) ) {
				
				if ( M is Obj_Mecha_Working ) {
					return true;
				}
			}
			return false;
		}

	}

}