// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Screen_Alert_Embeddedobject : Obj_Screen_Alert {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "embeddedobject";
		}

		public Obj_Screen_Alert_Embeddedobject ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: alert.dm
		public override bool Click( dynamic loc = null, string control = null, string _params = null ) {
			Mob M = null;

			
			if ( Task13.User is Mob_Living ) {
				M = Task13.User;
				((Mob_Living_Carbon)M).help_shake_act( M ); return false;
			}
			return false;
		}

	}

}