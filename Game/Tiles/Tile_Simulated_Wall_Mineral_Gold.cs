// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Tile_Simulated_Wall_Mineral_Gold : Tile_Simulated_Wall_Mineral {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.walltype = "gold";
			this.mineral = "gold";
			this.sheet_type = typeof(Obj_Item_Stack_Sheet_Mineral_Gold);
			this.canSmoothWith = new ByTable(new object [] { typeof(Tile_Simulated_Wall_Mineral_Gold), typeof(Obj_Structure_Falsewall_Gold) });
			this.icon = "icons/turf/walls/gold_wall.dmi";
			this.icon_state = "gold";
		}

		public Tile_Simulated_Wall_Mineral_Gold ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}