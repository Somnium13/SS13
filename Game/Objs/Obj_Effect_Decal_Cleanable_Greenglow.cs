// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Decal_Cleanable_Greenglow : Obj_Effect_Decal_Cleanable {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.luminosity = 1;
			this.icon_state = "greenglow";
		}

		public Obj_Effect_Decal_Cleanable_Greenglow ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: misc.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			return false;
		}

	}

}