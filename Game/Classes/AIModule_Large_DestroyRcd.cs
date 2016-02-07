// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class AIModule_Large_DestroyRcd : AIModule_Large {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.module_name = "Destroy RCDs";
			this.mod_pick_name = "rcd";
			this.description = "Send a specialised pulse to detonate all hand-held and exosuit Rapid Cconstruction Devices on the station.";
			this.cost = 25;
			this.one_time = true;
			this.power_type = typeof(Mob_Living_Silicon_Ai).GetMethod( "disable_rcd" );
		}

	}

}