// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Floor_Mineral_Gold : Tile_Simulated_Floor_Mineral {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.floor_tile = typeof(Obj_Item_Stack_Tile_Mineral_Gold);
			this.icons = new ByTable(new object [] { "gold", "gold_dam" });
			this.icon_state = "gold";
		}

		public Tile_Simulated_Floor_Mineral_Gold ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}