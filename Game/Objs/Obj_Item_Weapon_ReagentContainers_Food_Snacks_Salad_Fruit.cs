// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Salad_Fruit : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Salad {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bonus_reagents = new ByTable().Set( "nutriment", 2 ).Set( "vitamin", 4 );
			this.icon_state = "fruitsalad";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Salad_Fruit ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}