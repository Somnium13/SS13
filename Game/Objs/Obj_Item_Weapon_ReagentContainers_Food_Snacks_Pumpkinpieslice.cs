// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pumpkinpieslice : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.trash = typeof(Obj_Item_Trash_Plate);
			this.filling_color = "#FFA500";
			this.list_reagents = new ByTable().Set( "nutriment", 2 );
			this.icon = "icons/obj/food/piecake.dmi";
			this.icon_state = "pumpkinpieslice";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pumpkinpieslice ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}