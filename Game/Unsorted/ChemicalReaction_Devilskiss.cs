// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Devilskiss : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Devils Kiss";
			this.id = "devilskiss";
			this.result = "devilskiss";
			this.required_reagents = new ByTable().Set( "blood", 1 ).Set( "kahlua", 1 ).Set( "rum", 1 );
			this.result_amount = 3;
		}

	}

}