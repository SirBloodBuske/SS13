// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Toy_Crayon_Rainbow : Obj_Item_Toy_Crayon {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.colour = "#FFF000";
			this.shadeColour = "#000FFF";
			this.colourName = "rainbow";
			this.uses = 0;
			this.icon_state = "crayonrainbow";
		}

		public Obj_Item_Toy_Crayon_Rainbow ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: crayons.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			this.colour = Interface13.Input( user, "Please select the main colour.", "Crayon colour", null, null, InputType.Color );
			this.shadeColour = Interface13.Input( user, "Please select the shade colour.", "Crayon colour", null, null, InputType.Color );
			return null;
		}

	}

}