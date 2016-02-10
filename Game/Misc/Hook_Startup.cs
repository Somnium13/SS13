// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Hook_Startup : Hook {

		// Function from file: _gas_mixture.dm
		public bool createGasOverlays(  ) {
			GlobalVars.plmaster = new Obj_Effect_Overlay();
			GlobalVars.plmaster.icon = "icons/effects/tile_effects.dmi";
			GlobalVars.plmaster.icon_state = "plasma";
			GlobalVars.plmaster.layer = GlobalVars.FLY_LAYER;
			GlobalVars.plmaster.mouse_opacity = 0;
			GlobalVars.slmaster = new Obj_Effect_Overlay();
			GlobalVars.slmaster.icon = "icons/effects/tile_effects.dmi";
			GlobalVars.slmaster.icon_state = "sleeping_agent";
			GlobalVars.slmaster.layer = GlobalVars.FLY_LAYER;
			GlobalVars.slmaster.mouse_opacity = 0;
			return true;
		}

		// Function from file: datacore.dm
		public bool createDatacore(  ) {
			GlobalVars.data_core = new Obj_Effect_Datacore();
			return true;
		}

	}

}