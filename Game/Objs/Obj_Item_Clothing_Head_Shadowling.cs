// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Shadowling : Obj_Item_Clothing_Head {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.cold_protection = 1;
			this.min_cold_protection_temperature = 2;
			this.heat_protection = 1;
			this.max_heat_protection_temperature = 1500;
			this.unacidable = true;
			this.flags = 131;
			this.icon_state = "shadowling";
		}

		public Obj_Item_Clothing_Head_Shadowling ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}