// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Thirteenloko : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Thirteen Loko";
			this.id = "thirteenloko";
			this.result = "thirteenloko";
			this.required_reagents = new ByTable().Set( "vodka", 1 ).Set( "coffee", 1 ).Set( "limejuice", 1 );
			this.result_amount = 3;
		}

	}

}