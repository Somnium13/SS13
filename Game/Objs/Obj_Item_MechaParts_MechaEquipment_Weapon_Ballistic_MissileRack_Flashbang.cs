// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic_MissileRack_Flashbang : Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic_MissileRack {

		public int det_time = 20;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.projectile = typeof(Obj_Item_Weapon_Grenade_Flashbang);
			this.fire_sound = "sound/weapons/grenadelauncher.ogg";
			this.projectiles = 6;
			this.missile_speed = 1.5;
			this.projectile_energy_cost = 800;
			this.icon_state = "mecha_grenadelnchr";
		}

		public Obj_Item_MechaParts_MechaEquipment_Weapon_Ballistic_MissileRack_Flashbang ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: weapons.dm
		public override bool action( dynamic target = null ) {
			dynamic F = null;

			
			if ( !this.action_checks( target ) ) {
				return false;
			}
			this.set_ready_state( false );
			F = Lang13.Call( this.projectile, this.chassis.loc );
			GlobalFuncs.playsound( this.chassis, this.fire_sound, 50, 1 );
			((Ent_Dynamic)F).throw_at( target, this.missile_range, this.missile_speed );
			this.projectiles--;
			this.log_message( "Fired from " + this.name + ", targeting " + target + "." );
			Task13.Schedule( this.det_time, (Task13.Closure)(() => {
				((Obj_Item_Weapon_Grenade)F).prime();
				return;
			}));
			this.do_after_cooldown();
			return false;
		}

	}

}