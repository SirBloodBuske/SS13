// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Decal_Cleanable_PieSmudge : Obj_Effect_Decal_Cleanable {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.random_icon_states = new ByTable(new object [] { "smashed_pie" });
			this.icon = "icons/effects/tomatodecal.dmi";
		}

		public Obj_Effect_Decal_Cleanable_PieSmudge ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}