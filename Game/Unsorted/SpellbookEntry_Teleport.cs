// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SpellbookEntry_Teleport : SpellbookEntry {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Teleport";
			this.spell_type = typeof(Obj_Effect_ProcHolder_Spell_Targeted_AreaTeleport_Teleport);
			this.log_name = "TP";
			this.category = "Mobility";
		}

	}

}