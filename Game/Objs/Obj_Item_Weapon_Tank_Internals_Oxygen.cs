// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Tank_Internals_Oxygen : Obj_Item_Weapon_Tank_Internals {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.distribute_pressure = 16;
			this.force = 10;
			this.icon_state = "oxygen";
		}

		// Function from file: tank_types.dm
		public Obj_Item_Weapon_Tank_Internals_Oxygen ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.air_contents.assert_gas( "o2" );
			this.air_contents.gases["o2"][1] = ( this.volume ??0) * 607.949951171875 / 2436.07666015625;
			return;
		}

	}

}