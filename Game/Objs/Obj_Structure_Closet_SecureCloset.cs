// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_SecureCloset : Obj_Structure_Closet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.locked = true;
			this.health = 200;
			this.secure = true;
			this.icon_state = "secure";
		}

		public Obj_Structure_Closet_SecureCloset ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}