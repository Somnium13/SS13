// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Paper_Crumpled : Obj_Item_Weapon_Paper {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "scrap";
		}

		public Obj_Item_Weapon_Paper_Crumpled ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: paper.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			return false;
		}

	}

}