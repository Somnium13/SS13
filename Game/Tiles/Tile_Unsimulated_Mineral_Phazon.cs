// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Unsimulated_Mineral_Phazon : Tile_Unsimulated_Mineral {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.mineral = new Mineral_Phazon();
			this.scan_state = "rock_Phazon";
			this.icon_state = "rock_Phazon";
		}

		public Tile_Unsimulated_Mineral_Phazon ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}