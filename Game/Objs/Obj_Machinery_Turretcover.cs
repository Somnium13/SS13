// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Turretcover : Obj_Machinery {

		public Obj_Machinery_Turret host = null;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/turrets.dmi";
			this.icon_state = "turretCover";
			this.layer = 3.5;
		}

		public Obj_Machinery_Turretcover ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}