// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class FoodProcessorProcess_Mob_Chicken : FoodProcessorProcess_Mob {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.input = typeof(Mob_Living_SimpleAnimal_Chicken);
			this.output = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_ChickenNuggets);
		}

		// Function from file: processor.dm
		public override void process( Ent_Static loc = null, Ent_Dynamic what = null ) {
			GlobalFuncs.playsound( loc, "sound/machines/ya_dun_clucked.ogg", 50, 1 );
			base.process( loc, what );
			return;
		}

	}

}