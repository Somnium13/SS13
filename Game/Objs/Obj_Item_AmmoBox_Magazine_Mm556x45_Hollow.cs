// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoBox_Magazine_Mm556x45_Hollow : Obj_Item_AmmoBox_Magazine_Mm556x45 {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "combat=3";
			this.ammo_type = typeof(Obj_Item_AmmoCasing_Mm556x45_Hollow);
		}

		public Obj_Item_AmmoBox_Magazine_Mm556x45_Hollow ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}