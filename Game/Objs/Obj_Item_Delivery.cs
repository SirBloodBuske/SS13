// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Delivery : Obj_Item {

		public dynamic sortTag = null;
		public Obj_Item_Weapon_Paper wrapped = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/storage.dmi";
			this.icon_state = "deliverycrateSmall";
		}

		// Function from file: packagewrap.dm
		public Obj_Item_Delivery ( dynamic loc = null, dynamic target = null, int? size = null ) : base( (object)(loc) ) {
			size = size ?? 2;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.wrapped = target;
			this.icon_state = "deliverycrate" + Num13.MinInt( size ??0, 5 );
			return;
		}

		// Function from file: packagewrap.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			dynamic O = null;
			string tag = null;
			string str = null;
			dynamic M = null;

			
			if ( a is Obj_Item_Device_DestTagger ) {
				O = a;

				if ( this.sortTag != O.currTag ) {
					tag = String13.ToUpper( O.destinations[O.currTag] );
					GlobalFuncs.to_chat( b, "<span class='notice'>*" + tag + "*</span>" );
					this.sortTag = tag;
					GlobalFuncs.playsound( GlobalFuncs.get_turf( this ), "sound/machines/twobeep.ogg", 100, 1 );
					this.overlays = 0;
					this.overlays.Add( "deliverytag" );
					this.desc = "A small wrapped package. It has a label reading " + tag;
				}
			} else if ( a is Obj_Item_Weapon_Pen ) {
				str = String13.SubStr( GlobalFuncs.sanitize( Interface13.Input( b, "Label text?", "Set label", "", null, InputType.Any ) ), 1, 26 );

				if ( !this.Adjacent( b ) || Lang13.Bool( b.stat ) ) {
					return null;
				}

				if ( !Lang13.Bool( str ) || !( Lang13.Length( str ) != 0 ) ) {
					GlobalFuncs.to_chat( b, "<span class='warning'>Invalid text.</span>" );
					return null;
				}

				foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, null ) )) {
					M = _a;
					
					GlobalFuncs.to_chat( M, "<span class='notice'>" + b + " labels " + this + " as " + str + ".</span>" );
				}
				this.name = "" + this.name + " (" + str + ")";
			}
			return null;
		}

		// Function from file: packagewrap.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( this.wrapped != null ) {
				
				if ( user is Mob_Living_Carbon_Human ) {
					((Mob)user).put_in_hands( this.wrapped );
				} else {
					this.wrapped.forceMove( GlobalFuncs.get_turf( this ) );
				}
			}
			GlobalFuncs.qdel( this );
			return null;
		}

		// Function from file: packagewrap.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			base.Destroy( (object)(brokenup) );

			if ( this.wrapped != null ) {
				this.wrapped.forceMove( GlobalFuncs.get_turf( this.loc ) );
			}
			return null;
		}

	}

}