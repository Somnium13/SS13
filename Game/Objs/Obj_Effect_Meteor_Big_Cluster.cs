// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Meteor_Big_Cluster : Obj_Effect_Meteor_Big {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "big_cluster";
		}

		public Obj_Effect_Meteor_Big_Cluster ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: meteors.dm
		public override dynamic Bump(Ent_Static Obstacle = null, dynamic yes = null) {
			int failcount = 0;
			int? i = null;
			Obj_Effect_Meteor M = null;
			int c_endy = 0;
			int c_endx = 0;
			Tile c_pickedgoal = null;

			GlobalFuncs.explosion( GlobalFuncs.get_turf( Obstacle ), 1, 0, 0, 0, 0, true, false );
			failcount = 0;
			i = null;
			i = 0;

			while (( i ??0) < 3) {
				
				if ( failcount >= 5 ) {
					break;
				}
				M = new Obj_Effect_Meteor( GlobalFuncs.get_turf( this ) );
				c_endy = Rand13.Int( 7, Game13.map_size_y - 7 );
				c_endx = Rand13.Int( 7, Game13.map_size_x - 7 );
				c_pickedgoal = Map13.GetTile( c_endx, c_endy, 1 );

				if ( !( c_pickedgoal != null ) ) {
					GlobalFuncs.qdel( M );
					i--;
					failcount++;
				}
				Map13.WalkTowardsSimple( M, c_pickedgoal, 1 );
				i++;
			}
			GlobalFuncs.qdel( this );
			return null;
		}

	}

}