// FILE AUTOGENERATED BY SOM13. DO NOT EDIT YET.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_CyberimpMedicalHud : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Medical HUD implant";
			this.desc = "These cybernetic eyes will display a medical HUD over everything you see. Wiggle eyes to control.";
			this.id = "ci-medhud";
			this.req_tech = new ByTable().Set( "materials", 6 ).Set( "programming", 4 ).Set( "biotech", 4 );
			this.build_type = 18;
			this.construction_time = 50;
			this.materials = new ByTable().Set( "$metal", 200 ).Set( "$glass", 200 ).Set( "$silver", 500 ).Set( "$gold", 500 );
			this.build_path = typeof(Obj_Item_Organ_Internal_Cyberimp_Eyes_Hud_Medical);
			this.category = new ByTable(new object [] { "Misc", "Medical Designs" });
		}

	}

}