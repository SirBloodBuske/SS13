// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Organ_Internal_Cyberimp_Eyes_Shield_Ling : Obj_Item_Organ_Internal_Cyberimp_Eyes_Shield {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.eye_color = null;
			this.origin_tech = "biotech=4";
			this.slot = "eye_ling";
			this.icon_state = "ling_eyeshield";
		}

		public Obj_Item_Organ_Internal_Cyberimp_Eyes_Shield_Ling ( dynamic M = null ) : base( (object)(M) ) {
			
		}

		// Function from file: augmented_eyesight.dm
		public override Obj_Item_Weapon_ReagentContainers_Food_Snacks_Organ prepare_eat(  ) {
			Obj_Item_Weapon_ReagentContainers_Food_Snacks_Organ S = null;

			S = base.prepare_eat();
			S.reagents.add_reagent( "oculine", 15 );
			return S;
		}

		// Function from file: augmented_eyesight.dm
		public override void on_life(  ) {
			base.on_life();

			if ( this.owner.eye_blind > 1 || this.owner.eye_blind != 0 && Lang13.Bool( this.owner.stat ) != true || this.owner.eye_damage != 0 || this.owner.eye_blurry != 0 || Lang13.Bool( this.owner.disabilities & 8 ) ) {
				this.owner.reagents.add_reagent( "oculine", 1 );
			}
			return;
		}

	}

}