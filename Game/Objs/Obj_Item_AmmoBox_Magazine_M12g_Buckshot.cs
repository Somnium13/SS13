// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoBox_Magazine_M12g_Buckshot : Obj_Item_AmmoBox_Magazine_M12g {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.ammo_type = typeof(Obj_Item_AmmoCasing_Shotgun_Buckshot);
			this.icon_state = "m12gb";
		}

		public Obj_Item_AmmoBox_Magazine_M12g_Buckshot ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}