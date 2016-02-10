// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_LightConstruct : Obj_Machinery {

		public int stage = 1;
		public string fixture_type = "tube";
		public int sheets_refunded = 2;
		public Obj_Machinery_Light newlight = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/lighting.dmi";
			this.icon_state = "tube-construct-stage1";
			this.layer = 5;
		}

		// Function from file: lighting.dm
		public Obj_Machinery_LightConstruct ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( this.fixture_type == "bulb" ) {
				this.icon_state = "bulb-construct-stage1";
			}
			return;
		}

		// Function from file: lighting.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			Game_Data M = null;
			dynamic coil = null;

			this.add_fingerprint( b );

			if ( a is Obj_Item_Weapon_Wrench ) {
				
				if ( this.stage == 1 ) {
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Ratchet.ogg", 75, 1 );
					GlobalFuncs.to_chat( Task13.User, "You begin deconstructing " + this + "." );

					if ( !GlobalFuncs.do_after( Task13.User, this, 30 ) ) {
						return null;
					}
					M = GlobalFuncs.getFromPool( typeof(Obj_Item_Stack_Sheet_Metal), GlobalFuncs.get_turf( this ) );
					((dynamic)M).amount = this.sheets_refunded;
					((Ent_Static)b).visible_message( "" + b.name + " deconstructs " + this + ".", "You deconstruct " + this + ".", "You hear a noise." );
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/items/Deconstruct.ogg", 75, 1 );
					GlobalFuncs.qdel( this );
				}

				if ( this.stage == 2 ) {
					GlobalFuncs.to_chat( Task13.User, "You have to remove the wires first." );
					return null;
				}
			}

			if ( a is Obj_Item_Stack_CableCoil ) {
				
				if ( this.stage == 1 ) {
					coil = a;
					coil.use( 1 );

					switch ((string)( this.fixture_type )) {
						case "tube":
							this.icon_state = "tube-empty";
							break;
						case "bulb":
							this.icon_state = "bulb-empty";
							break;
					}
					this.stage = 2;
					((Ent_Static)b).visible_message( new Txt().item( b.name ).str( " adds wires to " ).the( this ).item().str( "." ).ToString(), new Txt( "You add wires to " ).the( this ).item().ToString() );

					switch ((string)( this.fixture_type )) {
						case "tube":
							this.newlight = new Obj_Machinery_Light_Built( this.loc );
							break;
						case "bulb":
							this.newlight = new Obj_Machinery_Light_Small_Built( this.loc );
							break;
					}
					this.newlight.dir = this.dir;
					this.transfer_fingerprints_to( this.newlight );
					GlobalFuncs.qdel( this );
					return null;
				}
			}
			base.attackby( (object)(a), (object)(b), (object)(c) );
			return null;
		}

		// Function from file: lighting.dm
		public override dynamic examine( dynamic user = null, string size = null ) {
			string mode = null;

			base.examine( (object)(user), size );

			switch ((int)( this.stage )) {
				case 1:
					mode = "It's empty and lacks wiring.";
					break;
				case 2:
					mode = "It's wired.";
					break;
			}
			GlobalFuncs.to_chat( user, "<span class='info'>" + mode + "</span>" );
			return null;
		}

	}

}