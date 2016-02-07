// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Job_Captain : Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.title = "Captain";
			this.flag = 1;
			this.department_head = new ByTable(new object [] { "Centcom" });
			this.department_flag = 1;
			this.faction = "Station";
			this.total_positions = 1;
			this.spawn_positions = 1;
			this.supervisors = "Nanotrasen officials and Space law";
			this.selection_color = "#ccccff";
			this.req_admin_notify = true;
			this.minimal_player_age = 14;
			this.outfit = typeof(Outfit_Job_Captain);
			this.access = new ByTable();
			this.minimal_access = new ByTable();
		}

		// Function from file: captain.dm
		public override ByTable get_access(  ) {
			return GlobalFuncs.get_all_accesses();
		}

	}

}