// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Subsystem : Game_Data {

		public string name = null;
		public int priority = 0;
		public double wait = 20;
		public int display = 100;
		public bool dynamic_wait = false;
		public int dwait_upper = 20;
		public int dwait_lower = 5;
		public int dwait_delta = 7;
		public double dwait_buffer = 061;
		public bool can_fire = false;
		public int last_fire = 0;
		public double next_fire = 0;
		public double cost = 0;
		public int times_fired = 0;
		public Obj_Effect_Statclick_Debug statclick = null;

		// Function from file: subsystem.dm
		public Subsystem (  ) {
			return;
		}

		// Function from file: subsystem.dm
		public override void on_varedit( dynamic modified_var = null ) {
			
			if ( modified_var == "can_fire" && this.can_fire ) {
				this.next_fire = Game13.time + this.wait;
			}
			return;
		}

		// Function from file: subsystem.dm
		public virtual void Recover(  ) {
			return;
		}

		// Function from file: subsystem.dm
		public void postpone( int? cycles = null ) {
			cycles = cycles ?? 1;

			
			if ( this.next_fire - Game13.time < this.wait ) {
				this.next_fire += this.wait * ( cycles ??0);
			}
			return;
		}

		// Function from file: subsystem.dm
		public virtual void stat_entry( string msg = null ) {
			string dwait = null;

			
			if ( !( this.statclick != null ) ) {
				this.statclick = new Obj_Effect_Statclick_Debug( "Initializing...", this );
			}
			dwait = "";

			if ( this.dynamic_wait ) {
				dwait = "DWait:" + Num13.Round( this.wait, 0.1 ) + "ds ";
			}

			if ( this.can_fire ) {
				msg = "" + Num13.Round( this.cost, 0.01 ) + "ds	" + dwait + msg;
			} else {
				msg = "OFFLINE	" + msg;
			}
			Interface13.Stat( this.name, this.statclick.update( msg ) );
			return;
		}

		// Function from file: subsystem.dm
		public virtual double Initialize( int start_timeofday = 0, double? zlevel = null ) {
			double time = 0;
			string msg = null;

			time = ( Game13.timeofday - start_timeofday ) / 10;
			msg = "Initialized " + this.name + " subsystem within " + time + " seconds!";

			if ( Lang13.Bool( zlevel ) ) {
				GlobalFuncs.testing( msg );
				return time;
			}
			Game13.WriteMsg( "<span class='boldannounce'>" + msg + "</span>" );
			return time;
		}

		// Function from file: subsystem.dm
		public virtual void fire(  ) {
			this.can_fire = false;
			return;
		}

	}

}