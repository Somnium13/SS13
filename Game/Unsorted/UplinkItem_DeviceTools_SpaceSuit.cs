// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_DeviceTools_SpaceSuit : UplinkItem_DeviceTools {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Syndicate Space Suit";
			this.desc = "This red and black syndicate space suit is less encumbering than Nanotrasen variants, fits inside bags, and has a weapon slot. Nanotrasen crewmembers are trained to report red space suit sightings, however.";
			this.item = typeof(Obj_Item_Weapon_Storage_Box_SyndieKit_Space);
			this.cost = 4;
			this.exclude_modes = new ByTable(new object [] { typeof(GameMode_Gang) });
		}

	}

}