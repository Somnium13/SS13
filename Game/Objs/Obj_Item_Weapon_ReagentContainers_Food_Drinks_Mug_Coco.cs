// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Drinks_Mug_Coco : Obj_Item_Weapon_ReagentContainers_Food_Drinks_Mug {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.list_reagents = new ByTable().Set( "hot_coco", 30 ).Set( "sugar", 5 );
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Drinks_Mug_Coco ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}