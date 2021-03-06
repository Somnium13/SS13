// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_KitchenKnife : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Kitchen knife";
			this.id = "kitchen_knife";
			this.build_type = 4;
			this.materials = new ByTable().Set( "$metal", 12000 );
			this.build_path = typeof(Obj_Item_Weapon_Kitchen_Knife);
			this.category = new ByTable(new object [] { "initial", "Misc" });
		}

	}

}