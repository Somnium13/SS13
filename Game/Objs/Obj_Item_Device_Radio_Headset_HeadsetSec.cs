// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Device_Radio_Headset_HeadsetSec : Obj_Item_Device_Radio_Headset {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.keyslot = new Obj_Item_Device_Encryptionkey_HeadsetSec();
			this.icon_state = "sec_headset";
		}

		public Obj_Item_Device_Radio_Headset_HeadsetSec ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}