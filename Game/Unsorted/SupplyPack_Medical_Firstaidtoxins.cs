// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Medical_Firstaidtoxins : SupplyPack_Medical {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Toxin Treatment Kit Crate";
			this.cost = 10;
			this.contains = new ByTable(new object [] { typeof(Obj_Item_Weapon_Storage_Firstaid_Toxin), typeof(Obj_Item_Weapon_Storage_Firstaid_Toxin), typeof(Obj_Item_Weapon_Storage_Firstaid_Toxin) });
			this.crate_name = "toxin treatment kit crate";
		}

	}

}