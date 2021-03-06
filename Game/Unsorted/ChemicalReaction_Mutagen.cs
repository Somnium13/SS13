// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Mutagen : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Unstable mutagen";
			this.id = "mutagen";
			this.result = "mutagen";
			this.required_reagents = new ByTable().Set( "radium", 1 ).Set( "phosphorus", 1 ).Set( "chlorine", 1 );
			this.result_amount = 3;
		}

	}

}