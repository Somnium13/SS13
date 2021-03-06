// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Pacman : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Machine Design (PACMAN-type Generator Board)";
			this.desc = "The circuit board that for a PACMAN-type portable generator.";
			this.id = "pacman";
			this.req_tech = new ByTable().Set( "programming", 3 ).Set( "plasmatech", 3 ).Set( "powerstorage", 3 ).Set( "engineering", 3 );
			this.build_type = 1;
			this.reliability = 79;
			this.materials = new ByTable().Set( "$glass", 1000 ).Set( "sacid", 20 );
			this.build_path = typeof(Obj_Item_Weapon_Circuitboard_Pacman);
			this.category = new ByTable(new object [] { "Engineering Machinery" });
		}

	}

}