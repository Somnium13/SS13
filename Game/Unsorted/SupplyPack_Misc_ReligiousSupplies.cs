// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Misc_ReligiousSupplies : SupplyPack_Misc {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Religious Supplies Crate";
			this.cost = 40;
			this.contains = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Holywater), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Holywater), 
				typeof(Obj_Item_Weapon_Storage_Book_Bible_Booze), 
				typeof(Obj_Item_Weapon_Storage_Book_Bible_Booze), 
				typeof(Obj_Item_Clothing_Suit_Hooded_ChaplainHoodie), 
				typeof(Obj_Item_Clothing_Suit_Hooded_ChaplainHoodie)
			 });
			this.crate_name = "religious supplies crate";
		}

	}

}