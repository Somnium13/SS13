// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_SpellProjectile_Seeking_MagicMissile : Obj_Item_Projectile_SpellProjectile_Seeking {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.linear_movement = false;
			this.proj_trail = true;
			this.proj_trail_lifespan = 5;
			this.proj_trail_icon_state = "magicmd";
			this.icon_state = "magicm";
		}

		public Obj_Item_Projectile_SpellProjectile_Seeking_MagicMissile ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}