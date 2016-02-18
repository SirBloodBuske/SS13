// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class NumberedDisplay : Game_Data {

		public Obj_Item sample_object = null;
		public double? number = null;

		// Function from file: storage.dm
		public NumberedDisplay ( Obj_Item sample = null ) {
			
			if ( !( sample is Obj_Item ) ) {
				GlobalFuncs.qdel( this );
			}
			this.sample_object = sample;
			this.number = 1;
			return;
		}

	}

}