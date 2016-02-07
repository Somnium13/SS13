// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_AcceleratedParticle : Obj_Effect {

		public int movement_range = 10;
		public int energy = 10;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.anchored = 1;
			this.icon = "icons/obj/machines/particle_accelerator.dmi";
			this.icon_state = "particle";
		}

		// Function from file: particle.dm
		public Obj_Effect_AcceleratedParticle ( dynamic loc = null, int? dir = null ) : base( (object)(loc) ) {
			dir = dir ?? 2;

			this.loc = loc;
			this.dir = dir ??0;

			if ( this.movement_range > 20 ) {
				this.movement_range = 20;
			}
			Task13.Schedule( 0, (Task13.Closure)(() => {
				this.move( 1 );
				return;
			}));
			return;
		}

		// Function from file: particle.dm
		public void move( int lag = 0 ) {
			
			if ( this.loc == null ) {
				return;
			}
			Map13.Step( this, this.dir );

			if ( !( this.loc == null ) ) {
				this.loc = Map13.GetStep( this, this.dir );
			}
			this.movement_range--;

			if ( this.movement_range <= 0 ) {
				this.loc = null;
			} else {
				Task13.Sleep( lag );
				this.move( lag );
			}
			return;
		}

		// Function from file: particle.dm
		public void toxmob( Ent_Static M = null ) {
			M.rad_act( this.energy * 6 );
			((Mob_Living)M).updatehealth();
			return;
		}

		// Function from file: particle.dm
		public override bool ex_act( double? severity = null, dynamic target = null ) {
			this.loc = null;
			return false;
		}

		// Function from file: particle.dm
		public override bool Bumped( dynamic AM = null ) {
			
			if ( AM is Mob ) {
				this.Bump( AM );
			}
			return false;
		}

		// Function from file: particle.dm
		public override dynamic Bump( Ent_Dynamic A = null, dynamic yes = null ) {
			
			if ( A != null ) {
				
				if ( A is Mob ) {
					this.toxmob( A );
				}

				if ( A is Obj_Machinery_TheSingularitygen || A is Obj_Singularity ) {
					((dynamic)A).energy += this.energy;
				}
			}
			return null;
		}

	}

}