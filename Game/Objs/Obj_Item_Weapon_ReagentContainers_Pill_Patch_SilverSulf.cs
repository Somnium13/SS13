// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Pill_Patch_SilverSulf : Obj_Item_Weapon_ReagentContainers_Pill_Patch {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.list_reagents = new ByTable().Set( "silver_sulfadiazine", 50 );
			this.icon_state = "bandaid_burn";
		}

		public Obj_Item_Weapon_ReagentContainers_Pill_Patch_SilverSulf ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}