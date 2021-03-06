// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_MagOldsmg_ApMag : Design_MagOldsmg {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "WT-550 Auto Gun Armour Piercing Magazine (4.6×30mm AP)";
			this.desc = "A 20 round armour piercing magazine for the out of date security WT-550 Auto Rifle";
			this.id = "mag_oldsmg_ap";
			this.materials = new ByTable().Set( "$metal", 6000 ).Set( "$silver", 600 );
			this.build_path = typeof(Obj_Item_AmmoBox_Magazine_Wt550m9_Wtap);
		}

	}

}