// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Toy_Cards_Deck_Syndicate : Obj_Item_Toy_Cards_Deck {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.deckstyle = "syndicate";
			this.card_hitsound = "sound/weapons/bladeslice.ogg";
			this.card_force = 5;
			this.card_throwforce = 10;
			this.card_attack_verb = new ByTable(new object [] { "attacked", "sliced", "diced", "slashed", "cut" });
		}

		public Obj_Item_Toy_Cards_Deck_Syndicate ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}