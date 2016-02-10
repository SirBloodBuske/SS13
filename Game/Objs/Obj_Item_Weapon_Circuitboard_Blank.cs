// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_Blank : Obj_Item_Weapon_Circuitboard {

		public ByTable allowed_boards = new ByTable()
											.Set( "autolathe", typeof(Obj_Item_Weapon_Circuitboard_Autolathe) )
											.Set( "intercom", typeof(Obj_Item_Weapon_IntercomElectronics) )
											.Set( "conveyor", typeof(Obj_Item_Weapon_Circuitboard_Conveyor) )
											.Set( "air alarm", typeof(Obj_Item_Weapon_Circuitboard_AirAlarm) )
											.Set( "fire alarm", typeof(Obj_Item_Weapon_Circuitboard_FireAlarm) )
											.Set( "airlock", typeof(Obj_Item_Weapon_Circuitboard_Airlock) )
											.Set( "APC", typeof(Obj_Item_Weapon_Circuitboard_PowerControl) )
											.Set( "vendomat", typeof(Obj_Item_Weapon_Circuitboard_Vendomat) )
											.Set( "microwave", typeof(Obj_Item_Weapon_Circuitboard_Microwave) )
										;
		public bool soldering = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "blank_mod";
		}

		// Function from file: constructable_frame.dm
		public Obj_Item_Weapon_Circuitboard_Blank ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: constructable_frame.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic t = null;
			dynamic S = null;
			dynamic boardType = null;
			dynamic I = null;
			dynamic WT = null;
			Obj_Item_Stack_Sheet_Glass_Glass new_item = null;

			
			if ( !this.soldering && a is Obj_Item_Weapon_Solder ) {
				t = Interface13.Input( b, "Which board should be designed?", null, null, this.allowed_boards, InputType.Null | InputType.Any );

				if ( !Lang13.Bool( t ) ) {
					return null;
				}
				S = a;

				if ( !Lang13.Bool( S.remove_fuel( 4, b ) ) ) {
					return null;
				}
				GlobalFuncs.playsound( this.loc, "sound/items/welder.ogg", 50, 1 );
				this.soldering = true;

				if ( GlobalFuncs.do_after( b, this, 40 ) ) {
					boardType = this.allowed_boards[t];
					I = Lang13.Call( boardType, GlobalFuncs.get_turf( b ) );
					GlobalFuncs.to_chat( b, "<span class='notice'>You fashion a crude " + I + " from the blank circuitboard.</span>" );
					GlobalFuncs.qdel( this );
					((Mob)b).put_in_hands( I );
				}
				this.soldering = false;
			} else if ( a is Obj_Item_Weapon_Weldingtool ) {
				WT = a;

				if ( ((Obj_Item_Weapon_Weldingtool)WT).remove_fuel( 1, b ) ) {
					new_item = new Obj_Item_Stack_Sheet_Glass_Glass( this.loc );
					new_item.add_to_stacks( b );
					GlobalFuncs.returnToPool( this );
					return null;
				}
			} else {
				return base.attackby( (object)(a), (object)(b), (object)(c) );
			}
			return null;
		}

	}

}