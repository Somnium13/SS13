// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_Dangerous_Smg : UplinkItem_Dangerous {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "C-20r Submachine Gun";
			this.desc = "A fully-loaded Scarborough Arms bullpup submachine gun. The C-20r fires .45 rounds with a 20-round magazine and is compatible with suppressors.";
			this.item = typeof(Obj_Item_Weapon_Gun_Projectile_Automatic_C20r);
			this.cost = 10;
			this.surplus = 40;
			this.include_modes = new ByTable(new object [] { typeof(GameMode_Nuclear) });
		}

	}

}