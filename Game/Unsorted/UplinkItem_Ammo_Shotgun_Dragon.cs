// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_Ammo_Shotgun_Dragon : UplinkItem_Ammo_Shotgun {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "12g Dragon's Breath Drum";
			this.desc = "An alternative 8-round dragon's breath magazine for use in the Bulldog shotgun. 'I'm a fire starter, twisted fire starter!'";
			this.item = typeof(Obj_Item_AmmoBox_Magazine_M12g_Dragon);
			this.include_modes = new ByTable(new object [] { typeof(GameMode_Nuclear) });
		}

	}

}