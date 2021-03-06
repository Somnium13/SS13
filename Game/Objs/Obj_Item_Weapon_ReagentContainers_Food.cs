// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food : Obj_Item_Weapon_ReagentContainers {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.possible_transfer_amounts = new ByTable();
			this.volume = 50;
			this.burn_state = 0;
		}

		// Function from file: food.dm
		public Obj_Item_Weapon_ReagentContainers_Food ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.pixel_x = Rand13.Int( -5, 5 );
			this.pixel_y = Rand13.Int( -5, 5 );
			return;
		}

	}

}