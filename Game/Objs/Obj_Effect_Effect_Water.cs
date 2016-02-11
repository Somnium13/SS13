// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Effect_Water : Obj_Effect_Effect {

		public int life = 15;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "extinguish";
		}

		// Function from file: effect_system.dm
		public Obj_Effect_Effect_Water ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Schedule( 70, (Task13.Closure)(() => {
				GlobalFuncs.qdel( this );
				return;
			}));
			return;
		}

		// Function from file: effect_system.dm
		public override dynamic Bump( Obj Obstacle = null, dynamic yes = null ) {
			
			if ( Lang13.Bool( this.reagents ) ) {
				((Reagents)this.reagents).reaction( Obstacle );
			}
			return base.Bump( Obstacle );
		}

		// Function from file: effect_system.dm
		public override bool Move( dynamic NewLoc = null, int? Dir = null, int step_x = 0, int step_y = 0 ) {
			Dir = Dir ?? 0;
			step_x = step_x ?? 0;
			step_y = step_y ?? 0;

			bool _default = false;

			
			if ( --this.life < 1 ) {
				GlobalFuncs.qdel( this );
				return false;
			}
			_default = base.Move( (object)(NewLoc), Dir, step_x, step_y );
			return _default;
		}

		// Function from file: effect_system.dm
		public override dynamic Destroy( dynamic brokenup = null ) {
			base.Destroy( (object)(brokenup) );
			return null;
		}

	}

}