// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Under_Rank_Beekeeper : Obj_Item_Clothing_Under_Rank {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "g_suit";
			this._color = "beekeeper";
			this.permeability_coefficient = 0.5;
			this.flags = 8448;
			this.icon_state = "beekeeper";
		}

		public Obj_Item_Clothing_Under_Rank_Beekeeper ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}