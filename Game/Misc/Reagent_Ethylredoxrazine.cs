// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Ethylredoxrazine : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Ethylredoxrazine";
			this.id = "ethylredoxrazine";
			this.description = "A powerful oxidizer that reacts with ethanol.";
			this.color = "#605048";
		}

		// Function from file: Chemistry-Reagents.dm
		public override bool on_mob_life( Mob_Living M = null, int? alien = null ) {
			
			if ( base.on_mob_life( M, alien ) ) {
				return true;
			}
			M.dizziness = 0;
			M.drowsyness = 0;
			M.stuttering = 0;
			M.confused = 0;
			return false;
		}

	}

}