// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SpacevineMutation_SpaceCovering : SpacevineMutation {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "space protective";
			this.hue = "#aa77aa";
			this.quality = 1;
		}

		// Function from file: spacevine.dm
		public override void on_death( Obj_Effect_Spacevine holder = null, dynamic hitter = null, dynamic I = null ) {
			Ent_Static spaceturf = null;

			
			if ( holder.loc is Tile_Simulated_Floor_Vines ) {
				spaceturf = holder.loc;
				Task13.Schedule( 0, (Task13.Closure)(() => {
					((Tile)spaceturf).ChangeTurf( typeof(Tile_Space) );
					return;
				}));
			}
			return;
		}

		// Function from file: spacevine.dm
		public override void process_mutation( Obj_Effect_Spacevine holder = null ) {
			Ent_Static spaceturf = null;

			
			if ( holder.loc is Tile_Space ) {
				spaceturf = holder.loc;
				((Tile)spaceturf).ChangeTurf( typeof(Tile_Simulated_Floor_Vines) );
			}
			return;
		}

		// Function from file: spacevine.dm
		public override void on_grow( Obj_Effect_Spacevine holder = null ) {
			Ent_Static spaceturf = null;

			
			if ( holder.loc is Tile_Space ) {
				spaceturf = holder.loc;
				((Tile)spaceturf).ChangeTurf( typeof(Tile_Simulated_Floor_Vines) );
			}
			return;
		}

	}

}