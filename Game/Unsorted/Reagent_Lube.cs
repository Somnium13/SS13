// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Lube : Reagent {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Space Lube";
			this.id = "lube";
			this.description = "Lubricant is a substance introduced between two moving surfaces to reduce the friction and wear between them. giggity.";
			this.color = "#009CA8";
		}

		// Function from file: other_reagents.dm
		public override void reaction_turf( dynamic T = null, double? volume = null ) {
			
			if ( !( T is Tile_Simulated ) ) {
				return;
			}

			if ( ( volume ??0) >= 1 ) {
				((Tile_Simulated)T).MakeSlippery( 2 );
			}
			return;
		}

	}

}