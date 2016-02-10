// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPacks_HydroponicsTrays : SupplyPacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Hydroponic Trays Components Crate";
			this.contains = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Circuitboard_Hydroponics), 
				typeof(Obj_Item_Weapon_StockParts_MatterBin), 
				typeof(Obj_Item_Weapon_StockParts_MatterBin), 
				typeof(Obj_Item_Weapon_StockParts_ScanningModule), 
				typeof(Obj_Item_Weapon_StockParts_Capacitor), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Beaker), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Beaker), 
				typeof(Obj_Item_Weapon_StockParts_ConsoleScreen), 
				typeof(Obj_Item_Weapon_Circuitboard_Hydroponics), 
				typeof(Obj_Item_Weapon_StockParts_MatterBin), 
				typeof(Obj_Item_Weapon_StockParts_MatterBin), 
				typeof(Obj_Item_Weapon_StockParts_ScanningModule), 
				typeof(Obj_Item_Weapon_StockParts_Capacitor), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Beaker), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Beaker), 
				typeof(Obj_Item_Weapon_StockParts_ConsoleScreen)
			 });
			this.cost = 12;
			this.containertype = typeof(Obj_Structure_Closet_Crate_Secure_Hydrosec);
			this.containername = "Hydroponic Trays Components Crate";
			this.access = 35;
			this.group = "Hydroponics";
		}

	}

}