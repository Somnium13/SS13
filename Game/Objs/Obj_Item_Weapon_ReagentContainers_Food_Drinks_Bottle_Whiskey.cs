// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Whiskey : Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.list_reagents = new ByTable().Set( "whiskey", 100 );
			this.icon_state = "whiskeybottle";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Drinks_Bottle_Whiskey ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}