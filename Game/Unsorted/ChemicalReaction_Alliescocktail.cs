// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Alliescocktail : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Allies Cocktail";
			this.id = "alliescocktail";
			this.result = "alliescocktail";
			this.required_reagents = new ByTable().Set( "martini", 1 ).Set( "vodka", 1 );
			this.result_amount = 2;
		}

	}

}