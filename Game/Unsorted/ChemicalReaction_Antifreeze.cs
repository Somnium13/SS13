// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Antifreeze : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Anti-freeze";
			this.id = "antifreeze";
			this.result = "antifreeze";
			this.required_reagents = new ByTable().Set( "vodka", 2 ).Set( "cream", 1 ).Set( "ice", 1 );
			this.result_amount = 4;
		}

	}

}