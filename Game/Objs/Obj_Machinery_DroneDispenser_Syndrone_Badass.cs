// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_DroneDispenser_Syndrone_Badass : Obj_Machinery_DroneDispenser_Syndrone {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.dispense_type = typeof(Obj_Item_DroneShell_Syndrone_Badass);
			this.end_create_message = "dispenses a ominous suspicious drone shell.";
		}

		public Obj_Machinery_DroneDispenser_Syndrone_Badass ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}