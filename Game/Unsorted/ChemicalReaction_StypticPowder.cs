// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_StypticPowder : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Styptic Powder";
			this.id = "styptic_powder";
			this.result = "styptic_powder";
			this.required_reagents = new ByTable().Set( "aluminium", 1 ).Set( "hydrogen", 1 ).Set( "oxygen", 1 ).Set( "sacid", 1 );
			this.result_amount = 4;
			this.mix_message = "The solution yields an astringent powder.";
		}

	}

}