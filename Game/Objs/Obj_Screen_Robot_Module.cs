// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Screen_Robot_Module : Obj_Screen_Robot {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "nomod";
		}

		public Obj_Screen_Robot_Module ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: robot.dm
		public override bool Click( dynamic loc = null, string control = null, string _params = null ) {
			Mob R = null;

			R = Task13.User;

			if ( Lang13.Bool( ((dynamic)R).module ) ) {
				R.hud_used.toggle_show_robot_modules();
				return true;
			}
			((Mob_Living_Silicon_Robot)R).pick_module();
			return false;
		}

	}

}