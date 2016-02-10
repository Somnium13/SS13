// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_SnackbarMachine : Obj_Item_Weapon_Circuitboard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = "/obj/machinery/chem_master/snackbar_machine";
			this.board_type = "machine";
			this.origin_tech = "engineering=3;biotech=4";
			this.frame_desc = "Requires 2 manipulator, 2 scanning modules, 2 micro-lasers, and 2 console screens.";
			this.req_components = new ByTable()
				.Set( "/obj/item/weapon/stock_parts/manipulator", 2 )
				.Set( "/obj/item/weapon/stock_parts/scanning_module", 2 )
				.Set( "/obj/item/weapon/stock_parts/micro_laser", 2 )
				.Set( "/obj/item/weapon/stock_parts/console_screen", 2 )
			;
		}

		public Obj_Item_Weapon_Circuitboard_SnackbarMachine ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}