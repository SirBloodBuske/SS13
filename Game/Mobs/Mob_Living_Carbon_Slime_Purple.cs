// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Mob_Living_Carbon_Slime_Purple : Mob_Living_Carbon_Slime {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.colour = "purple";
			this.primarytype = typeof(Mob_Living_Carbon_Slime_Purple);
			this.adulttype = typeof(Mob_Living_Carbon_Slime_Adult_Purple);
			this.coretype = typeof(Obj_Item_SlimeExtract_Purple);
			this.icon_state = "purple baby slime";
		}

		public Mob_Living_Carbon_Slime_Purple ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}