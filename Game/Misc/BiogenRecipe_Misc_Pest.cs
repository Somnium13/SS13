// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class BiogenRecipe_Misc_Pest : BiogenRecipe_Misc {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.cost = 40;
			this.id = "pest";
			this.name = "Pest Spray";
			this.other_amounts = new ByTable(new object [] { 5 });
			this.result = typeof(Obj_Item_Weapon_Plantspray_Pests);
		}

	}

}