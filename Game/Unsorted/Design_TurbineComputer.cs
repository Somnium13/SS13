// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_TurbineComputer : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Computer Design (Power Turbine Console Board)";
			this.desc = "The circuit board for a power turbine console.";
			this.id = "power_turbine_console";
			this.req_tech = new ByTable().Set( "programming", 4 ).Set( "powerstorage", 4 ).Set( "engineering", 4 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_TurbineComputer);
			this.category = new ByTable(new object [] { "Engineering Machinery" });
		}

	}

}