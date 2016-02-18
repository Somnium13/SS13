// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Job_Officer : Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.title = "Security Officer";
			this.flag = 16;
			this.department_head = new ByTable(new object [] { "Head of Security" });
			this.department_flag = 1;
			this.faction = "Station";
			this.total_positions = 5;
			this.spawn_positions = 5;
			this.supervisors = "the head of security, and the head of your assigned department (if applicable)";
			this.selection_color = "#ffeeee";
			this.minimal_player_age = 7;
			this.outfit = typeof(Outfit_Job_Security);
			this.access = new ByTable(new object [] { 1, 63, 2, 42, 12, 6, 66, 4 });
			this.minimal_access = new ByTable(new object [] { 1, 63, 2, 42, 66 });
		}

		// Function from file: security.dm
		public override ByTable get_access(  ) {
			ByTable L = null;

			L = new ByTable();
			L.Or( base.get_access() | this.check_config_for_sec_maint() );
			return L;
		}

	}

}