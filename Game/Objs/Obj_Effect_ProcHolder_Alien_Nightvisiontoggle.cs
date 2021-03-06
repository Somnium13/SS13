// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_ProcHolder_Alien_Nightvisiontoggle : Obj_Effect_ProcHolder_Alien {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.has_action = false;
		}

		public Obj_Effect_ProcHolder_Alien_Nightvisiontoggle ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: alien_powers.dm
		public override bool fire( Mob user = null ) {
			
			if ( !Lang13.Bool( ((dynamic)user).nightvision ) ) {
				user.see_in_dark = 8;
				user.see_invisible = 5;
				((dynamic)user).nightvision = 1;
				user.hud_used.nightvisionicon.icon_state = "nightvision1";
			} else if ( Lang13.Bool( ((dynamic)user).nightvision ) == true ) {
				user.see_in_dark = 4;
				user.see_invisible = 45;
				((dynamic)user).nightvision = 0;
				user.hud_used.nightvisionicon.icon_state = "nightvision0";
			}
			return true;
		}

	}

}