// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Ioncarbine : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Ion Carbine";
			this.desc = "How to dismantle a cyborg : The gun.";
			this.id = "ioncarbine";
			this.req_tech = new ByTable().Set( "combat", 5 ).Set( "materials", 4 ).Set( "magnets", 4 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$silver", 4000 ).Set( "$metal", 6000 ).Set( "$uranium", 1000 );
			this.build_path = typeof(Obj_Item_Weapon_Gun_Energy_Ionrifle_Carbine);
			this.category = new ByTable(new object [] { "Weapons" });
		}

	}

}