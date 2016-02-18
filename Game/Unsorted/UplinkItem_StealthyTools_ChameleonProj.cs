// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class UplinkItem_StealthyTools_ChameleonProj : UplinkItem_StealthyTools {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Chameleon Projector";
			this.desc = "Projects an image across a user, disguising them as an object scanned with it, as long as they don't move the projector from their hand. Disguised users move slowly, and projectiles pass over them.";
			this.item = typeof(Obj_Item_Device_Chameleon);
			this.cost = 7;
			this.exclude_modes = new ByTable(new object [] { typeof(GameMode_Gang) });
		}

	}

}