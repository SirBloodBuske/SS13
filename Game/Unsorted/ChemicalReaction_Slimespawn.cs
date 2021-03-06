// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Slimespawn : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Slime Spawn";
			this.id = "m_spawn";
			this.required_reagents = new ByTable().Set( "plasma", 1 );
			this.result_amount = 1;
			this.required_container = typeof(Obj_Item_SlimeExtract_Grey);
			this.required_other = true;
		}

		// Function from file: slime_extracts.dm
		public override void on_reaction( Reagents holder = null, double? created_volume = null ) {
			Mob_Living_SimpleAnimal_Slime S = null;

			GlobalFuncs.feedback_add_details( "slime_cores_used", "" + this.type );
			S = new Mob_Living_SimpleAnimal_Slime();
			S.loc = GlobalFuncs.get_turf( holder.my_atom );
			S.visible_message( "<span class='danger'>Infused with plasma, the core begins to quiver and grow, and soon a new baby slime emerges from it!</span>" );
			return;
		}

	}

}