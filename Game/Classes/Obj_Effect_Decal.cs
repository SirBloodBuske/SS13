// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Decal : Obj_Effect {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/effects/effects.dmi";
		}

		public Obj_Effect_Decal ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: decal.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			GlobalFuncs.qdel( this );
			return false;
		}

	}

}