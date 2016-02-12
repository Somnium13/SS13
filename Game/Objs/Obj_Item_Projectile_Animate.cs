// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Animate : Obj_Item_Projectile {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage = 0;
			this.damage_type = "fire";
			this.nodamage = true;
			this.flag = "energy";
			this.icon_state = "ice_1";
		}

		public Obj_Item_Projectile_Animate ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: animate.dm
		public override dynamic Bump(Ent_Static Obstacle = null, dynamic yes = null) {
			Obj O = null;

			
			if ( Obstacle is Obj_Item || Obstacle is Obj_Structure && !GlobalFuncs.is_type_in_list( Obstacle, GlobalVars.protected_objects ) ) {
				O = (Obj)Obstacle;
				new Mob_Living_SimpleAnimal_Hostile_Mimic_Copy( O.loc, O, this.firer, null, 1200 );
			}
			base.Bump( Obstacle );
			return null;
		}

	}

}