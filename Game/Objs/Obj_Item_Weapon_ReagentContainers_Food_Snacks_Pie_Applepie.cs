// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie_Applepie : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bonus_reagents = new ByTable().Set( "nutriment", 1 ).Set( "vitamin", 3 );
			this.icon_state = "applepie";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie_Applepie ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}