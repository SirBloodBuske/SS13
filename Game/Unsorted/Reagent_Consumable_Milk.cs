// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Consumable_Milk : Reagent_Consumable {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Milk";
			this.id = "milk";
			this.description = "An opaque white liquid produced by the mammary glands of mammals.";
			this.color = "#DFDFDF";
		}

		// Function from file: drink_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			
			if ( ((Mob_Living)M).getBruteLoss() != 0 && Rand13.PercentChance( 20 ) ) {
				((Mob_Living)M).heal_organ_damage( 1, 0 );
			}

			if ( Lang13.Bool( ((Reagents)this.holder).has_reagent( "capsaicin" ) ) ) {
				((Reagents)this.holder).remove_reagent( "capsaicin", 2 );
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}