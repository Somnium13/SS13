// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Plasmacutter : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Plasma Cutter";
			this.desc = "You could use it to cut limbs off of xenos! Or, you know, mine stuff.";
			this.id = "plasmacutter";
			this.req_tech = new ByTable().Set( "materials", 4 ).Set( "plasmatech", 3 ).Set( "engineering", 3 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$iron", 1500 ).Set( "$glass", 500 ).Set( "$gold", 500 ).Set( "$plasma", 500 );
			this.reliability_base = 79;
			this.category = "Mining";
			this.build_path = typeof(Obj_Item_Weapon_Pickaxe_Plasmacutter);
		}

	}

}