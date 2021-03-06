// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Oatmeal : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Oatmeal";
			this.reqs = new ByTable().Set( typeof(Reagent_Consumable_Milk), 10 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bowl), 1 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Oat), 1 );
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Salad_Oatmeal);
			this.category = "Food";
		}

	}

}