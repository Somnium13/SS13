// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Lighter_Greyscale : Obj_Item_Weapon_Lighter {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_state = "lighter";
		}

		// Function from file: cigs_lighters.dm
		public Obj_Item_Weapon_Lighter_Greyscale ( dynamic loc = null ) : base( (object)(loc) ) {
			Image I = null;

			I = new Image( this.icon, "lighter-overlay" );
			I.color = GlobalFuncs.color2hex( GlobalFuncs.randomColor( true ) );
			this.overlays.Add( I );
			return;
		}

	}

}