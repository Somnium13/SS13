// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_LargeGrenade : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Large Grenade";
			this.desc = "A grenade that affects a larger area and use larger containers.";
			this.id = "large_Grenade";
			this.req_tech = new ByTable().Set( "combat", 3 ).Set( "materials", 2 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 3000 );
			this.reliability = 79;
			this.build_path = typeof(Obj_Item_Weapon_Grenade_ChemGrenade_Large);
			this.category = new ByTable(new object [] { "Weapons" });
		}

	}

}