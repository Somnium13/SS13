// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_NoRaisin : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.trash = typeof(Obj_Item_Trash_Raisins);
			this.list_reagents = new ByTable().Set( "nutriment", 2 ).Set( "sugar", 4 );
			this.junkiness = 25;
			this.filling_color = "#8B0000";
			this.icon_state = "4no_raisins";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_NoRaisin ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}