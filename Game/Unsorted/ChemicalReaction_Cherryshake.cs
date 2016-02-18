// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Cherryshake : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cherry Shake";
			this.id = "cherryshake";
			this.result = "cherryshake";
			this.required_reagents = new ByTable().Set( "cherryjelly", 1 ).Set( "ice", 1 ).Set( "cream", 1 );
			this.result_amount = 3;
		}

	}

}