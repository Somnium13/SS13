// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_Implants_Microbomb : UplinkItem_Implants {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Microbomb Implant";
			this.desc = "An implant injected into the body, and later activated either manually or automatically upon death. The more implants inside of you, the higher the explosive power. This will permanently destroy your body, however.";
			this.item = typeof(Obj_Item_Weapon_Storage_Box_SyndieKit_ImpMicrobomb);
			this.cost = 2;
			this.include_modes = new ByTable(new object [] { typeof(GameMode_Nuclear) });
		}

	}

}