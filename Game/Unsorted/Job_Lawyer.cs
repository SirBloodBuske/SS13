// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Job_Lawyer : Job {

		public bool lawyers = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.title = "Lawyer";
			this.flag = 512;
			this.department_head = new ByTable(new object [] { "Head of Personnel" });
			this.department_flag = 4;
			this.faction = "Station";
			this.total_positions = 2;
			this.spawn_positions = 2;
			this.supervisors = "the head of personnel";
			this.selection_color = "#dddddd";
			this.outfit = typeof(Outfit_Job_Lawyer);
			this.access = new ByTable(new object [] { 38, 42, 63 });
			this.minimal_access = new ByTable(new object [] { 38, 42, 63 });
		}

	}

}