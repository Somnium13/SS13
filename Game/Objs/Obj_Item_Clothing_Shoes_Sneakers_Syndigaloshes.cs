// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Shoes_Sneakers_Syndigaloshes : Obj_Item_Clothing_Shoes_Sneakers {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "brown";
			this.permeability_coefficient = 0.05;
			this.flags = 1024;
			this.origin_tech = "syndicate=3";
			this.can_hold_items = true;
			this.icon_state = "brown";
		}

		public Obj_Item_Clothing_Shoes_Sneakers_Syndigaloshes ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}