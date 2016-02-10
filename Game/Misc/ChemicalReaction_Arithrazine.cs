// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Arithrazine : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Arithrazine";
			this.id = "arithrazine";
			this.result = "arithrazine";
			this.required_reagents = new ByTable().Set( "hyronalin", 1 ).Set( "hydrogen", 1 );
			this.result_amount = 2;
		}

	}

}