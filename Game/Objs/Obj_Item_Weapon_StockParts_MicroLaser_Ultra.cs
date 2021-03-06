// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_StockParts_MicroLaser_Ultra : Obj_Item_Weapon_StockParts_MicroLaser {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "magnets=5";
			this.rating = 3;
			this.materials = new ByTable().Set( "$metal", 10 ).Set( "$glass", 20 );
			this.icon_state = "ultra_high_micro_laser";
		}

		public Obj_Item_Weapon_StockParts_MicroLaser_Ultra ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}