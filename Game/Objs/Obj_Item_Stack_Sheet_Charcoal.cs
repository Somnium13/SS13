// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack_Sheet_Charcoal : Obj_Item_Stack_Sheet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.singular_name = "charcoal sheet";
			this.autoignition_temperature = 573.1500244140625;
			this.icon_state = "sheet-charcoal";
		}

		// Function from file: sheet_types.dm
		public Obj_Item_Stack_Sheet_Charcoal ( dynamic loc = null, int? amount = null ) : base( (object)(loc), amount ) {
			this.recipes = GlobalVars.charcoal_recipes;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}