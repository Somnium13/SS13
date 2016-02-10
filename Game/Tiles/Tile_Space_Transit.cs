// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Space_Transit : Tile_Space {

		public int pushdirection = 0;

		// Function from file: transit.dm
		public Tile_Space_Transit ( dynamic loc = null ) : base( (object)(loc) ) {
			Ent_Static A = null;
			string dira = null;
			double i = 0;

			
			if ( this.loc != null ) {
				A = this.loc;
				((dynamic)A).area_turfs += this;
			}
			dira = "";
			i = 0;

			switch ((int)( this.pushdirection )) {
				case 2:
					dira = "ns";
					i = Math.Abs( ( this.x ^ 2 ) - this.y ) % 15 + 1;
					break;
				case 8:
					dira = "ew";
					i = ( ( this.y ^ 2 ) + this.x ) % 15 + 1;
					break;
				default:
					this.icon_state = "black";
					break;
			}

			if ( this.icon_state != "black" ) {
				this.icon_state = "speedspace_" + dira + "_" + i;
			}
			return;
		}

		// Function from file: transit.dm
		public override int canBuildPlating( Obj_Item_Stack_Tile_Wood material = null ) {
			return -1;
		}

		// Function from file: transit.dm
		public override bool canBuildLattice( Obj_Item_Stack material = null ) {
			return false;
		}

		// Function from file: transit.dm
		public override dynamic canBuildCatwalk(  ) {
			return 0;
		}

		// Function from file: transit.dm
		public override dynamic attackby( dynamic a = null, dynamic b = null, dynamic c = null ) {
			return null;
		}

		// Function from file: transit.dm
		public override dynamic ChangeTurf( dynamic N = null, bool? tell_universe = null, bool? force_lighting_update = null, bool? allow = null ) {
			tell_universe = tell_universe ?? true;
			force_lighting_update = force_lighting_update ?? false;
			allow = allow ?? false;

			return base.ChangeTurf( (object)(N), tell_universe, true, allow );
		}

	}

}