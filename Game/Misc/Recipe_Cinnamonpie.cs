// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Recipe_Cinnamonpie : Recipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.reagents = new ByTable().Set( "milk", 5 ).Set( "sugar", 10 ).Set( "flour", 10 ).Set( "cinnamon", 5 );
			this.items = new ByTable(new object [] { typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Egg) });
			this.result = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cinnamonpie);
		}

	}

}