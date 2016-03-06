// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Bullet_Mime : Obj_Item_Projectile_Bullet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage = 20;
		}

		public Obj_Item_Projectile_Bullet_Mime ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: bullets.dm
		public override dynamic on_hit( Ent_Static target = null, double? blocked = null, dynamic hit_zone = null ) {
			blocked = blocked ?? 0;

			dynamic _default = null;

			Ent_Static M = null;

			_default = base.on_hit( target, blocked, (object)(hit_zone) );

			if ( target is Mob_Living_Carbon ) {
				M = target;
				((dynamic)M).silent = Num13.MaxInt( Convert.ToInt32( ((dynamic)M).silent ), 10 );
			}
			return _default;
		}

	}

}