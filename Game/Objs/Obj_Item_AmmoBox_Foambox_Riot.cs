// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoBox_Foambox_Riot : Obj_Item_AmmoBox_Foambox {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.ammo_type = typeof(Obj_Item_AmmoCasing_Caseless_FoamDart_Riot);
			this.icon_state = "foambox_riot";
		}

		public Obj_Item_AmmoBox_Foambox_Riot ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}