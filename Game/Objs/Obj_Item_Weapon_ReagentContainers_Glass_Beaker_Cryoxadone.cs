// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Cryoxadone : Obj_Item_Weapon_ReagentContainers_Glass_Beaker {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.list_reagents = new ByTable().Set( "cryoxadone", 30 );
		}

		public Obj_Item_Weapon_ReagentContainers_Glass_Beaker_Cryoxadone ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}