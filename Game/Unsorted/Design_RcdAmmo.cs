// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_RcdAmmo : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Compressed matter cardridge";
			this.id = "rcd_ammo";
			this.build_type = 4;
			this.materials = new ByTable().Set( "$metal", 3000 ).Set( "$glass", 2000 );
			this.build_path = typeof(Obj_Item_Weapon_RcdAmmo);
			this.category = new ByTable(new object [] { "initial", "Construction" });
		}

	}

}