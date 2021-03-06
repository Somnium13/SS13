// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Orangeburger : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Orange burger";
			this.reqs = new ByTable()
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Meat_Steak_Plain), 1 )
				.Set( typeof(Obj_Item_Toy_Crayon_Orange), 1 )
				.Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Bun), 1 )
			;
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Burger_Orange);
			this.category = "Food";
		}

	}

}