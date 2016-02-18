// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_DeviceTools_SyndicateBomb : UplinkItem_DeviceTools {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Syndicate Bomb";
			this.desc = "The Syndicate bomb is a fearsome device capable of massive destruction. It has an adjustable timer, with a minimum of 60 seconds, and can be bolted to the floor with a wrench to prevent movement. The bomb is bulky and cannot be moved; upon ordering this item, a smaller beacon will be transported to you that will teleport the actual bomb to it upon activation. Note that this bomb can be defused, and some crew may attempt to do so.";
			this.item = typeof(Obj_Item_Device_Sbeacondrop_Bomb);
			this.cost = 11;
		}

	}

}