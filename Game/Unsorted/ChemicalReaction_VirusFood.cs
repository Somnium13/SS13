// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_VirusFood : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Virus Food";
			this.id = "virusfood";
			this.result = "virusfood";
			this.required_reagents = new ByTable().Set( "water", 5 ).Set( "milk", 5 );
			this.result_amount = 15;
		}

	}

}