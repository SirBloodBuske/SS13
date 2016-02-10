// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Computer_Crew : Obj_Machinery_Computer {

		public ByTable tracked = new ByTable();
		public dynamic track_special_role = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.idle_power_usage = 250;
			this.active_power_usage = 500;
			this.circuit = "/obj/item/weapon/circuitboard/crew";
			this.light_color = "#6496FA";
			this.light_range_on = 2;
			this.icon_state = "crew";
		}

		// Function from file: crew.dm
		public Obj_Machinery_Computer_Crew ( dynamic loc = null ) : base( (object)(loc) ) {
			this.tracked = new ByTable();
			GlobalVars.html_machines.Add( this );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: crew.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( ( this.stat & 1 ) != 0 ) {
				this.icon_state = "crewb";
			} else if ( ( this.stat & 2 ) != 0 ) {
				this.icon_state = "c_unpowered";
				this.stat |= 2;
			} else {
				this.icon_state = Lang13.Initial( this, "icon_state" );
				this.stat &= 65533;
			}
			return null;
		}

		// Function from file: crew.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic _default = null;

			_default = base.attack_hand( (object)(a), (object)(b), (object)(c) );

			if ( Lang13.Bool( _default ) ) {
				return _default;
			}

			if ( ( this.stat & 3 ) != 0 ) {
				return _default;
			}
			GlobalVars.crewmonitor.show( a );
			return _default;
		}

		// Function from file: crew.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.attack_hand( user );
			return null;
		}

		// Function from file: crew.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			base.Destroy( (object)(brokenup) );
			GlobalVars.html_machines.Remove( this );
			return null;
		}

	}

}