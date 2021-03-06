// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Cryotube : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Machine Design (Cryotube Board)";
			this.desc = "The circuit board for a cryotube.";
			this.id = "cryotube";
			this.req_tech = new ByTable().Set( "programming", 4 ).Set( "biotech", 3 ).Set( "engineering", 4 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_CryoTube);
			this.category = new ByTable(new object [] { "Medical Machinery" });
		}

	}

}