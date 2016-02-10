// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Sacid : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Sulphuric Acid";
			this.id = "sacid";
			this.result = "sacid";
			this.required_reagents = new ByTable().Set( "sulfur", 2 ).Set( "oxygen", 3 ).Set( "water", 2 );
			this.result_amount = 2;
		}

	}

}