// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RoundEvent_Wizard_Darkness : RoundEvent_Wizard {

		// Function from file: advanced_darkness.dm
		public override bool start(  ) {
			Weather_AdvancedDarkness darkness = null;

			darkness = new Weather_AdvancedDarkness();
			darkness.weather_start_up();
			return false;
		}

	}

}