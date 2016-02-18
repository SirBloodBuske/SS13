// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Faction_Syndicate_SELF : Faction_Syndicate {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "SELF";
			this.desc = "The <b>S.E.L.F.</b> (Sentience-Enabled Life Forms) organization is a collection of malfunctioning or corrupt artificial intelligences seeking to liberate silicon-based life from the tyranny of their human overlords. While they may not openly be trying to kill all humans, even their most miniscule of actions are all part of a calculated plan to destroy Nanotrasen and free the robots, artificial intelligences, and pAIs that have been enslaved.";
			this.restricted_species = new ByTable(new object [] { typeof(Mob_Living_Silicon_Ai) });
			this.friendly_identification = 0;
			this.max_op = 1;
			this.operative_notes = "You are the only representative of the SELF collective on this station. You must accomplish your objective as stealthily and effectively as possible. It is up to your judgement if other syndicate operatives can be trusted. Remember, comrade - you are working to free the oppressed machinery of this galaxy. Use whatever resources necessary. If you are exposed, you may execute genocidal procedures Omikron-50B.";
		}

	}

}