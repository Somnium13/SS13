// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TheftObjective_Number_Special_Gold : TheftObjective_Number_Special {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "gold bars";
			this.typepath = typeof(Obj_Item_Stack_Sheet_Mineral_Gold);
			this.min = 10;
			this.max = 50;
			this.step = 10;
		}

	}

}