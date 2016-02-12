// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Laser : Obj_Effect {

		public bool damage = false;
		public int range = 10;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/projectiles.dmi";
		}

		public Obj_Effect_Laser ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: teleporter.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			this.range--;
			return false;
		}

		// Function from file: teleporter.dm
		public override dynamic Bump( Ent_Static Obstacle = null, dynamic yes = null) {
			this.range--;
			return null;
		}

	}

}