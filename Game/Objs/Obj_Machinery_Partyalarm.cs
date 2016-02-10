// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Partyalarm : Obj_Machinery {

		public bool detecting = true;
		public bool working = true;
		public double time = 10;
		public double? timing = 0;
		public bool lockdownbyai = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.idle_power_usage = 2;
			this.active_power_usage = 6;
			this.icon = "icons/obj/monitors.dmi";
			this.icon_state = "fire0";
		}

		// Function from file: alarm.dm
		public Obj_Machinery_Partyalarm ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.name = "" + this.areaMaster.name + " party alarm";
			return;
		}

		// Function from file: alarm.dm
		public override dynamic Topic( string href = null, ByTable href_list = null, dynamic hclient = null, HtmlInterface currui = null ) {
			double? tp = null;

			
			if ( Lang13.Bool( base.Topic( href, href_list, (object)(hclient) ) ) ) {
				return 1;
			}

			if ( Lang13.Bool( Task13.User.stat ) || ( this.stat & 3 ) != 0 ) {
				return null;
			}
			Task13.User.machine = this;

			if ( Lang13.Bool( href_list["reset"] ) ) {
				this.reset();
			} else if ( Lang13.Bool( href_list["alarm"] ) ) {
				this.alarm();
			} else if ( Lang13.Bool( href_list["time"] ) ) {
				this.timing = String13.ParseNumber( href_list["time"] );
			} else if ( Lang13.Bool( href_list["tp"] ) ) {
				tp = String13.ParseNumber( href_list["tp"] );
				this.time += tp ??0;
				this.time = Num13.MinInt( Num13.MaxInt( Num13.Floor( this.time ), 0 ), 120 );
			}
			this.updateUsrDialog();
			this.add_fingerprint( Task13.User );
			return null;
		}

		// Function from file: alarm.dm
		public void alarm(  ) {
			
			if ( !this.working ) {
				return;
			}
			((Zone)this.areaMaster).partyalert();
			return;
		}

		// Function from file: alarm.dm
		public void reset(  ) {
			
			if ( !this.working ) {
				return;
			}
			((Zone)this.areaMaster).partyreset();
			return;
		}

		// Function from file: alarm.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			string d1 = null;
			string d2 = null;
			double second = 0;
			double minute = 0;
			string dat = null;
			double second2 = 0;
			double minute2 = 0;
			string dat2 = null;

			
			if ( Lang13.Bool( a.stat ) && !( a is Mob_Dead_Observer ) || ( this.stat & 3 ) != 0 ) {
				return null;
			}
			a.machine = this;

			if ( a is Mob_Living_Carbon_Human || a is Mob_Living_Silicon_Ai ) {
				
				if ( this.areaMaster.party == true ) {
					d1 = new Txt( "<A href='?src=" ).Ref( this ).str( ";reset=1'>No Party :(</A>" ).ToString();
				} else {
					d1 = new Txt( "<A href='?src=" ).Ref( this ).str( ";alarm=1'>PARTY!!!</A>" ).ToString();
				}

				if ( Lang13.Bool( this.timing ) ) {
					d2 = new Txt( "<A href='?src=" ).Ref( this ).str( ";time=0'>Stop Time Lock</A>" ).ToString();
				} else {
					d2 = new Txt( "<A href='?src=" ).Ref( this ).str( ";time=1'>Initiate Time Lock</A>" ).ToString();
				}
				second = this.time % 60;
				minute = ( this.time - second ) / 60;
				dat = new Txt( "<HTML><HEAD></HEAD><BODY><TT><B>Party Button</B> " ).item( d1 ).str( "\n<HR>\nTimer System: " ).item( d2 ).str( "<BR>\nTime Left: " ).item( ( minute != 0 ? "" + minute + ":" : null ) ).item( second ).str( " <A href='?src=" ).Ref( this ).str( ";tp=-30'>-</A> <A href='?src=" ).Ref( this ).str( ";tp=-1'>-</A> <A href='?src=" ).Ref( this ).str( ";tp=1'>+</A> <A href='?src=" ).Ref( this ).str( ";tp=30'>+</A>\n</TT></BODY></HTML>" ).ToString();
				Interface13.Browse( a, dat, "window=partyalarm" );
				GlobalFuncs.onclose( a, "partyalarm" );
			} else {
				
				if ( Lang13.Bool( this.areaMaster.fire ) ) {
					d1 = new Txt( "<A href='?src=" ).Ref( this ).str( ";reset=1'>" ).item( GlobalFuncs.stars( "No Party :(" ) ).str( "</A>" ).ToString();
				} else {
					d1 = new Txt( "<A href='?src=" ).Ref( this ).str( ";alarm=1'>" ).item( GlobalFuncs.stars( "PARTY!!!" ) ).str( "</A>" ).ToString();
				}

				if ( Lang13.Bool( this.timing ) ) {
					d2 = new Txt( "<A href='?src=" ).Ref( this ).str( ";time=0'>" ).item( GlobalFuncs.stars( "Stop Time Lock" ) ).str( "</A>" ).ToString();
				} else {
					d2 = new Txt( "<A href='?src=" ).Ref( this ).str( ";time=1'>" ).item( GlobalFuncs.stars( "Initiate Time Lock" ) ).str( "</A>" ).ToString();
				}
				second2 = this.time % 60;
				minute2 = ( this.time - second2 ) / 60;
				dat2 = new Txt( "<HTML><HEAD></HEAD><BODY><TT><B>" ).item( GlobalFuncs.stars( "Party Button" ) ).str( "</B> " ).item( d1 ).str( "\n<HR>\nTimer System: " ).item( d2 ).str( "<BR>\nTime Left: " ).item( ( minute2 != 0 ? "" + minute2 + ":" : null ) ).item( second2 ).str( " <A href='?src=" ).Ref( this ).str( ";tp=-30'>-</A> <A href='?src=" ).Ref( this ).str( ";tp=-1'>-</A> <A href='?src=" ).Ref( this ).str( ";tp=1'>+</A> <A href='?src=" ).Ref( this ).str( ";tp=30'>+</A>\n</TT></BODY></HTML>" ).ToString();
				Interface13.Browse( a, dat2, "window=partyalarm" );
				GlobalFuncs.onclose( a, "partyalarm" );
			}
			return null;
		}

		// Function from file: alarm.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			return this.attack_hand( a );
		}

	}

}