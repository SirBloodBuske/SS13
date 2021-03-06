// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Donut_Chaos : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Donut {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bitesize = 10;
		}

		// Function from file: snacks_pastry.dm
		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Donut_Chaos ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.extra_reagent = Rand13.Pick(new object [] { "nutriment", "capsaicin", "frostoil", "krokodil", "plasma", "cocoa", "slimejelly", "banana", "berryjuice", "omnizine" });
			this.reagents.add_reagent( "" + this.extra_reagent, 3 );
			this.bonus_reagents = new ByTable().Set( "" + this.extra_reagent, 3 ).Set( "sugar", 1 );

			if ( Rand13.PercentChance( 30 ) ) {
				this.icon_state = "donut2";
				this.name = "frosted chaos donut";
				this.reagents.add_reagent( "sprinkles", 2 );
				this.bonus_reagents = new ByTable().Set( "sprinkles", 2 ).Set( "" + this.extra_reagent, 3 ).Set( "sugar", 1 );
				this.filling_color = "#FF69B4";
			}
			return;
		}

	}

}