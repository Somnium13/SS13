// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Spellburger2 : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Spell burger";
			this.reqs = new ByTable().Set( typeof(Obj_Item_Clothing_Head_Wizard), 1 ).Set( typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Bun), 1 );
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Burger_Spell);
			this.category = "Food";
		}

	}

}