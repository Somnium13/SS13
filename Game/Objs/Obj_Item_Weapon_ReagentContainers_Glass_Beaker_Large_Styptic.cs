// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Large_Styptic : Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Large {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.list_reagents = new ByTable().Set( "styptic_powder", 50 );
		}

		public Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Large_Styptic ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}