// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_DeviceTools_Potion : UplinkItem_DeviceTools {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Sentience Potion";
			this.item = typeof(Obj_Item_Slimepotion_Sentience);
			this.desc = "A potion recovered at great risk by undercover syndicate operatives. Using it will make any animal sentient, and bound to serve you.";
			this.cost = 4;
			this.include_modes = new ByTable(new object [] { typeof(GameMode_Nuclear) });
		}

	}

}