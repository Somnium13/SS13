// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_BeepskySmash : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Beepksy Smash";
			this.id = "beepksysmash";
			this.result = "beepskysmash";
			this.required_reagents = new ByTable().Set( "limejuice", 2 ).Set( "whiskey", 2 ).Set( "iron", 1 );
			this.result_amount = 4;
		}

	}

}