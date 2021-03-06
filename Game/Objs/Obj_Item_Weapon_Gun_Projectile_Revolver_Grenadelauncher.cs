// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Projectile_Revolver_Grenadelauncher : Obj_Item_Weapon_Gun_Projectile_Revolver {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.mag_type = typeof(Obj_Item_AmmoBox_Magazine_Internal_Grenadelauncher);
			this.fire_sound = "sound/weapons/grenadelaunch.ogg";
			this.pin = typeof(Obj_Item_Device_FiringPin_Implant_Pindicate);
			this.icon_state = "dshotgun-sawn";
		}

		public Obj_Item_Weapon_Gun_Projectile_Revolver_Grenadelauncher ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: launchers.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			base.attackby( (object)(A), (object)(user), _params, silent, replace_spent );

			if ( A is Obj_Item_AmmoBox || A is Obj_Item_AmmoCasing ) {
				this.chamber_round();
			}
			return null;
		}

	}

}