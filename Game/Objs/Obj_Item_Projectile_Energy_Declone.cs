// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Energy_Declone : Obj_Item_Projectile_Energy {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage = 12;
			this.damage_type = "clone";
			this.irradiate = 40;
			this.icon_state = "declone";
		}

		public Obj_Item_Projectile_Energy_Declone ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}