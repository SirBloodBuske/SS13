// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Soft : Obj_Item_Clothing_Head {

		public bool flipped = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "helmet";
			this.item_color = "cargo";
			this.icon_state = "cargosoft";
		}

		public Obj_Item_Clothing_Head_Soft ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: soft_caps.dm
		public override double examine( dynamic user = null ) {
			base.examine( (object)(user) );
			user.WriteMsg( "<span class='notice'>Alt-click the cap to flip it " + ( this.flipped ? "forwards" : "backwards" ) + ".</span>" );
			return 0;
		}

		// Function from file: soft_caps.dm
		public void flip( Mob user = null ) {
			
			if ( user.canmove && !( user.stat != 0 ) && !user.restrained() ) {
				this.flipped = !this.flipped;

				if ( this.flipped ) {
					this.icon_state = "" + this.item_color + "soft_flipped";
					user.WriteMsg( "<span class='notice'>You flip the hat backwards.</span>" );
				} else {
					this.icon_state = "" + this.item_color + "soft";
					user.WriteMsg( "<span class='notice'>You flip the hat back in normal position.</span>" );
				}
				Task13.User.update_inv_head();
			}
			return;
		}

		// Function from file: soft_caps.dm
		public override bool AltClick( Mob user = null ) {
			base.AltClick( user );

			if ( !user.canUseTopic( user ) ) {
				user.WriteMsg( "<span class='warning'>You can't do that right now!</span>" );
				return false;
			}

			if ( !( Map13.GetDistance( this, user ) <= 1 ) ) {
				return false;
			} else {
				this.flip( user );
			}
			return false;
		}

		// Function from file: soft_caps.dm
		public override bool dropped( dynamic user = null ) {
			this.icon_state = "" + this.item_color + "soft";
			this.flipped = false;
			base.dropped( (object)(user) );
			return false;
		}

		// Function from file: soft_caps.dm
		[Verb]
		[VerbInfo( name: "Flip cap", group: "Object" )]
		public void flipcap(  ) {
			this.flip( Task13.User );
			return;
		}

	}

}