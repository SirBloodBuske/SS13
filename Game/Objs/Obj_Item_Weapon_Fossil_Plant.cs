// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Fossil_Plant : Obj_Item_Weapon_Fossil {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "plant1";
		}

		// Function from file: finds_fossils.dm
		public Obj_Item_Weapon_Fossil_Plant ( dynamic loc = null ) : base( (object)(loc) ) {
			ByTable prehistoric_plants = null;

			this.icon_state = "plant" + Rand13.Int( 1, 4 );
			prehistoric_plants = new ByTable(new object [] { 
				typeof(Obj_Item_Seeds_Telriis), 
				typeof(Obj_Item_Seeds_Thaadra), 
				typeof(Obj_Item_Seeds_Jurlmah), 
				typeof(Obj_Item_Seeds_Amauri), 
				typeof(Obj_Item_Seeds_Gelthi), 
				typeof(Obj_Item_Seeds_Vale), 
				typeof(Obj_Item_Seeds_Surik)
			 });
			this.nonplant_seed_type = Rand13.PickFromTable( prehistoric_plants );
			return;
		}

	}

}