// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Consumable_Tonic : Reagent_Consumable {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Tonic Water";
			this.id = "tonic";
			this.description = "It tastes strange but at least the quinine keeps the Space Malaria at bay.";
			this.color = "#0064C8";
		}

		// Function from file: drink_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			M.dizziness = Num13.MaxInt( 0, M.dizziness - 5 );
			M.drowsyness = Num13.MaxInt( 0, M.drowsyness - 3 );
			((Mob)M).AdjustSleeping( -2 );

			if ( Convert.ToDouble( M.bodytemperature ) > 310 ) {
				M.bodytemperature = Num13.MaxInt( 310, Convert.ToInt32( M.bodytemperature - 7.5 ) );
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}