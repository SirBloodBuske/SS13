// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Toy_Cards_Wizard : Obj_Item_Toy_Cards {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.strict_deck = false;
			this.icon = "icons/obj/wiz_cards.dmi";
			this.icon_state = "wizdeck_low";
		}

		public Obj_Item_Toy_Cards_Wizard ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: wizard_cards.dm
		public override bool? update_icon( dynamic location = null, dynamic target = null ) {
			
			if ( this.cards.len > 15 ) {
				this.icon_state = "wizdeck_full";
			} else if ( this.cards.len > 8 ) {
				this.icon_state = "wizdeck_half";
			} else if ( this.cards.len > 1 ) {
				this.icon_state = "wizdeck_low";
			} else {
				this.icon_state = "wizdeck_empty";
			}
			return null;
		}

		// Function from file: wizard_cards.dm
		public override void generate_cards(  ) {
			return;
		}

	}

}