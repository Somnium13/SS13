// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Security_Armory_Trackingimp : SupplyPack_Security_Armory {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Tracking Implants Crate";
			this.cost = 20;
			this.contains = new ByTable(new object [] { typeof(Obj_Item_Weapon_Storage_Box_Trackimp) });
			this.crate_name = "tracking implant crate";
		}

	}

}