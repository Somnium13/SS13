// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Ushanka : Obj_Item_Clothing_Head {

		public bool earflaps = true;

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "ushankadown";
			this.flags_inv = 2;
			this.cold_protection = 1;
			this.min_cold_protection_temperature = 60;
			this.icon_state = "ushankadown";
		}

		public Obj_Item_Clothing_Head_Ushanka ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: misc_special.dm
		public override dynamic attack_self( dynamic user = null, dynamic flag = null, bool? emp = null ) {
			
			if ( this.earflaps ) {
				this.icon_state = "ushankaup";
				this.item_state = "ushankaup";
				this.earflaps = false;
				user.WriteMsg( "<span class='notice'>You raise the ear flaps on the ushanka.</span>" );
			} else {
				this.icon_state = "ushankadown";
				this.item_state = "ushankadown";
				this.earflaps = true;
				user.WriteMsg( "<span class='notice'>You lower the ear flaps on the ushanka.</span>" );
			}
			return null;
		}

	}

}