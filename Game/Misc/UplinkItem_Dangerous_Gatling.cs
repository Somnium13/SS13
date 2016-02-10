// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_Dangerous_Gatling : UplinkItem_Dangerous {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Gatling Gun";
			this.desc = "A huge minigun. Makes up for its lack of mobility and discretion with sheer firepower. Has 200 bullets.";
			this.item = typeof(Obj_Item_Weapon_Gun_Gatling);
			this.cost = 20;
			this.gamemodes = new ByTable(new object [] { "nuclear emergency" });
		}

	}

}