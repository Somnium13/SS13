// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Gloves_Color_Latex : Obj_Item_Clothing_Gloves_Color {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "lgloves";
			this.siemens_coefficient = 0.3;
			this.permeability_coefficient = 0.01;
			this.item_color = "white";
			this.transfer_prints = true;
			this.icon_state = "latex";
		}

		public Obj_Item_Clothing_Gloves_Color_Latex ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}