// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Toxin_Heparin : Reagent_Toxin {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Heparin";
			this.id = "heparin";
			this.description = "A powerful anticoagulant. Victims will bleed uncontrollably and suffer scaling bruising.";
			this.color = "#C8C8C8";
			this.metabolization_rate = 0.08;
			this.toxpwr = 0;
		}

		// Function from file: toxin_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			dynamic H = null;

			
			if ( M is Mob_Living_Carbon_Human ) {
				H = M;
				H.blood_max += 2;
				((Mob_Living)H).adjustBruteLoss( 1 );
			}
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}