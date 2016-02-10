// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Vinegar : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Vinegar";
			this.id = "vinegar";
			this.result = "vinegar";
			this.required_reagents = new ByTable().Set( "wine", 5 );
			this.required_catalysts = new ByTable().Set( "enzyme", 5 );
			this.result_amount = 5;
		}

	}

}