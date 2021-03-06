// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Glasses_Thermal : Obj_Item_Clothing_Glasses {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "glasses";
			this.origin_tech = "magnets=3";
			this.vision_flags = 4;
			this.invis_view = 2;
			this.icon_state = "thermal";
		}

		public Obj_Item_Clothing_Glasses_Thermal ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: glasses.dm
		public override double emp_act( int severity = 0 ) {
			this.thermal_overload();
			base.emp_act( severity );
			return 0;
		}

	}

}