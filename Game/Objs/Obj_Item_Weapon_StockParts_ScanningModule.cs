// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_StockParts_ScanningModule : Obj_Item_Weapon_StockParts {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "magnets=1";
			this.materials = new ByTable().Set( "$metal", 50 ).Set( "$glass", 20 );
			this.icon_state = "scan_module";
		}

		public Obj_Item_Weapon_StockParts_ScanningModule ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}