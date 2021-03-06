// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Drill : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Mining Drill";
			this.desc = "Yours is the drill that will pierce through the rock walls.";
			this.id = "drill";
			this.req_tech = new ByTable().Set( "materials", 2 ).Set( "powerstorage", 3 ).Set( "engineering", 2 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$metal", 6000 ).Set( "$glass", 1000 );
			this.build_path = typeof(Obj_Item_Weapon_Pickaxe_Drill);
			this.category = new ByTable(new object [] { "Mining Designs" });
		}

	}

}