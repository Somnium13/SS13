// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_FreeformcoreModule : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Core Module Design (Freeform)";
			this.desc = "Allows for the construction of a Freeform AI Core Module.";
			this.id = "freeformcore_module";
			this.req_tech = new ByTable().Set( "programming", 4 ).Set( "materials", 6 );
			this.build_type = 1;
			this.materials = new ByTable().Set( "$glass", 2000 ).Set( "sacid", 20 ).Set( "$diamond", 100 );
			this.category = "Module Boards";
			this.build_path = typeof(Obj_Item_Weapon_AiModule_Freeform_Core);
		}

	}

}