// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Sashimi : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Sashimi";
			this.reqs = new ByTable()
				.Set( typeof(Reagent_Consumable_Soysauce), 5 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Spidereggs), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Carpmeat), 1 )
			;
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Sashimi);
			this.category = "Food";
		}

	}

}