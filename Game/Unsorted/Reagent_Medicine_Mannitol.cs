// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Medicine_Mannitol : Reagent_Medicine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Mannitol";
			this.id = "mannitol";
			this.description = "Efficiently restores brain damage.";
			this.color = "#C8A5DC";
		}

		// Function from file: medicine_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			((Mob_Living)M).adjustBrainLoss( -3 );
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}