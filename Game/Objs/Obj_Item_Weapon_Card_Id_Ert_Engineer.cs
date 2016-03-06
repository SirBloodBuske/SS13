// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Card_Id_Ert_Engineer : Obj_Item_Weapon_Card_Id_Ert {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.registered_name = "Engineer Response Officer";
			this.assignment = "Engineer Response Officer";
		}

		// Function from file: cards_ids.dm
		public Obj_Item_Weapon_Card_Id_Ert_Engineer ( dynamic loc = null ) : base( (object)(loc) ) {
			this.access = GlobalFuncs.get_all_accesses() + GlobalFuncs.get_ert_access( "eng" ) - GlobalVars.access_change_ids;
			return;
		}

	}

}