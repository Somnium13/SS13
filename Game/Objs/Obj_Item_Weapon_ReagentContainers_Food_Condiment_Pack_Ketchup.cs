// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Condiment_Pack_Ketchup : Obj_Item_Weapon_ReagentContainers_Food_Condiment_Pack {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.originalname = "ketchup";
			this.list_reagents = new ByTable().Set( "ketchup", 10 );
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Condiment_Pack_Ketchup ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}