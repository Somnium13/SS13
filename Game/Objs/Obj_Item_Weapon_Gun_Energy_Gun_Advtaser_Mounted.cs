// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Energy_Gun_Advtaser_Mounted : Obj_Item_Weapon_Gun_Energy_Gun_Advtaser {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.selfcharge = true;
			this.flags = 2;
			this.w_class = 5;
			this.icon_state = "armcannon";
		}

		public Obj_Item_Weapon_Gun_Energy_Gun_Advtaser_Mounted ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: mounted.dm
		public override bool dropped( dynamic user = null ) {
			this.loc = null;
			return false;
		}

	}

}