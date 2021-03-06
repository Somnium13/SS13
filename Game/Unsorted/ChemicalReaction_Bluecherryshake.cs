// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Bluecherryshake : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Blue Cherry Shake";
			this.id = "bluecherryshake";
			this.result = "bluecherryshake";
			this.required_reagents = new ByTable().Set( "bluecherryjelly", 1 ).Set( "ice", 1 ).Set( "cream", 1 );
			this.result_amount = 3;
		}

	}

}