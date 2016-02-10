// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoCasing_Shotgun_Flare : Obj_Item_AmmoCasing_Shotgun {

		public Obj_Item_Device_Flashlight_Flare stored_flare = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.caliber = "flare";
			this.projectile_type = "/obj/item/projectile/flare";
			this.starting_materials = new ByTable().Set( "$iron", 1000 );
			this.icon_state = "flareshell";
		}

		// Function from file: flares.dm
		public Obj_Item_AmmoCasing_Shotgun_Flare ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.stored_flare = new Obj_Item_Device_Flashlight_Flare( this );
			return;
		}

		// Function from file: flares.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( this.stored_flare != null ) {
				GlobalFuncs.to_chat( Task13.User, "You disassemble the flare shell." );
				this.stored_flare.loc = Task13.User.loc;
				this.stored_flare = null;
				this.BB = null;
				this.icon_state = "flareshell-empty";
				this.update_icon();
			} else {
				GlobalFuncs.to_chat( Task13.User, "This flare is empty." );
			}
			return null;
		}

	}

}