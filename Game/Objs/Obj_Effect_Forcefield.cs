// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Forcefield : Obj_Effect {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.unacidable = true;
			this.icon = "icons/effects/effects.dmi";
			this.icon_state = "m_shield";
		}

		public Obj_Effect_Forcefield ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: forcefields.dm
		public override bool CanAtmosPass( dynamic T = null ) {
			return !this.density;
		}

	}

}