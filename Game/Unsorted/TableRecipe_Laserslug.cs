// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class TableRecipe_Laserslug : TableRecipe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Laser Slug Shell";
			this.result = typeof(Obj_Item_AmmoCasing_Shotgun_Laserslug);
			this.reqs = new ByTable().Set( typeof(Obj_Item_AmmoCasing_Shotgun_Techshell), 1 ).Set( typeof(Obj_Item_Weapon_StockParts_Capacitor_Adv), 1 ).Set( typeof(Obj_Item_Weapon_StockParts_MicroLaser_High), 1 );
			this.tools = new ByTable(new object [] { typeof(Obj_Item_Weapon_Screwdriver) });
			this.time = 5;
			this.category = "Ammunition";
		}

	}

}