// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Projectile_Automatic_Pistol : Obj_Item_Weapon_Gun_Projectile_Automatic {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.w_class = 2;
			this.origin_tech = "combat=2;materials=2;syndicate=2";
			this.mag_type = typeof(Obj_Item_AmmoBox_Magazine_M10mm);
		}

		public Obj_Item_Weapon_Gun_Projectile_Automatic_Pistol ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: pistol.dm
		public override bool update_icon( dynamic new_state = null, dynamic new_icon = null, int? new_px = null, int? new_py = null ) {
			base.update_icon( (object)(new_state), (object)(new_icon), new_px, new_py );
			this.icon_state = "" + Lang13.Initial( this, "icon_state" ) + ( Lang13.Bool( this.chambered ) ? "" : "-e" ) + ( Lang13.Bool( this.suppressed ) ? "-suppressed" : "" );
			return false;
		}

	}

}