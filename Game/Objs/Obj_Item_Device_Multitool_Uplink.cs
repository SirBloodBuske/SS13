// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Multitool_Uplink : Obj_Item_Device_Multitool {

		// Function from file: uplinks.dm
		public Obj_Item_Device_Multitool_Uplink ( dynamic loc = null ) : base( (object)(loc) ) {
			this.hidden_uplink = new Obj_Item_Device_Uplink_Hidden( this );
			return;
		}

		// Function from file: uplinks.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( this.hidden_uplink != null ) {
				this.hidden_uplink.trigger( user );
			}
			return null;
		}

	}

}