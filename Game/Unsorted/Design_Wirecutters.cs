// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Wirecutters : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Wirecutters";
			this.id = "wirecutters";
			this.build_type = 4;
			this.materials = new ByTable().Set( "$metal", 80 );
			this.build_path = typeof(Obj_Item_Weapon_Wirecutters);
			this.category = new ByTable(new object [] { "initial", "Tools" });
		}

	}

}