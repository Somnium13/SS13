// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store_Cake_Plain : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store_Cake {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.custom_food_type = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Customizable_Cake);
			this.bonus_reagents = new ByTable().Set( "nutriment", 10 ).Set( "vitamin", 2 );
			this.icon_state = "plaincake";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store_Cake_Plain ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}