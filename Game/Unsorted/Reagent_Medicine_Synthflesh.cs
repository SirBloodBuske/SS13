// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Medicine_Synthflesh : Reagent_Medicine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Synthflesh";
			this.id = "synthflesh";
			this.description = "Has a 100% chance of instantly healing brute and burn damage. One unit of the chemical will heal one point of damage. Touch application only.";
			this.color = "#C8A5DC";
		}

		// Function from file: medicine_reagents.dm
		public override double reaction_mob( dynamic M = null, int? method = null, double? reac_volume = null, bool? show_message = null, dynamic touch_protection = null, Mob_Camera_Blob O = null ) {
			method = method ?? GlobalVars.TOUCH;
			show_message = show_message ?? true;

			
			if ( M is Mob_Living_Carbon && Convert.ToInt32( M.stat ) != 2 ) {
				
				if ( new ByTable(new object [] { GlobalVars.PATCH, GlobalVars.TOUCH }).Contains( method ) ) {
					((Mob_Living)M).adjustBruteLoss( ( reac_volume ??0) * -1.25 );
					((Mob_Living)M).adjustFireLoss( ( reac_volume ??0) * -1.25 );

					if ( show_message == true ) {
						M.WriteMsg( "<span class='danger'>You feel your burns and bruises healing! It stings like hell!</span>" );
					}
				}
			}
			base.reaction_mob( (object)(M), method, reac_volume, show_message, (object)(touch_protection), O );
			return 0;
		}

	}

}