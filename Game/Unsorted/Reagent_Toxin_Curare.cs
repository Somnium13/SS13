// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Toxin_Curare : Reagent_Toxin {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Curare";
			this.id = "curare";
			this.description = "Causes slight toxin damage followed by chain-stunning and oxygen damage.";
			this.metabolization_rate = 0.05;
			this.toxpwr = 1;
		}

		// Function from file: toxin_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			
			if ( this.current_cycle >= 11 ) {
				((Mob)M).Weaken( 3 );
			}
			((Mob_Living)M).adjustOxyLoss( 1 );
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}