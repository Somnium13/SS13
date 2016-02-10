// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_Blueprinter : Obj_Item_Weapon_Circuitboard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = "/obj/machinery/r_n_d/blueprinter";
			this.board_type = "machine";
			this.origin_tech = "engineering=3;programming=3";
			this.frame_desc = "Requires 2 Matter Bins, 1 Scanning Module, and 1 Manipulator.";
			this.req_components = new ByTable().Set( "/obj/item/weapon/stock_parts/matter_bin", 2 ).Set( "/obj/item/weapon/stock_parts/manipulator", 1 ).Set( "/obj/item/weapon/stock_parts/scanning_module", 1 );
		}

		public Obj_Item_Weapon_Circuitboard_Blueprinter ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}