// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Shoes_Sneakers_Black : Obj_Item_Clothing_Shoes_Sneakers {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_color = "black";
			this.cold_protection = 96;
			this.min_cold_protection_temperature = 2;
			this.heat_protection = 96;
			this.max_heat_protection_temperature = 1500;
			this.icon_state = "black";
		}

		public Obj_Item_Clothing_Shoes_Sneakers_Black ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}