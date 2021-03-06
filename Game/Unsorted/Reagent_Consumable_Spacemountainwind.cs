// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Consumable_Spacemountainwind : Reagent_Consumable {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "SM Wind";
			this.id = "spacemountainwind";
			this.description = "Blows right through you like a space wind.";
			this.color = "#102000";
		}

		// Function from file: drink_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			M.drowsyness = Num13.MaxInt( 0, M.drowsyness - 7 );
			((Mob)M).AdjustSleeping( -1 );

			if ( Convert.ToDouble( M.bodytemperature ) > 310 ) {
				M.bodytemperature = Num13.MaxInt( 310, Convert.ToInt32( M.bodytemperature - 7.5 ) );
			}
			((Mob)M).Jitter( 5 );
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}