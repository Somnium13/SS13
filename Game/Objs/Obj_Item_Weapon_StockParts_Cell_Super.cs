// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_StockParts_Cell_Super : Obj_Item_Weapon_StockParts_Cell {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "powerstorage=5";
			this.maxcharge = 20000;
			this.materials = new ByTable().Set( "$glass", 70 );
			this.rating = 4;
			this.chargerate = 2000;
			this.icon_state = "scell";
		}

		public Obj_Item_Weapon_StockParts_Cell_Super ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}