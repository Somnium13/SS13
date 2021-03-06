// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Hotdog : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Hot dog";
			this.reqs = new ByTable().Set( typeof(Reagent_Consumable_Ketchup), 5 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Bun), 1 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Sausage), 1 );
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Hotdog);
			this.category = "Food";
		}

	}

}