// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Construction_Reversible_Mecha_Odysseus : Construction_Reversible_Mecha {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.result = "/obj/mecha/medical/odysseus";
			this.steps = new ByTable(new object [] { 
				new ByTable().Set( "key", typeof(Obj_Item_Weapon_Weldingtool) ).Set( "backkey", typeof(Obj_Item_Weapon_Wrench) ).Set( "desc", "External armor is wrenched." ), 
				new ByTable().Set( "key", typeof(Obj_Item_Weapon_Wrench) ).Set( "backkey", typeof(Obj_Item_Weapon_Crowbar) ).Set( "desc", "External armor is installed." ), 
				new ByTable().Set( "key", typeof(Obj_Item_Stack_Sheet_Plasteel) ).Set( "backkey", typeof(Obj_Item_Weapon_Weldingtool) ).Set( "desc", "Internal armor is welded." ), 
				new ByTable().Set( "key", typeof(Obj_Item_Weapon_Weldingtool) ).Set( "backkey", typeof(Obj_Item_Weapon_Wrench) ).Set( "desc", "Internal armor is wrenched." ), 
				new ByTable().Set( "key", typeof(Obj_Item_Weapon_Wrench) ).Set( "backkey", typeof(Obj_Item_Weapon_Crowbar) ).Set( "desc", "Internal armor is installed." ), 
				new ByTable().Set( "key", typeof(Obj_Item_Stack_Sheet_Metal) ).Set( "backkey", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "desc", "Peripherals control module is secured." ), 
				new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "backkey", typeof(Obj_Item_Weapon_Crowbar) ).Set( "desc", "Peripherals control module is installed." ), 
				new ByTable().Set( "key", typeof(Obj_Item_Weapon_Circuitboard_Mecha_Odysseus_Peripherals) ).Set( "backkey", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "desc", "Central control module is secured." ), 
				new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "backkey", typeof(Obj_Item_Weapon_Crowbar) ).Set( "desc", "Central control module is installed." ), 
				new ByTable().Set( "key", typeof(Obj_Item_Weapon_Circuitboard_Mecha_Odysseus_Main) ).Set( "backkey", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "desc", "The wiring is adjusted." ), 
				new ByTable().Set( "key", typeof(Obj_Item_Weapon_Wirecutters) ).Set( "backkey", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "desc", "The wiring is added." ), 
				new ByTable().Set( "key", typeof(Obj_Item_Stack_CableCoil) ).Set( "backkey", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "desc", "The hydraulic systems are active." ), 
				new ByTable().Set( "key", typeof(Obj_Item_Weapon_Screwdriver) ).Set( "backkey", typeof(Obj_Item_Weapon_Wrench) ).Set( "desc", "The hydraulic systems are connected." ), 
				new ByTable().Set( "key", typeof(Obj_Item_Weapon_Wrench) ).Set( "desc", "The hydraulic systems are disconnected." )
			 });
		}

		public Construction_Reversible_Mecha_Odysseus ( Game_Data atom = null ) : base( atom ) {
			
		}

		// Function from file: mecha_construction_paths.dm
		public override void spawn_result(  ) {
			base.spawn_result();
			GlobalFuncs.feedback_inc( "mecha_odysseus_created", 1 );
			return;
		}

		// Function from file: mecha_construction_paths.dm
		public override bool custom_action( int? index = null, dynamic diff = null, dynamic used_atom = null, dynamic user = null ) {
			Obj_Item_Stack_CableCoil coil = null;
			Obj_Item_Stack_Sheet_Metal MS = null;
			Obj_Item_Stack_Sheet_Plasteel MS2 = null;

			
			if ( !base.custom_action( index, (object)(diff), (object)(used_atom), (object)(user) ) ) {
				return false;
			}

			switch ((int?)( index )) {
				case 14:
					((Ent_Static)user).visible_message( "" + user + " connects the " + this.holder + " hydraulic systems", "<span class='notice'>You connect the " + this.holder + " hydraulic systems.</span>" );
					((dynamic)this.holder).icon_state = "odysseus1";
					break;
				case 13:
					
					if ( diff == -1 ) {
						((Ent_Static)user).visible_message( "" + user + " activates the " + this.holder + " hydraulic systems.", "<span class='notice'>You activate the " + this.holder + " hydraulic systems.</span>" );
						((dynamic)this.holder).icon_state = "odysseus2";
					} else {
						((Ent_Static)user).visible_message( "" + user + " disconnects the " + this.holder + " hydraulic systems", "<span class='notice'>You disconnect the " + this.holder + " hydraulic systems.</span>" );
						((dynamic)this.holder).icon_state = "odysseus0";
					}
					break;
				case 12:
					
					if ( diff == -1 ) {
						((Ent_Static)user).visible_message( "" + user + " adds the wiring to the " + this.holder + ".", "<span class='notice'>You add the wiring to the " + this.holder + ".</span>" );
						((dynamic)this.holder).icon_state = "odysseus3";
					} else {
						((Ent_Static)user).visible_message( "" + user + " deactivates the " + this.holder + " hydraulic systems.", "<span class='notice'>You deactivate the " + this.holder + " hydraulic systems.</span>" );
						((dynamic)this.holder).icon_state = "odysseus1";
					}
					break;
				case 11:
					
					if ( diff == -1 ) {
						((Ent_Static)user).visible_message( "" + user + " adjusts the wiring of the " + this.holder + ".", "<span class='notice'>You adjust the wiring of the " + this.holder + ".</span>" );
						((dynamic)this.holder).icon_state = "odysseus4";
					} else {
						((Ent_Static)user).visible_message( "" + user + " removes the wiring from the " + this.holder + ".", "<span class='notice'>You remove the wiring from the " + this.holder + ".</span>" );
						coil = new Obj_Item_Stack_CableCoil( GlobalFuncs.get_turf( this.holder ) );
						coil.amount = 4;
						((dynamic)this.holder).icon_state = "odysseus2";
					}
					break;
				case 10:
					
					if ( diff == -1 ) {
						((Ent_Static)user).visible_message( "" + user + " installs the central control module into the " + this.holder + ".", "<span class='notice'>You install the central computer mainboard into the " + this.holder + ".</span>" );
						GlobalFuncs.qdel( used_atom );
						((dynamic)this.holder).icon_state = "odysseus5";
					} else {
						((Ent_Static)user).visible_message( "" + user + " disconnects the wiring of the " + this.holder + ".", "<span class='notice'>You disconnect the wiring of the " + this.holder + ".</span>" );
						((dynamic)this.holder).icon_state = "odysseus3";
					}
					break;
				case 9:
					
					if ( diff == -1 ) {
						((Ent_Static)user).visible_message( "" + user + " secures the mainboard.", "<span class='notice'>You secure the mainboard.</span>" );
						((dynamic)this.holder).icon_state = "odysseus6";
					} else {
						((Ent_Static)user).visible_message( "" + user + " removes the central control module from the " + this.holder + ".", "<span class='notice'>You remove the central computer mainboard from the " + this.holder + ".</span>" );
						new Obj_Item_Weapon_Circuitboard_Mecha_Odysseus_Main( GlobalFuncs.get_turf( this.holder ) );
						((dynamic)this.holder).icon_state = "odysseus4";
					}
					break;
				case 8:
					
					if ( diff == -1 ) {
						((Ent_Static)user).visible_message( "" + user + " installs the peripherals control module into the " + this.holder + ".", "<span class='notice'>You install the peripherals control module into the " + this.holder + ".</span>" );
						GlobalFuncs.qdel( used_atom );
						((dynamic)this.holder).icon_state = "odysseus7";
					} else {
						((Ent_Static)user).visible_message( "" + user + " unfastens the mainboard.", "<span class='notice'>You unfasten the mainboard.</span>" );
						((dynamic)this.holder).icon_state = "odysseus5";
					}
					break;
				case 7:
					
					if ( diff == -1 ) {
						((Ent_Static)user).visible_message( "" + user + " secures the peripherals control module.", "<span class='notice'>You secure the peripherals control module.</span>" );
						((dynamic)this.holder).icon_state = "odysseus8";
					} else {
						((Ent_Static)user).visible_message( "" + user + " removes the peripherals control module from the " + this.holder + ".", "<span class='notice'>You remove the peripherals control module from the " + this.holder + ".</span>" );
						new Obj_Item_Weapon_Circuitboard_Mecha_Odysseus_Peripherals( GlobalFuncs.get_turf( this.holder ) );
						((dynamic)this.holder).icon_state = "odysseus6";
					}
					break;
				case 6:
					
					if ( diff == -1 ) {
						((Ent_Static)user).visible_message( "" + user + " installs the internal armor layer to the " + this.holder + ".", "<span class='notice'>You install the internal armor layer to the " + this.holder + ".</span>" );
						((dynamic)this.holder).icon_state = "odysseus9";
					} else {
						((Ent_Static)user).visible_message( "" + user + " unfastens the peripherals control module.", "<span class='notice'>You unfasten the peripherals control module.</span>" );
						((dynamic)this.holder).icon_state = "odysseus7";
					}
					break;
				case 5:
					
					if ( diff == -1 ) {
						((Ent_Static)user).visible_message( "" + user + " secures the internal armor layer.", "<span class='notice'>You secure the internal armor layer.</span>" );
						((dynamic)this.holder).icon_state = "odysseus10";
					} else {
						((Ent_Static)user).visible_message( "" + user + " pries internal armor layer from the " + this.holder + ".", "<span class='notice'>You pry internal armor layer from the " + this.holder + ".</span>" );
						MS = new Obj_Item_Stack_Sheet_Metal( GlobalFuncs.get_turf( this.holder ) );
						MS.amount = 5;
						((dynamic)this.holder).icon_state = "odysseus8";
					}
					break;
				case 4:
					
					if ( diff == -1 ) {
						((Ent_Static)user).visible_message( "" + user + " welds the internal armor layer to the " + this.holder + ".", "<span class='notice'>You weld the internal armor layer to the " + this.holder + ".</span>" );
						((dynamic)this.holder).icon_state = "odysseus11";
					} else {
						((Ent_Static)user).visible_message( "" + user + " unfastens the internal armor layer.", "<span class='notice'>You unfasten the internal armor layer.</span>" );
						((dynamic)this.holder).icon_state = "odysseus9";
					}
					break;
				case 3:
					
					if ( diff == -1 ) {
						((Ent_Static)user).visible_message( "" + user + " installs " + used_atom + " layer to the " + this.holder + ".", "<span class='notice'>You install the external reinforced armor layer to the " + this.holder + ".</span>" );
						((dynamic)this.holder).icon_state = "odysseus12";
					} else {
						((Ent_Static)user).visible_message( "" + user + " cuts the internal armor layer from the " + this.holder + ".", "<span class='notice'>You cut the internal armor layer from the " + this.holder + ".</span>" );
						((dynamic)this.holder).icon_state = "odysseus10";
					}
					break;
				case 2:
					
					if ( diff == -1 ) {
						((Ent_Static)user).visible_message( "" + user + " secures the external armor layer.", "<span class='notice'>You secure the external reinforced armor layer.</span>" );
						((dynamic)this.holder).icon_state = "odysseus13";
					} else {
						MS2 = new Obj_Item_Stack_Sheet_Plasteel( GlobalFuncs.get_turf( this.holder ) );
						MS2.amount = 5;
						((Ent_Static)user).visible_message( "" + user + " pries " + MS2 + " from the " + this.holder + ".", "<span class='notice'>You pry " + MS2 + " from the " + this.holder + ".</span>" );
						((dynamic)this.holder).icon_state = "odysseus11";
					}
					break;
				case 1:
					
					if ( diff == -1 ) {
						((Ent_Static)user).visible_message( "" + user + " welds the external armor layer to the " + this.holder + ".", "<span class='notice'>You weld the external armor layer to the " + this.holder + ".</span>" );
						((dynamic)this.holder).icon_state = "odysseus14";
					} else {
						((Ent_Static)user).visible_message( "" + user + " unfastens the external armor layer.", "<span class='notice'>You unfasten the external armor layer.</span>" );
						((dynamic)this.holder).icon_state = "odysseus12";
					}
					break;
			}
			return true;
		}

		// Function from file: mecha_construction_paths.dm
		public override bool action( dynamic used_atom = null, dynamic user = null ) {
			return this.check_step( used_atom, user );
		}

	}

}