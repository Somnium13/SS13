// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Shovel_Spade : Obj_Item_Weapon_Shovel {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "spade";
			this.force = 5;
			this.throwforce = 7;
			this.w_class = 2;
			this.icon_state = "spade";
		}

		public Obj_Item_Weapon_Shovel_Spade ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}