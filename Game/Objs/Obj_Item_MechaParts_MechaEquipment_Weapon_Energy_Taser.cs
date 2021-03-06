// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_MechaParts_MechaEquipment_Weapon_Energy_Taser : Obj_Item_MechaParts_MechaEquipment_Weapon_Energy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.energy_drain = 20;
			this.equip_cooldown = 8;
			this.projectile = typeof(Obj_Item_Projectile_Energy_Electrode);
			this.fire_sound = "sound/weapons/taser.ogg";
			this.icon_state = "mecha_taser";
		}

		public Obj_Item_MechaParts_MechaEquipment_Weapon_Energy_Taser ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}