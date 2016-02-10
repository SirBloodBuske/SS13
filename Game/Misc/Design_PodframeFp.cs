// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_PodframeFp : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Fore port pod frame";
			this.desc = "Allows for the construction of spacepod frames. This is the fore port component.";
			this.id = "podframefp";
			this.build_type = 32;
			this.req_tech = new ByTable().Set( "materials", 3 ).Set( "engineering", 2 );
			this.build_path = typeof(Obj_Item_PodParts_PodFrame_ForePort);
			this.category = "Pod_Frame";
			this.materials = new ByTable().Set( "$iron", 15000 ).Set( "$glass", 5000 );
		}

	}

}