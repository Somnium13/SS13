// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Energy_Gun_Turret : Obj_Item_Weapon_Gun_Energy_Gun {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "turretlaser";
			this.w_class = 5;
			this.ammo_type = new ByTable(new object [] { typeof(Obj_Item_AmmoCasing_Energy_Electrode), typeof(Obj_Item_AmmoCasing_Energy_Laser) });
			this.heavy_weapon = true;
			this.trigger_guard = false;
			this.icon_state = "turretlaser";
		}

		public Obj_Item_Weapon_Gun_Energy_Gun_Turret ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}