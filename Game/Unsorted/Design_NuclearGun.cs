// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_NuclearGun : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Advanced Energy Gun";
			this.desc = "An energy gun with an experimental miniaturized reactor.";
			this.id = "nuclear_gun";
			this.req_tech = new ByTable().Set( "combat", 4 ).Set( "materials", 5 ).Set( "powerstorage", 3 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 5000 ).Set( "$glass", 1000 ).Set( "$uranium", 2000 );
			this.reliability = 76;
			this.build_path = typeof(Obj_Item_Weapon_Gun_Energy_Gun_Nuclear);
			this.category = new ByTable(new object [] { "Weapons" });
		}

	}

}