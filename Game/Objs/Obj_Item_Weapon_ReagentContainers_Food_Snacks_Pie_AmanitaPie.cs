// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie_AmanitaPie : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bitesize = 4;
			this.bonus_reagents = new ByTable().Set( "nutriment", 1 ).Set( "vitamin", 4 );
			this.list_reagents = new ByTable().Set( "nutriment", 6 ).Set( "amatoxin", 3 ).Set( "mushroomhallucinogen", 1 ).Set( "vitamin", 4 );
			this.icon_state = "amanita_pie";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Pie_AmanitaPie ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}