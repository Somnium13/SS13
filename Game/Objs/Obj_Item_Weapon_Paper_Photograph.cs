// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Paper_Photograph : Obj_Item_Weapon_Paper {

		public bool photo_id = false;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "paper";
			this.icon_state = "photo";
		}

		public Obj_Item_Weapon_Paper_Photograph ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}