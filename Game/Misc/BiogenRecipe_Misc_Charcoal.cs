// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class BiogenRecipe_Misc_Charcoal : BiogenRecipe_Misc {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.cost = 100;
			this.id = "charcoal";
			this.name = "Charcoal Sheet";
			this.other_amounts = new ByTable(new object [] { 5, 10 });
			this.result = typeof(Obj_Item_Stack_Sheet_Charcoal);
		}

	}

}