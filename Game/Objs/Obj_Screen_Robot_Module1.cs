// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Screen_Robot_Module1 : Obj_Screen_Robot {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "inv1";
		}

		public Obj_Screen_Robot_Module1 ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: robot.dm
		public override bool Click( dynamic loc = null, string control = null, string _params = null ) {
			Mob R = null;

			R = Task13.User;
			((dynamic)R).toggle_module( 1 );
			return false;
		}

	}

}