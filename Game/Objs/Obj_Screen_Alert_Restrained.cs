// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Screen_Alert_Restrained : Obj_Screen_Alert {

		public Obj_Screen_Alert_Restrained ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: alert.dm
		public override bool Click( dynamic loc = null, string control = null, string _params = null ) {
			Mob L = null;

			
			if ( Task13.User is Mob_Living ) {
				L = Task13.User;
				((Mob_Living)L).resist(); return false;
			}
			return false;
		}

	}

}