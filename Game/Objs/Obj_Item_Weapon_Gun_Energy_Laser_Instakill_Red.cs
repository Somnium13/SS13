// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Energy_Laser_Instakill_Red : Obj_Item_Weapon_Gun_Energy_Laser_Instakill {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "instagibred";
			this.ammo_type = new ByTable(new object [] { typeof(Obj_Item_AmmoCasing_Energy_Instakill_Red) });
			this.icon_state = "instagibred";
		}

		public Obj_Item_Weapon_Gun_Energy_Laser_Instakill_Red ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}