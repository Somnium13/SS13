// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Job_Mime : Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.title = "Mime";
			this.flag = 4096;
			this.department_head = new ByTable(new object [] { "Head of Personnel" });
			this.department_flag = 4;
			this.faction = "Station";
			this.total_positions = 1;
			this.spawn_positions = 1;
			this.supervisors = "the head of personnel";
			this.selection_color = "#dddddd";
			this.outfit = typeof(Outfit_Job_Mime);
			this.access = new ByTable(new object [] { 46 });
			this.minimal_access = new ByTable(new object [] { 46 });
		}

	}

}