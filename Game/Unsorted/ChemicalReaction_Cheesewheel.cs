// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class ChemicalReaction_Cheesewheel : ChemicalReaction {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cheesewheel";
			this.id = "cheesewheel";
			this.required_reagents = new ByTable().Set( "milk", 40 );
			this.required_catalysts = new ByTable().Set( "enzyme", 5 );
			this.result_amount = 1;
		}

		// Function from file: food_mixtures.dm
		public override void on_reaction( Reagents holder = null, double? created_volume = null ) {
			dynamic location = null;

			location = GlobalFuncs.get_turf( holder.my_atom );
			new Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store_Cheesewheel( location );
			return;
		}

	}

}