// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Hyronalin : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Hyronalin";
			this.id = "hyronalin";
			this.description = "Hyronalin is a medicinal drug used to counter the effect of radiation poisoning.";
			this.reagent_state = 2;
			this.color = "#C8A5DC";
			this.custom_metabolism = 0.05;
			this.overdose = 30;
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}
			M.radiation = Num13.MaxInt( ((int)( M.radiation - 1.5 )), 0 );
			return false;
		}

	}

}