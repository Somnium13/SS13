// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class RoundEvent_MeteorWave_Spooky : RoundEvent_MeteorWave {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.endWhen = 40;
		}

		// Function from file: halloween.dm
		public override void tick(  ) {
			
			if ( GlobalFuncs.IsMultiple( this.activeFor, 4 ) ) {
				GlobalFuncs.spawn_meteors( 3, GlobalVars.meteorsSPOOKY );
			}
			return;
		}

	}

}