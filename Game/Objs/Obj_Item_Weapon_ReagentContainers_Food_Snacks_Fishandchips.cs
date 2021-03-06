// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Fishandchips : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bonus_reagents = new ByTable().Set( "nutriment", 1 ).Set( "vitamin", 2 );
			this.list_reagents = new ByTable().Set( "nutriment", 6 );
			this.filling_color = "#FA8072";
			this.icon_state = "fishandchips";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Fishandchips ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}