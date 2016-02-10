// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Bed_Chair_Vehicle_Gokart : Obj_Structure_Bed_Chair_Vehicle {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.keytype = typeof(Obj_Item_Key_Gokart);
			this.icon_state = "gokart0";
		}

		public Obj_Structure_Bed_Chair_Vehicle_Gokart ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: gokart.dm
		public override void update_mob(  ) {
			
			if ( !Lang13.Bool( this.occupant ) ) {
				return;
			}

			switch ((int)( this.dir )) {
				case 2:
					this.occupant.pixel_x = 0;
					this.occupant.pixel_y = 7;
					break;
				case 8:
					this.occupant.pixel_x = 4;
					this.occupant.pixel_y = 7;
					break;
				case 1:
					this.occupant.pixel_x = 0;
					this.occupant.pixel_y = 4;
					break;
				case 4:
					this.occupant.pixel_x = -4;
					this.occupant.pixel_y = 7;
					break;
			}
			return;
		}

		// Function from file: gokart.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			this.icon_state = "gokart" + !Lang13.Bool( this.occupant );
			return null;
		}

		// Function from file: gokart.dm
		public override bool lock_atom( dynamic AM = null ) {
			bool _default = false;

			_default = base.lock_atom( (object)(AM) );
			this.update_icon();
			return _default;
		}

		// Function from file: gokart.dm
		public override bool unlock_atom( dynamic AM = null ) {
			bool _default = false;

			_default = base.unlock_atom( (object)(AM) );
			this.update_icon();
			return _default;
		}

	}

}