// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_Ammo_A40mm : UplinkItem_Ammo {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "40mm Grenade Box";
			this.desc = "A box of 4 additional 40mm HE grenades for use with the M-90gl's underbarrel grenade launcher. Your teammates will ask you to not shoot these down small hallways.";
			this.item = typeof(Obj_Item_AmmoBox_A40mm);
			this.cost = 5;
			this.include_modes = new ByTable(new object [] { typeof(GameMode_Nuclear) });
		}

	}

}