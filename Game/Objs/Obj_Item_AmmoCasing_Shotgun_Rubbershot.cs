// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoCasing_Shotgun_Rubbershot : Obj_Item_AmmoCasing_Shotgun {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.projectile_type = typeof(Obj_Item_Projectile_Bullet_Rpellet);
			this.pellets = 6;
			this.variance = 0.8;
			this.materials = new ByTable().Set( "$metal", 4000 );
			this.icon_state = "bshell";
		}

		public Obj_Item_AmmoCasing_Shotgun_Rubbershot ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}