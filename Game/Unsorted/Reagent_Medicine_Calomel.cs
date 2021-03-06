// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Medicine_Calomel : Reagent_Medicine {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Calomel";
			this.id = "calomel";
			this.description = "Quickly purges the body of all chemicals. Toxin damage is dealt if the patient is in good condition.";
			this.color = "#C8A5DC";
			this.metabolization_rate = 0.2;
		}

		// Function from file: medicine_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			Reagent R = null;

			
			foreach (dynamic _a in Lang13.Enumerate( M.reagents.reagent_list, typeof(Reagent) )) {
				R = _a;
				

				if ( R != this ) {
					((Reagents)M.reagents).remove_reagent( R.id, 2.5 );
				}
			}

			if ( Convert.ToDouble( M.health ) > 20 ) {
				((Mob_Living)M).adjustToxLoss( 2.5 );
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}