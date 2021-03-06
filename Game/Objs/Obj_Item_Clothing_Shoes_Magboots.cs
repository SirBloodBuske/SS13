// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Shoes_Magboots : Obj_Item_Clothing_Shoes {

		public string magboot_state = "magboots";
		public bool magpulse = false;
		public int slowdown_active = 2;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.action_button_name = "Toggle Magboots";
			this.strip_delay = 70;
			this.put_on_delay = 70;
			this.origin_tech = "magnets=2";
			this.icon_state = "magboots0";
		}

		public Obj_Item_Clothing_Shoes_Magboots ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: magboots.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );
			user.WriteMsg( "Its mag-pulse traction system appears to be " + ( this.magpulse ? "enabled" : "disabled" ) + "." );
			return 0;
		}

		// Function from file: magboots.dm
		public override dynamic negates_gravity(  ) {
			return this.flags & 1024;
		}

		// Function from file: magboots.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( this.magpulse ) {
				this.flags &= 64511;
				this.slowdown = 0;
			} else {
				this.flags |= 1024;
				this.slowdown = this.slowdown_active;
			}
			this.magpulse = !this.magpulse;
			this.icon_state = "" + this.magboot_state + this.magpulse;
			user.WriteMsg( "<span class='notice'>You " + ( this.magpulse ? "enable" : "disable" ) + " the mag-pulse traction system.</span>" );
			((Mob)user).update_inv_shoes();
			((Mob)user).update_gravity( ((Mob)user).mob_has_gravity() );
			return null;
		}

		// Function from file: magboots.dm
		[Verb]
		[VerbInfo( name: "Toggle Magboots", group: "Object", access: VerbAccess.InUserContents, range: 127 )]
		public void toggle(  ) {
			
			if ( !this.can_use( Task13.User ) ) {
				return;
			}
			this.attack_self( Task13.User );
			return;
		}

	}

}