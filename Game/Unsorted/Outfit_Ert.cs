// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Outfit_Ert : Outfit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "ERT Common";
			this.uniform = typeof(Obj_Item_Clothing_Under_Rank_CentcomOfficer);
			this.shoes = typeof(Obj_Item_Clothing_Shoes_Combat_Swat);
			this.gloves = typeof(Obj_Item_Clothing_Gloves_Combat);
			this.ears = typeof(Obj_Item_Device_Radio_Headset_HeadsetCent_Alt);
		}

		// Function from file: ert.dm
		public override void post_equip( Mob H = null, int? visualsOnly = null ) {
			visualsOnly = visualsOnly ?? GlobalVars.FALSE;

			Obj_Item_Weapon_Implant_Loyalty L = null;
			Obj_Item_Device_Radio R = null;
			Obj_Item_Weapon_Card_Id W = null;

			
			if ( Lang13.Bool( visualsOnly ) ) {
				return;
			}
			L = new Obj_Item_Weapon_Implant_Loyalty( H );
			L.imp_in = H;
			L.implanted = 1;
			((dynamic)H).sec_hud_set_implants();
			R = ((dynamic)H).ears;
			R.set_frequency( GlobalVars.CENTCOM_FREQ );
			R.freqlock = true;
			W = ((dynamic)H).wear_id;
			W.registered_name = H.real_name;
			W.update_label( W.registered_name, W.assignment );
			return;
		}

	}

}