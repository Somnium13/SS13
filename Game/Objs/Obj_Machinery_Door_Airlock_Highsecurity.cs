// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Door_Airlock_Highsecurity : Obj_Machinery_Door_Airlock {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.overlays_file = "icons/obj/doors/airlocks/highsec/overlays.dmi";
			this.doortype = typeof(Obj_Structure_DoorAssembly_DoorAssemblyHighsecurity);
			this.explosion_block = 2;
			this.icon = "icons/obj/doors/airlocks/highsec/highsec.dmi";
		}

		public Obj_Machinery_Door_Airlock_Highsecurity ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}