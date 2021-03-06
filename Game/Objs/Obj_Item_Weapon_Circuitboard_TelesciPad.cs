// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_TelesciPad : Obj_Item_Weapon_Circuitboard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = typeof(Obj_Machinery_Telepad);
			this.board_type = "machine";
			this.origin_tech = "programming=4;engineering=3;materials=3;bluespace=4";
			this.req_components = new ByTable()
				.Set( typeof(Obj_Item_Weapon_Ore_BluespaceCrystal), 2 )
				.Set( typeof(Obj_Item_Weapon_StockParts_Capacitor), 1 )
				.Set( typeof(Obj_Item_Stack_CableCoil), 1 )
				.Set( typeof(Obj_Item_Weapon_StockParts_ConsoleScreen), 1 )
			;
		}

		public Obj_Item_Weapon_Circuitboard_TelesciPad ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}