// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class SupplyPack_Security_Securityclothes : SupplyPack_Security {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Security Clothing Crate";
			this.cost = 30;
			this.contains = new ByTable(new object [] { 
				typeof(Obj_Item_Clothing_Under_Rank_Security_Navyblue), 
				typeof(Obj_Item_Clothing_Under_Rank_Security_Navyblue), 
				typeof(Obj_Item_Clothing_Suit_Security_Officer), 
				typeof(Obj_Item_Clothing_Suit_Security_Officer), 
				typeof(Obj_Item_Clothing_Head_Beret_Sec_Navyofficer), 
				typeof(Obj_Item_Clothing_Head_Beret_Sec_Navyofficer), 
				typeof(Obj_Item_Clothing_Under_Rank_Warden_Navyblue), 
				typeof(Obj_Item_Clothing_Suit_Security_Warden), 
				typeof(Obj_Item_Clothing_Head_Beret_Sec_Navywarden), 
				typeof(Obj_Item_Clothing_Under_Rank_HeadOfSecurity_Navyblue), 
				typeof(Obj_Item_Clothing_Suit_Security_Hos), 
				typeof(Obj_Item_Clothing_Head_Beret_Sec_Navyhos)
			 });
			this.crate_name = "security clothing crate";
		}

	}

}