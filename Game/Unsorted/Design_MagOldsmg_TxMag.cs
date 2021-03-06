// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_MagOldsmg_TxMag : Design_MagOldsmg {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "WT-550 Auto Gun Urnaium Magazine (4.6×30mm TX)";
			this.desc = "A 20 round urnaium tipped magazine for the out of date security WT-550 Auto Rifle";
			this.id = "mag_oldsmg_tx";
			this.materials = new ByTable().Set( "$metal", 6000 ).Set( "$silver", 600 ).Set( "$uranium", 2000 );
			this.build_path = typeof(Obj_Item_AmmoBox_Magazine_Wt550m9_Wttx);
		}

	}

}