// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Braincake : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Brain cake";
			this.reqs = new ByTable().Set( typeof(Obj_Item_Organ_Internal_Brain), 1 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store_Cake_Plain), 1 );
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store_Cake_Brain);
			this.category = "Food";
		}

	}

}