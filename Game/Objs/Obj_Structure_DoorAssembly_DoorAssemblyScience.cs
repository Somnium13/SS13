// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_DoorAssembly_DoorAssemblyScience : Obj_Structure_DoorAssembly {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.base_icon_state = "sci";
			this.base_name = "Science Airlock";
			this.glass_type = "/glass_science";
			this.airlock_type = "/science";
		}

		public Obj_Structure_DoorAssembly_DoorAssemblyScience ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}