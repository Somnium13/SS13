// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Space_Transit : Tile_Space {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.baseturf = typeof(Tile_Space_Transit);
			this.icon_state = "black";
		}

		// Function from file: transit.dm
		public Tile_Space_Transit ( dynamic loc = null ) : base( (object)(loc) ) {
			this.update_icon();
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			return;
		}

		// Function from file: transit.dm
		public void update_icon(  ) {
			int p = 0;
			double angle = 0;
			int state = 0;

			p = 9;
			angle = 0;
			state = 1;

			switch ((int)( this.dir )) {
				case 1:
					angle = 180;
					state = ( -p * this.x + this.y ) % 15 + 1;

					if ( state < 1 ) {
						state += 15;
					}
					break;
				case 4:
					angle = 90;
					state = ( this.x + p * this.y ) % 15 + 1;
					break;
				case 8:
					angle = -90;
					state = ( this.x - p * this.y ) % 15 + 1;

					if ( state < 1 ) {
						state += 15;
					}
					break;
				default:
					state = ( p * this.x + this.y ) % 15 + 1;
					break;
			}
			this.icon_state = "speedspace_ns_" + state;
			this.transform = Num13.Rotate( Num13.Matrix(), angle );
			return;
		}

		// Function from file: transit.dm
		public override dynamic attackby( dynamic A = null, dynamic user = null, string _params = null, bool? silent = null, bool? replace_spent = null ) {
			return null;
		}

		// Function from file: transit.dm
		public override dynamic Entered( Ent_Dynamic Obj = null, Ent_Static oldloc = null ) {
			int max = 0;
			int min = 0;
			int ___z = 0;
			int ___x = 0;
			int ___y = 0;
			Tile T = null;

			
			if ( !( Obj != null ) ) {
				return null;
			}
			max = Game13.map_size_x - 7;
			min = 8;
			___z = Rand13.Int( 3, 7 );

			switch ((int)( this.dir )) {
				case 2:
					___x = Rand13.Int( min, max );
					___y = max;
					break;
				case 8:
					___x = max;
					___y = Rand13.Int( min, max );
					break;
				case 4:
					___x = min;
					___y = Rand13.Int( min, max );
					break;
				default:
					___x = Rand13.Int( min, max );
					___y = min;
					break;
			}
			T = Map13.GetTile( ___x, ___y, ___z );
			Obj.loc = T;
			Obj.newtonian_move( this.dir );
			return null;
		}

	}

}