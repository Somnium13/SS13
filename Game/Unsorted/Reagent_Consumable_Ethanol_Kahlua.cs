// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Consumable_Ethanol_Kahlua : Reagent_Consumable_Ethanol {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Kahlua";
			this.id = "kahlua";
			this.description = "A widely known, Mexican coffee-flavoured liqueur. In production since 1936!";
			this.color = "#664300";
			this.boozepwr = 45;
		}

		// Function from file: alcohol_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			M.dizziness = Num13.MaxInt( 0, M.dizziness - 5 );
			M.drowsyness = Num13.MaxInt( 0, M.drowsyness - 3 );
			((Mob)M).AdjustSleeping( -2 );
			((Mob)M).Jitter( 5 );
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}