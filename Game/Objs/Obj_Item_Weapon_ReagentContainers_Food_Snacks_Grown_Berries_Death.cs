// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Berries_Death : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Berries {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.seed = typeof(Obj_Item_Seeds_Deathberryseed);
			this.filling_color = "#708090";
			this.icon_state = "deathberrypile";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Berries_Death ( dynamic newloc = null, int? new_potency = null ) : base( (object)(newloc), new_potency ) {
			
		}

		// Function from file: grown.dm
		public override bool add_juice( dynamic loc = null, int? potency = null ) {
			base.add_juice( (object)(loc), potency );
			this.reagents.add_reagent( "toxin", Num13.Round( ( this.potency ??0) / 3, 1 ) + 3 );
			this.reagents.add_reagent( "lexorin", Num13.Round( ( this.potency ??0) / 5, 1 ) + 1 );
			return false;
		}

	}

}