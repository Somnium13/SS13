// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Hud_HogGod : Hud {

		// Function from file: other_mobs.dm
		public Hud_HogGod ( Mob_Camera_God owner = null ) : base( owner ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.healths = new Obj_Screen_Healths_Deity();
			this.infodisplay.Add( this.healths );
			this.deity_power_display = new Obj_Screen_DeityPowerDisplay();
			this.infodisplay.Add( this.deity_power_display );
			this.deity_follower_display = new Obj_Screen_DeityFollowerDisplay();
			this.infodisplay.Add( this.deity_follower_display );
			return;
		}

	}

}