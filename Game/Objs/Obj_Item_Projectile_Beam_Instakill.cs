// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Beam_Instakill : Obj_Item_Projectile_Beam {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage = 200;
			this.icon_state = "purple_laser";
		}

		public Obj_Item_Projectile_Beam_Instakill ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: beams.dm
		public override dynamic on_hit( Ent_Static target = null, double? blocked = null, dynamic hit_zone = null ) {
			dynamic _default = null;

			Ent_Static M = null;

			_default = base.on_hit( target, blocked, (object)(hit_zone) );

			if ( target is Mob_Living_Carbon ) {
				M = target;
				M.visible_message( "<span class='danger'>" + M + " explodes into a shower of gibs!</span>" );
				((dynamic)M).gib();
			}
			return _default;
		}

	}

}