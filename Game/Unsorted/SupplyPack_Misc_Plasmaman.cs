// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Misc_Plasmaman : SupplyPack_Misc {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Plasmaman Supply Kit";
			this.cost = 20;
			this.contains = new ByTable(new object [] { 
				typeof(Obj_Item_Clothing_Under_Plasmaman), 
				typeof(Obj_Item_Clothing_Under_Plasmaman), 
				typeof(Obj_Item_Weapon_Tank_Internals_Plasmaman_Belt_Full), 
				typeof(Obj_Item_Weapon_Tank_Internals_Plasmaman_Belt_Full), 
				typeof(Obj_Item_Clothing_Head_Helmet_Space_Plasmaman), 
				typeof(Obj_Item_Clothing_Head_Helmet_Space_Plasmaman)
			 });
			this.crate_name = "plasmaman supply kit";
		}

	}

}