// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Floor_Plating_Lava_Smooth : Tile_Simulated_Floor_Plating_Lava {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.baseturf = typeof(Tile_Simulated_Floor_Plating_Lava_Smooth);
			this.smooth = 1;
			this.canSmoothWith = new ByTable(new object [] { typeof(Tile_Simulated_Wall), typeof(Tile_Simulated_Mineral), typeof(Tile_Simulated_Floor_Plating_Lava_Smooth) });
			this.icon = "icons/turf/floors/lava.dmi";
			this.icon_state = "smooth";
		}

		public Tile_Simulated_Floor_Plating_Lava_Smooth ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}