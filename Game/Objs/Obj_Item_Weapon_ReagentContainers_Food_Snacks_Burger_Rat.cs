// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Burger_Rat : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Burger {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bonus_reagents = new ByTable().Set( "nutriment", 1 ).Set( "vitamin", 1 );
			this.icon_state = "ratburger";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Burger_Rat ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}