// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_DryingAgent : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Drying agent";
			this.id = "drying_agent";
			this.result = "drying_agent";
			this.required_reagents = new ByTable().Set( "stable_plasma", 2 ).Set( "ethanol", 1 ).Set( "sodium", 1 );
			this.result_amount = 3;
		}

	}

}