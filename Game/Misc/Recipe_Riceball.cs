// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Recipe_Riceball : Recipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.reagents = new ByTable().Set( "rice", 5 );
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Riceball);
		}

	}

}