// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Wires_Vending : Wires {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.holder_type = typeof(Obj_Machinery_Vending);
		}

		// Function from file: vending.dm
		public Wires_Vending ( Obj_Machinery_Vending holder = null ) : base( holder ) {
			this.wires = new ByTable(new object [] { "throw", "electrify", "speaker", "contraband", "idscan" });
			this.add_duds( 1 );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: vending.dm
		public override void on_cut( dynamic wire = null, int? mend = null ) {
			Obj V = null;

			V = this.holder;

			dynamic _a = wire; // Was a switch-case, sorry for the mess.
			if ( _a=="throw" ) {
				((dynamic)V).shoot_inventory = !Lang13.Bool( mend );
			} else if ( _a=="contraband" ) {
				((dynamic)V).extended_inventory = GlobalVars.FALSE;
			} else if ( _a=="electrify" ) {
				
				if ( Lang13.Bool( mend ) ) {
					((dynamic)V).seconds_electrified = GlobalVars.FALSE;
				} else {
					((dynamic)V).seconds_electrified = -1;
				}
			} else if ( _a=="idscan" ) {
				((dynamic)V).scan_id = mend;
			} else if ( _a=="speaker" ) {
				((dynamic)V).shut_up = mend;
			}
			return;
		}

		// Function from file: vending.dm
		public override void on_pulse( string wire = null ) {
			Obj V = null;

			V = this.holder;

			switch ((string)( wire )) {
				case "throw":
					((dynamic)V).shoot_inventory = !Lang13.Bool( ((dynamic)V).shoot_inventory );
					break;
				case "contraband":
					((dynamic)V).extended_inventory = !Lang13.Bool( ((dynamic)V).extended_inventory );
					break;
				case "electrify":
					((dynamic)V).seconds_electrified = 30;
					break;
				case "idscan":
					((dynamic)V).scan_id = !Lang13.Bool( ((dynamic)V).scan_id );
					break;
				case "speaker":
					((dynamic)V).shut_up = !Lang13.Bool( ((dynamic)V).shut_up );
					break;
			}
			return;
		}

		// Function from file: vending.dm
		public override ByTable get_status(  ) {
			Obj V = null;
			ByTable status = null;

			V = this.holder;
			status = new ByTable();
			status.Add( "The orange light is " + ( Lang13.Bool( ((dynamic)V).seconds_electrified ) ? "on" : "off" ) + "." );
			status.Add( "The red light is " + ( Lang13.Bool( ((dynamic)V).shoot_inventory ) ? "off" : "blinking" ) + "." );
			status.Add( "The green light is " + ( Lang13.Bool( ((dynamic)V).extended_inventory ) ? "on" : "off" ) + "." );
			status.Add( "A " + ( Lang13.Bool( ((dynamic)V).scan_id ) ? "purple" : "yellow" ) + " light is on." );
			status.Add( "The speaker light is " + ( Lang13.Bool( ((dynamic)V).shut_up ) ? "off" : "on" ) + "." );
			return status;
		}

		// Function from file: vending.dm
		public override int? interactable( dynamic user = null ) {
			Obj V = null;

			V = this.holder;

			if ( !( user is Mob_Living_Silicon ) && Lang13.Bool( ((dynamic)V).seconds_electrified ) && Lang13.Bool( ((dynamic)V).shock( user, 100 ) ) ) {
				return GlobalVars.FALSE;
			}

			if ( Lang13.Bool( ((dynamic)V).panel_open ) ) {
				return GlobalVars.TRUE;
			}
			return null;
		}

	}

}