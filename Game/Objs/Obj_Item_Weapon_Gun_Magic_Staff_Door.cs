// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Magic_Staff_Door : Obj_Item_Weapon_Gun_Magic_Staff {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.fire_sound = "sound/magic/Staff_Door.ogg";
			this.ammo_type = typeof(Obj_Item_AmmoCasing_Magic_Door);
			this.item_state = "staffofdoor";
			this.max_charges = 10;
			this.recharge_rate = 2;
			this.no_den_usage = true;
			this.icon_state = "staffofdoor";
		}

		public Obj_Item_Weapon_Gun_Magic_Staff_Door ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}