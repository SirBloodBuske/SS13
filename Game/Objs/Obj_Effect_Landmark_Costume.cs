// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Landmark_Costume : Obj_Effect_Landmark {

		// Function from file: landmarks.dm
		public Obj_Effect_Landmark_Costume ( dynamic loc = null ) : base( (object)(loc) ) {
			dynamic options = null;
			dynamic PICK = null;

			options = Lang13.GetTypes( typeof(Obj_Effect_Landmark_Costume) );
			PICK = options[Rand13.Int( 1, options.len )];
			Lang13.Call( PICK, this.loc );
			GlobalFuncs.qdel( this );
			return;
		}

	}

}