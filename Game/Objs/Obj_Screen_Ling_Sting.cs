// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Screen_Ling_Sting : Obj_Screen_Ling {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.screen_loc = "WEST:6,CENTER-3:11";
		}

		public Obj_Screen_Ling_Sting ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: human.dm
		public override bool Click( dynamic loc = null, string control = null, string _params = null ) {
			Mob U = null;

			U = Task13.User;
			((Mob_Living_Carbon)U).unset_sting();
			return false;
		}

	}

}