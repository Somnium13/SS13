// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Flora_Ausbushes_Stalkybush : Obj_Structure_Flora_Ausbushes {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "stalkybush_1";
		}

		// Function from file: flora.dm
		public Obj_Structure_Flora_Ausbushes_Stalkybush ( dynamic loc = null ) : base( (object)(loc) ) {
			this.icon_state = "stalkybush_" + Rand13.Int( 1, 3 );
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

	}

}