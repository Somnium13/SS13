// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Meteor_Radioactive : Obj_Effect_Meteor {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "medium_radioactive";
		}

		public Obj_Effect_Meteor_Radioactive ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: meteors.dm
		public override dynamic Bump(Ent_Static Obstacle = null, dynamic yes = null) {
			Mob_Living M = null;

			
			foreach (dynamic _a in Lang13.Enumerate( Map13.FetchViewers( null, this ), typeof(Mob_Living) )) {
				M = _a;
				
				M.radiation += Rand13.Int( 5, 10 );
			}
			base.Bump( Obstacle );
			return null;
		}

	}

}