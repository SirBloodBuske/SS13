// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoCasing_Magic_Death : Obj_Item_AmmoCasing_Magic {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.projectile_type = typeof(Obj_Item_Projectile_Magic_Death);
		}

		public Obj_Item_AmmoCasing_Magic_Death ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}