// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Wall_Shuttle_Smooth_Overpurple : Tile_Simulated_Wall_Shuttle_Smooth {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.fixed_underlay = new ByTable().Set( "icon", "icons/turf/floors.dmi" ).Set( "icon_state", "shuttlefloor5" );
			this.icon_state = "overpurple";
		}

		public Tile_Simulated_Wall_Shuttle_Smooth_Overpurple ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}