// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Security_Laser : SupplyPack_Security {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Lasers Crate";
			this.cost = 15;
			this.contains = new ByTable(new object [] { typeof(Obj_Item_Weapon_Gun_Energy_Laser), typeof(Obj_Item_Weapon_Gun_Energy_Laser), typeof(Obj_Item_Weapon_Gun_Energy_Laser) });
			this.crate_name = "laser crate";
		}

	}

}