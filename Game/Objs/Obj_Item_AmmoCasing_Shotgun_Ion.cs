// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoCasing_Shotgun_Ion : Obj_Item_AmmoCasing_Shotgun {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.projectile_type = typeof(Obj_Item_Projectile_Ion_Weak);
			this.pellets = 4;
			this.variance = 081;
			this.icon_state = "ionshell";
		}

		public Obj_Item_AmmoCasing_Shotgun_Ion ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}