// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Syndicatebomb : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Syndicate Bomb";
			this.id = "syndicatebomb";
			this.result = "syndicatebomb";
			this.required_reagents = new ByTable().Set( "beer", 1 ).Set( "whiskeycola", 1 );
			this.result_amount = 2;
		}

	}

}