// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Circuitboard_Telecomms_Processor : Obj_Item_Weapon_Circuitboard_Telecomms {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.build_path = "/obj/machinery/telecomms/processor";
			this.board_type = "machine";
			this.origin_tech = "programming=4;engineering=4";
			this.frame_desc = "Requires 3 Manipulators, 1 Hyperwave Filter, 2 Treatment Disks, 1 Wavelength Analyzer, 2 Cable Coils and 1 Subspace Amplifier.";
			this.req_components = new ByTable()
				.Set( "/obj/item/weapon/stock_parts/manipulator", 3 )
				.Set( "/obj/item/weapon/stock_parts/subspace/filter", 1 )
				.Set( "/obj/item/weapon/stock_parts/subspace/treatment", 2 )
				.Set( "/obj/item/weapon/stock_parts/subspace/analyzer", 1 )
				.Set( "/obj/item/stack/cable_coil", 2 )
				.Set( "/obj/item/weapon/stock_parts/subspace/amplifier", 1 )
			;
		}

		public Obj_Item_Weapon_Circuitboard_Telecomms_Processor ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}