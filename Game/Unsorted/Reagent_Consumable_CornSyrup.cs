// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Reagent_Consumable_CornSyrup : Reagent_Consumable {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Corn Syrup";
			this.id = "corn_syrup";
			this.description = "Decays into sugar.";
			this.color = "#C8A5DC";
			this.metabolization_rate = 1.2;
		}

		// Function from file: food_reagents.dm
		public override bool on_mob_life( dynamic M = null ) {
			((Reagents)this.holder).add_reagent( "sugar", 3 );
			base.on_mob_life( (object)(M) );
			return false;
		}

	}

}