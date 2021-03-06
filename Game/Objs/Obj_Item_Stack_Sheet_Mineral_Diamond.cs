// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Stack_Sheet_Mineral_Diamond : Obj_Item_Stack_Sheet_Mineral {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.singular_name = "diamond";
			this.origin_tech = "materials=6";
			this.sheettype = "diamond";
			this.materials = new ByTable().Set( "$diamond", 2000 );
			this.icon_state = "sheet-diamond";
		}

		// Function from file: mineral.dm
		public Obj_Item_Stack_Sheet_Mineral_Diamond ( dynamic loc = null, int? amount = null ) : base( (object)(loc), amount ) {
			this.recipes = GlobalVars.diamond_recipes;
			this.pixel_x = Rand13.Int( 0, 4 ) - 4;
			this.pixel_y = Rand13.Int( 0, 4 ) - 4;
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}