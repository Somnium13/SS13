// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Beam_Scatter : Obj_Item_Projectile_Beam {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage = 5;
			this.icon_state = "scatterlaser";
		}

		public Obj_Item_Projectile_Beam_Scatter ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}