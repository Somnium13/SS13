// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Baguette : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bonus_reagents = new ByTable().Set( "nutriment", 2 ).Set( "vitamin", 2 );
			this.list_reagents = new ByTable().Set( "nutriment", 6 ).Set( "vitamin", 1 );
			this.bitesize = 3;
			this.icon = "icons/obj/food/burgerbread.dmi";
			this.icon_state = "baguette";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Baguette ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}