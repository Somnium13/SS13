// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_StockParts_Cell_High_Slime : Obj_Item_Weapon_StockParts_Cell_High {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "powerstorage=2;biotech=4";
			this.materials = new ByTable();
			this.icon = "icons/mob/slimes.dmi";
			this.icon_state = "yellow slime extract";
		}

		public Obj_Item_Weapon_StockParts_Cell_High_Slime ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}