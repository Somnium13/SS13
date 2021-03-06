// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Salbutamol : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Salbutamol";
			this.id = "salbutamol";
			this.result = "salbutamol";
			this.required_reagents = new ByTable().Set( "sal_acid", 1 ).Set( "lithium", 1 ).Set( "aluminium", 1 ).Set( "bromine", 1 ).Set( "ammonia", 1 );
			this.result_amount = 5;
		}

	}

}