// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Recipe_Beetsoup : Recipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.reagents = new ByTable().Set( "water", 10 );
			this.items = new ByTable(new object [] { typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Whitebeet), typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Cabbage) });
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Beetsoup);
		}

	}

}