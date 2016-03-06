// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tea_Astra : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tea {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.seed = typeof(Obj_Item_Seeds_TeaAstraSeed);
			this.filling_color = "#4582B4";
			this.icon_state = "tea_astra_leaves";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Tea_Astra ( dynamic newloc = null, int? new_potency = null ) : base( (object)(newloc), new_potency ) {
			
		}

		// Function from file: grown.dm
		public override bool add_juice( dynamic loc = null, int? potency = null ) {
			base.add_juice( (object)(loc), potency );
			this.reagents.add_reagent( "salglu_solution", Num13.Round( ( this.potency ??0) / 20, 1 ) + 1 );
			return false;
		}

	}

}