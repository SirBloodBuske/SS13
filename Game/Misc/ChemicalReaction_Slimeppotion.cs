// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Slimeppotion : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Slime Potion";
			this.id = "m_potion";
			this.required_reagents = new ByTable().Set( "plasma", 5 );
			this.result_amount = 1;
			this.required_container = typeof(Obj_Item_SlimeExtract_Pink);
			this.required_other = true;
		}

		// Function from file: Chemistry-Recipes.dm
		public override void on_reaction( Reagents holder = null, int? created_volume = null ) {
			Obj_Item_Weapon_Slimepotion P = null;

			GlobalFuncs.feedback_add_details( "slime_cores_used", "" + GlobalFuncs.replacetext( this.name, " ", "_" ) );
			P = new Obj_Item_Weapon_Slimepotion();
			P.loc = GlobalFuncs.get_turf( holder.my_atom );
			return;
		}

	}

}