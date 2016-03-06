// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Scotchegg : Obj_Item_Weapon_ReagentContainers_Food_Snacks {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.bonus_reagents = new ByTable().Set( "nutriment", 2 ).Set( "vitamin", 2 );
			this.bitesize = 3;
			this.filling_color = "#FFFFF0";
			this.list_reagents = new ByTable().Set( "nutriment", 6 );
			this.icon_state = "scotchegg";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Scotchegg ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}