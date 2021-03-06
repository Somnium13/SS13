// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Rofflewaffles : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.trash = typeof(Obj_Item_Trash_Waffles);
			this.bitesize = 4;
			this.bonus_reagents = new ByTable().Set( "vitamin", 2 );
			this.list_reagents = new ByTable().Set( "nutriment", 8 ).Set( "mushroomhallucinogen", 2 ).Set( "vitamin", 2 );
			this.filling_color = "#00BFFF";
			this.icon_state = "rofflewaffles";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Rofflewaffles ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}