// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_WormholeProjector : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Bluespace Wormhole Projector";
			this.desc = "A projector that emits high density quantum-coupled bluespace beams.";
			this.id = "wormholeprojector";
			this.req_tech = new ByTable().Set( "combat", 6 ).Set( "materials", 6 ).Set( "bluespace", 4 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$silver", 1000 ).Set( "$metal", 5000 ).Set( "$diamond", 3000 );
			this.build_path = typeof(Obj_Item_Weapon_Gun_Energy_WormholeProjector);
			this.category = new ByTable(new object [] { "Weapons" });
		}

	}

}