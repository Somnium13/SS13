// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cakeslice_Carrot : Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cakeslice {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.filling_color = "#FFA500";
			this.list_reagents = new ByTable().Set( "nutriment", 4 ).Set( "oculine", 2 ).Set( "vitamin", 1 );
			this.icon_state = "carrotcake_slice";
		}

		public Obj_Item_Weapon_ReagentContainers_Food_Snacks_Cakeslice_Carrot ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}