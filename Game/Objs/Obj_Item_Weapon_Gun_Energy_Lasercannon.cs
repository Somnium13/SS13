// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Energy_Lasercannon : Obj_Item_Weapon_Gun_Energy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "laser";
			this.w_class = 4;
			this.force = 10;
			this.slot_flags = 1024;
			this.origin_tech = "combat=4;materials=3;powerstorage=3";
			this.ammo_type = new ByTable(new object [] { typeof(Obj_Item_AmmoCasing_Energy_Laser_Heavy) });
			this.ammo_x_offset = 3;
			this.icon_state = "lasercannon";
		}

		public Obj_Item_Weapon_Gun_Energy_Lasercannon ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}