// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Syringe_Bioterror : Obj_Item_Weapon_ReagentContainers_Syringe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.list_reagents = new ByTable().Set( "neurotoxin", 5 ).Set( "mutetoxin", 5 ).Set( "sodium_thiopental", 5 );
		}

		public Obj_Item_Weapon_ReagentContainers_Syringe_Bioterror ( dynamic location = null, int? vol = null ) : base( (object)(location), vol ) {
			
		}

	}

}