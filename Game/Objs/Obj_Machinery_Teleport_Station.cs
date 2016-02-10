// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Teleport_Station : Obj_Machinery_Teleport {

		public bool active = false;
		public bool engaged = false;
		public bool opened = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.idle_power_usage = 10;
			this.active_power_usage = 2000;
			this.machine_flags = 6;
			this.icon_state = "controller";
		}

		// Function from file: teleporter.dm
		public Obj_Machinery_Teleport_Station ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.component_parts = new ByTable(new object [] { 
				new Obj_Item_Weapon_Circuitboard_Telestation(), 
				new Obj_Item_Weapon_StockParts_ScanningModule_Adv_Phasic(), 
				new Obj_Item_Weapon_StockParts_ScanningModule_Adv_Phasic(), 
				new Obj_Item_Weapon_StockParts_Capacitor_Adv_Super(), 
				new Obj_Item_Weapon_StockParts_Capacitor_Adv_Super(), 
				new Obj_Item_Weapon_StockParts_Subspace_Ansible(), 
				new Obj_Item_Weapon_StockParts_Subspace_Ansible(), 
				new Obj_Item_Weapon_StockParts_Subspace_Analyzer(), 
				new Obj_Item_Weapon_StockParts_Subspace_Analyzer(), 
				new Obj_Item_Weapon_StockParts_Subspace_Analyzer(), 
				new Obj_Item_Weapon_StockParts_Subspace_Analyzer()
			 });
			this.RefreshParts();
			return;
		}

		// Function from file: teleporter.dm
		public override dynamic power_change(  ) {
			dynamic com = null;

			base.power_change();

			if ( ( this.stat & 2 ) != 0 ) {
				this.icon_state = "controller-p";
				com = Lang13.FindIn( typeof(Obj_Machinery_Teleport_Hub), Map13.GetTile( this.x + 1, this.y, this.z ) );

				if ( Lang13.Bool( com ) ) {
					com.icon_state = "tele0";
				}
			} else {
				this.icon_state = "controller";
			}
			return null;
		}

		// Function from file: teleporter.dm
		public void disengage(  ) {
			Ent_Static l = null;
			dynamic com = null;
			dynamic H = null;
			dynamic O = null;

			
			if ( ( this.stat & 3 ) != 0 ) {
				return;
			}
			l = this.loc;
			com = Lang13.FindIn( typeof(Obj_Machinery_Teleport_Hub), Map13.GetTile( l.x + 1, l.y, l.z ) );

			if ( Lang13.Bool( com ) ) {
				H = com;
				H.engaged = 0;
				H.icon_state = "tele0";

				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchHearers( null, this ) )) {
					O = _a;
					
					O.show_message( "<span class='notice'>Teleporter disengaged!</span>", 2 );
				}
			}
			this.add_fingerprint( Task13.User );
			this.engaged = false;
			return;
		}

		// Function from file: teleporter.dm
		public void engage(  ) {
			Ent_Static l = null;
			dynamic com = null;
			dynamic H = null;
			dynamic O = null;

			
			if ( ( this.stat & 3 ) != 0 ) {
				return;
			}
			l = this.loc;
			com = Lang13.FindIn( typeof(Obj_Machinery_Teleport_Hub), Map13.GetTile( l.x + 1, l.y, l.z ) );

			if ( Lang13.Bool( com ) ) {
				H = com;
				H.engaged = 1;
				H.icon_state = "tele1";
				this.f_use_power( 5000 );

				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchHearers( null, this ) )) {
					O = _a;
					
					O.show_message( "<span class='notice'>Teleporter engaged!</span>", 2 );
				}
			}
			this.add_fingerprint( Task13.User );
			this.engaged = true;
			return;
		}

		// Function from file: teleporter.dm
		public override dynamic attack_hand( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( this.engaged ) {
				this.disengage();
			} else {
				this.engage();
			}
			return null;
		}

		// Function from file: teleporter.dm
		public override dynamic attack_ai( dynamic user = null ) {
			this.attack_hand( user );
			return null;
		}

		// Function from file: teleporter.dm
		public override dynamic attack_paw( Mob a = null, dynamic b = null, dynamic c = null ) {
			this.attack_hand( a );
			return null;
		}

		// Function from file: teleporter.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			
			if ( Lang13.Bool( base.attackby( (object)(a), (object)(b), (object)(c) ) ) ) {
				return 1;
			} else {
				this.attack_hand();
			}
			return null;
		}

		// Function from file: teleporter.dm
		[Verb]
		[VerbInfo( name: "Test Fire Teleporter", group: "Object", access: VerbAccess.InViewExcludeThis, range: 1 )]
		public void testfire(  ) {
			Ent_Static l = null;
			dynamic com = null;
			dynamic O = null;

			
			if ( ( this.stat & 3 ) != 0 || !( Task13.User is Mob_Living ) ) {
				return;
			}
			l = this.loc;
			com = Lang13.FindIn( typeof(Obj_Machinery_Teleport_Hub), Map13.GetTile( l.x + 1, l.y, l.z ) );

			if ( Lang13.Bool( com ) && !this.active ) {
				this.active = true;

				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchHearers( null, this ) )) {
					O = _a;
					
					O.show_message( "<span class='notice'>Test firing!</span>", 2 );
				}
				com.teleport();
				this.f_use_power( 5000 );
				Task13.Schedule( 30, (Task13.Closure)(() => {
					this.active = false;
					return;
				}));
			}
			this.add_fingerprint( Task13.User );
			return;
		}

	}

}