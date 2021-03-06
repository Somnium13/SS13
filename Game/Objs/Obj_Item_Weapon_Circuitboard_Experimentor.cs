// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_Experimentor : Obj_Item_Weapon_Circuitboard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = typeof(Obj_Machinery_RND_Experimentor);
			this.board_type = "machine";
			this.origin_tech = "magnets=1;engineering=1;programming=1;biotech=1;bluespace=2";
			this.req_components = new ByTable().Set( typeof(Obj_Item_Weapon_StockParts_ScanningModule), 1 ).Set( typeof(Obj_Item_Weapon_StockParts_Manipulator), 2 ).Set( typeof(Obj_Item_Weapon_StockParts_MicroLaser), 2 );
		}

		public Obj_Item_Weapon_Circuitboard_Experimentor ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}