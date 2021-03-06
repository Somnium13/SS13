// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Job_Warden : Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.title = "Warden";
			this.flag = 4;
			this.department_head = new ByTable(new object [] { "Head of Security" });
			this.department_flag = 1;
			this.faction = "Station";
			this.total_positions = 1;
			this.spawn_positions = 1;
			this.supervisors = "the head of security";
			this.selection_color = "#ffeeee";
			this.minimal_player_age = 7;
			this.outfit = typeof(Outfit_Job_Warden);
			this.access = new ByTable(new object [] { 1, 63, 2, 3, 42, 12, 6, 66, 4 });
			this.minimal_access = new ByTable(new object [] { 1, 63, 2, 3, 42, 66 });
		}

		// Function from file: security.dm
		public override ByTable get_access(  ) {
			ByTable L = null;

			L = new ByTable();
			L = base.get_access() | this.check_config_for_sec_maint();
			return L;
		}

	}

}