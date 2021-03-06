// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Diphenhydramine : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Diphenhydramine";
			this.id = "diphenhydramine";
			this.result = "diphenhydramine";
			this.required_reagents = new ByTable().Set( "oil", 1 ).Set( "carbon", 1 ).Set( "bromine", 1 ).Set( "diethylamine", 1 ).Set( "ethanol", 1 );
			this.result_amount = 4;
			this.mix_message = "The mixture dries into a pale blue powder.";
		}

	}

}