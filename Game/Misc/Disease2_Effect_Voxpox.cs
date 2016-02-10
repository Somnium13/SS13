// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Disease2_Effect_Voxpox : Disease2_Effect {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Vox Pox";
			this.badness = 2;
		}

		// Function from file: effect.dm
		public override bool activate( Mob_Living mob = null, bool multiplier = false ) {
			Mob_Living h = null;

			
			if ( mob is Mob_Living_Carbon_Human ) {
				h = mob;

				if ( ((dynamic)h).species.name != "Vox" ) {
					
					if ( ((Mob_Living_Carbon_Human)h).set_species( "Vox" ) ) {
						h.regenerate_icons();
					}
				}
			}
			return false;
		}

	}

}