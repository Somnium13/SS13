// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Spiderleg : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.list_reagents = new ByTable().Set( "nutriment", 2 ).Set( "toxin", 2 );
			this.cooked_type = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Boiledspiderleg);
			this.filling_color = "#000000";
			this.icon_state = "spiderleg";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Spiderleg ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}