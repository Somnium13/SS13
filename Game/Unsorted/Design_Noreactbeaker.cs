// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Noreactbeaker : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cryostasis Beaker";
			this.desc = "A cryostasis beaker that allows for chemical storage without reactions. Can hold up to 50 units.";
			this.id = "splitbeaker";
			this.req_tech = new ByTable().Set( "materials", 2 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 3000 );
			this.reliability = 76;
			this.build_path = typeof(Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Noreact);
			this.category = new ByTable(new object [] { "Medical Designs" });
		}

	}

}