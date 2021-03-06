// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_DoorAssembly_DoorAssemblyEng : Obj_Structure_DoorAssembly {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.typetext = "engineering";
			this.icontext = "eng";
			this.glass_type = typeof(Obj_Machinery_Door_Airlock_GlassEngineering);
			this.airlock_type = typeof(Obj_Machinery_Door_Airlock_Engineering);
			this.anchored = 1;
			this.state = 1;
			this.icon = "icons/obj/doors/airlocks/station/engineering.dmi";
		}

		public Obj_Structure_DoorAssembly_DoorAssemblyEng ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}