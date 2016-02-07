// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Blob_Normal : Obj_Effect_Blob {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.luminosity = 0;
			this.health = 21;
			this.maxhealth = 25;
			this.health_regen = 1;
			this.brute_resist = 0.25;
			this.icon_state = "blob";
		}

		public Obj_Effect_Blob_Normal ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: theblob.dm
		public override bool? update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			base.update_icon( (object)(new_state), (object)(new_icon), new_px, new_py );

			if ( this.health <= 10 ) {
				this.icon_state = "blob_damaged";
				this.name = "fragile blob";
				this.desc = "A thin lattice of slightly twitching tendrils.";
				this.brute_resist = 0.5;
			} else {
				this.icon_state = "blob";
				this.name = "blob";
				this.desc = "A thick wall of writhing tendrils.";
				this.brute_resist = 0.25;
			}
			return null;
		}

	}

}