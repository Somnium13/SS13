// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Nun : Obj_Item_Clothing_Suit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "nun";
			this.body_parts_covered = 1950;
			this.flags_inv = 12;
			this.v_allowed = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Storage_Book_Bible), 
				typeof(Obj_Item_Weapon_Nullrod), 
				typeof(Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Holywater), 
				typeof(Obj_Item_Weapon_Storage_Fancy_CandleBox), 
				typeof(Obj_Item_Candle), 
				typeof(Obj_Item_Weapon_Tank_Internals_EmergencyOxygen)
			 });
			this.icon_state = "nun";
		}

		public Obj_Item_Clothing_Suit_Nun ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}