// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Flora_Ausbushes_Fernybush : Obj_Structure_Flora_Ausbushes {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "fernybush_1";
		}

		// Function from file: flora.dm
		public Obj_Structure_Flora_Ausbushes_Fernybush ( dynamic loc = null ) : base( (object)(loc) ) {
			this.icon_state = "fernybush_" + Rand13.Int( 1, 3 );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}