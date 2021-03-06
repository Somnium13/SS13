// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Toxin_Venom : Reagent_Toxin {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Venom";
			this.id = "venom";
			this.description = "An exotic poison extracted from highly toxic fauna. Causes scaling amounts of toxin damage and bruising depending and dosage. Often decays into Histamine.";
			this.metabolization_rate = 0.1;
			this.toxpwr = 0;
		}

		// Function from file: toxin_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			this.toxpwr = this.volume * 0.2;
			((Mob_Living)M).adjustBruteLoss( this.volume * 0.3 );

			if ( Rand13.PercentChance( 15 ) ) {
				((Reagents)M.reagents).add_reagent( "histamine", Rand13.Pick(new object [] { 5, 10 }) );
				((Reagents)M.reagents).remove_reagent( "venom", 1.1 );
			} else {
				base.on_mob_life( (object)(M) );
			}
			return false;
		}

	}

}