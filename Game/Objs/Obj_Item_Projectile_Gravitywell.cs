// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Projectile_Gravitywell : Obj_Item_Projectile {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.damage = 0;
			this.nodamage = true;
			this.phase_type = 31;
			this.penetration = -1;
			this.icon = "icons/obj/projectiles_experimental.dmi";
			this.icon_state = "gravitywell";
		}

		public Obj_Item_Projectile_Gravitywell ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: gravitywell.dm
		public override double singularity_act( double? current_size = null, Obj_Machinery_Singularity S = null ) {
			this.loc = S.loc;
			this.spawnGravityWell();
			return 0;
		}

		// Function from file: gravitywell.dm
		public override dynamic cultify(  ) {
			return null;
		}

		// Function from file: gravitywell.dm
		public override bool bump_original_check(  ) {
			
			if ( !this.bumped ) {
				
				if ( this.loc == GlobalFuncs.get_turf( this.original ) ) {
					
					if ( !this.permutated.Contains( this.original ) ) {
						this.Bump( this.original );
					}
				}
			}
			return false;
		}

		// Function from file: gravitywell.dm
		public void spawnGravityWell(  ) {
			this.kill_count = 0;
			GlobalFuncs.log_admin( "[" + GlobalFuncs.time_stamp() + "] <b>" + GlobalFuncs.key_name( this.firer ) + "</b> has created a gravity well at (" + this.loc.x + "," + this.loc.y + "," + this.loc.z + ")" );
			GlobalFuncs.message_admins( "[" + GlobalFuncs.time_stamp() + "] <b>" + GlobalFuncs.key_name( this.firer ) + "</b> has created a gravity well at (<A HREF='?_src_=holder;adminplayerobservecoodjump=1;X=" + this.loc.x + ";Y=" + this.loc.y + ";Z=" + this.loc.z + "'>(" + this.loc.x + "," + this.loc.y + "," + this.loc.z + ")</a>)" );
			new Obj_Effect_Overlay_Gravitywell( this.loc );
			this.bullet_die();
			return;
		}

		// Function from file: gravitywell.dm
		public override dynamic Bump(Ent_Static Obstacle = null, dynamic yes = null) {
			Mob_Living M = null;

			
			if ( this.loc == this.target ) {
				this.spawnGravityWell();
			}

			if ( Obstacle is Mob_Living ) {
				M = (Mob_Living)Obstacle;
				((dynamic)M).Weaken( 5 );
			}
			this.forceMove( Map13.GetStep( this.loc, this.dir ) );

			if ( this.loc == this.target ) {
				this.spawnGravityWell();
			}
			return null;
		}

		// Function from file: gravitywell.dm
		public override dynamic bresenham_step( double distA = 0, double distB = 0, double? dA = null, double? dB = null, Ent_Static lastposition = null, double? target_dir = null, dynamic reference = null ) {
			
			if ( Lang13.Bool( base.bresenham_step( distA, distB, dA, dB, lastposition, target_dir, (object)(reference) ) ) ) {
				return 2;
			} else {
				return 0;
			}
		}

	}

}