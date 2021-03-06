// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack_Sheet_Cardboard : Obj_Item_Stack_Sheet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.singular_name = "cardboard sheet";
			this.burn_state = 0;
			this.icon_state = "sheet-card";
		}

		// Function from file: sheet_types.dm
		public Obj_Item_Stack_Sheet_Cardboard ( dynamic loc = null, int? amount = null ) : base( (object)(loc), amount ) {
			this.recipes = GlobalVars.cardboard_recipes;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}