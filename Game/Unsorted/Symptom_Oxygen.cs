// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Symptom_Oxygen : Symptom {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Self-Respiration";
			this.stealth = 1;
			this.resistance = -3;
			this.stage_speed = -3;
			this.transmittable = -4;
			this.level = 6;
		}

		// Function from file: oxygen.dm
		public override void Activate( Disease_Advance A = null ) {
			dynamic M = null;

			base.Activate( A );

			if ( Rand13.PercentChance( 15 ) ) {
				M = A.affected_mob;

				switch ((int?)( A.stage )) {
					case 4:
					case 5:
						
						if ( ( ((Reagents)M.reagents).get_reagent_amount( "salbutamol" ) ?1:0) < 20 ) {
							((Reagents)M.reagents).add_reagent( "salbutamol", 20 );
						}
						break;
					default:
						
						if ( Rand13.PercentChance( 15 ) ) {
							M.WriteMsg( "<span class='notice'>" + Rand13.Pick(new object [] { "Your lungs feel great.", "You realize you haven't been breathing.", "You don't feel the need to breathe." }) + "</span>" );
						}
						break;
				}
			}
			return;
		}

	}

}