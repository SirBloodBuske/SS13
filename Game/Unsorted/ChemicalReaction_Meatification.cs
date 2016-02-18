// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Meatification : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Meatification";
			this.id = "meatification";
			this.required_reagents = new ByTable().Set( "liquidgibs", 10 ).Set( "nutriment", 10 ).Set( "carbon", 10 );
			this.result_amount = 1;
			this.mob_react = true;
		}

		// Function from file: others.dm
		public override void on_reaction( Reagents holder = null, double? created_volume = null ) {
			dynamic location = null;

			location = GlobalFuncs.get_turf( holder.my_atom );
			new Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Slab_Meatproduct( location );
			return;
		}

	}

}