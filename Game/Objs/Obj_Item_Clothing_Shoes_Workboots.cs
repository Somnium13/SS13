// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Shoes_Workboots : Obj_Item_Clothing_Shoes {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "jackboots";
			this.put_on_delay = 40;
			this.can_hold_items = true;
			this.icon_state = "workboots";
		}

		public Obj_Item_Clothing_Shoes_Workboots ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}