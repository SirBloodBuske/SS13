// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Under_Vox : Obj_Item_Clothing_Under {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.has_sensor = 0;
			this.species_restricted = new ByTable(new object [] { "Vox" });
		}

		public Obj_Item_Clothing_Under_Vox ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}