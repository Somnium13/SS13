// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Door_Airlock_Glass : Obj_Machinery_Door_Airlock {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.glass = true;
			this.penetration_dampening = 3;
			this.icon = "icons/obj/doors/Doorglass.dmi";
		}

		public Obj_Machinery_Door_Airlock_Glass ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}