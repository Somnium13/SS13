// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TheftObjective_Traitor_Magboots : TheftObjective_Traitor {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "a pair of advanced magboots";
			this.typepath = typeof(Obj_Item_Clothing_Shoes_Magboots_Elite);
			this.protected_jobs = new ByTable(new object [] { "Chief Engineer" });
		}

	}

}