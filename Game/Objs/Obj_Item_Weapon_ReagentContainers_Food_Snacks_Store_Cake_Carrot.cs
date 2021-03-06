// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store_Cake_Carrot : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store_Cake {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.slice_path = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cakeslice_Carrot);
			this.bonus_reagents = new ByTable().Set( "nutriment", 3 ).Set( "oculine", 5 ).Set( "vitamin", 10 );
			this.list_reagents = new ByTable().Set( "nutriment", 20 ).Set( "oculine", 10 ).Set( "vitamin", 5 );
			this.icon_state = "carrotcake";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Store_Cake_Carrot ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}