// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Gladiator : Obj_Item_Clothing_Head_Helmet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.flags = 32768;
			this.item_state = "gladiator";
			this.flags_inv = 7;
			this.icon_state = "gladiator";
		}

		public Obj_Item_Clothing_Head_Helmet_Gladiator ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}