// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Ammonia : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Ammonia";
			this.id = "ammonia";
			this.result = "ammonia";
			this.required_reagents = new ByTable().Set( "hydrogen", 3 ).Set( "nitrogen", 1 );
			this.result_amount = 3;
		}

	}

}