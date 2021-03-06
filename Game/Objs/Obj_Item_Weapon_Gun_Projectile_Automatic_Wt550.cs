// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Projectile_Automatic_Wt550 : Obj_Item_Weapon_Gun_Projectile_Automatic {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "arg";
			this.mag_type = typeof(Obj_Item_AmmoBox_Magazine_Wt550m9);
			this.burst_size = 0;
			this.icon_state = "wt550";
		}

		public Obj_Item_Weapon_Gun_Projectile_Automatic_Wt550 ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: automatic.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			base.update_icon( (object)(new_state), (object)(new_icon), new_px, new_py );
			this.icon_state = "wt550" + ( Lang13.Bool( this.magazine ) ? "-" + GlobalFuncs.Ceiling( this.get_ammo( false ) / 4 ) * 4 : "" );
			return false;
		}

	}

}