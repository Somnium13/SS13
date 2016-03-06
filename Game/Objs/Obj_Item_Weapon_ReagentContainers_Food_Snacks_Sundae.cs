// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Sundae : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bonus_reagents = new ByTable().Set( "nutriment", 2 ).Set( "vitamin", 1 );
			this.list_reagents = new ByTable().Set( "nutriment", 6 ).Set( "banana", 5 ).Set( "vitamin", 2 );
			this.filling_color = "#FFFACD";
			this.icon_state = "sundae";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Sundae ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}