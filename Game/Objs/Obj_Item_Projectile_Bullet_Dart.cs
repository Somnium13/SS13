// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Bullet_Dart : Obj_Item_Projectile_Bullet {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage = 6;
			this.icon_state = "cbbolt";
		}

		// Function from file: bullets.dm
		public Obj_Item_Projectile_Bullet_Dart ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.flags |= 16384;
			this.create_reagents( 50 );
			return;
		}

		// Function from file: bullets.dm
		public override dynamic on_hit( Ent_Static target = null, double? blocked = null, dynamic hit_zone = null ) {
			blocked = blocked ?? 0;

			Ent_Static M = null;

			
			if ( target is Mob_Living_Carbon ) {
				M = target;

				if ( blocked != 100 ) {
					
					if ( Lang13.Bool( ((dynamic)M).can_inject( null, 0, hit_zone ) ) ) {
						base.on_hit( target, blocked, (object)(hit_zone) );
						this.reagents.trans_to( M, this.reagents.total_volume );
						return 1;
					} else {
						blocked = 100;
						target.visible_message( "<span class='danger'>The " + this.name + " was deflected!</span>", "<span class='userdanger'>You were protected against the " + this.name + "!</span>" );
					}
				}
			}
			base.on_hit( target, blocked, (object)(hit_zone) );
			this.flags &= 49151;
			this.reagents.handle_reactions();
			return 1;
		}

	}

}