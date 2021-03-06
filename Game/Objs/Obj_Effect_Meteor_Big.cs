// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Meteor_Big : Obj_Effect_Meteor {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.hits = 6;
			this.heavy = true;
			this.dropamt = 4;
			this.icon_state = "large";
		}

		public Obj_Effect_Meteor_Big ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: meteors.dm
		public override void meteor_effect( bool? sound = null ) {
			base.meteor_effect( this.heavy );
			GlobalFuncs.explosion( this.loc, 1, 2, 3, 4, 0 );
			return;
		}

	}

}