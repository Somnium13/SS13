// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_DoorAssembly_DoorAssemblyMai : Obj_Structure_DoorAssembly {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.base_icon_state = "mai";
			this.base_name = "Maintenance Airlock";
			this.airlock_type = "/maintenance";
			this.glass = -1;
		}

		public Obj_Structure_DoorAssembly_DoorAssemblyMai ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}