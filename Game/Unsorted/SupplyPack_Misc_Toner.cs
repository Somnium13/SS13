// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Misc_Toner : SupplyPack_Misc {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Toner Crate";
			this.cost = 10;
			this.contains = new ByTable(new object [] { 
				typeof(Obj_Item_Device_Toner), 
				typeof(Obj_Item_Device_Toner), 
				typeof(Obj_Item_Device_Toner), 
				typeof(Obj_Item_Device_Toner), 
				typeof(Obj_Item_Device_Toner), 
				typeof(Obj_Item_Device_Toner)
			 });
			this.crate_name = "toner crate";
		}

	}

}