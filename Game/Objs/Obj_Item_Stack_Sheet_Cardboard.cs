// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack_Sheet_Cardboard : Obj_Item_Stack_Sheet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.singular_name = "cardboard sheet";
			this.starting_materials = new ByTable().Set( "$cardboard", 3750 );
			this.w_type = 1;
			this.icon_state = "sheet-card";
		}

		// Function from file: sheet_types.dm
		public Obj_Item_Stack_Sheet_Cardboard ( dynamic loc = null, int? amount = null ) : base( (object)(loc), amount ) {
			this.recipes = GlobalVars.cardboard_recipes;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: sheet_types.dm
		public override int recycle( Game_Data rec = null ) {
			((dynamic)rec).addAmount( "$cardboard", this.amount );
			return 1;
		}

	}

}