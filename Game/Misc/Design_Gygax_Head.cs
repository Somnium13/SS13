// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Gygax_Head : Design_Gygax {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Structure (Gygax head)";
			this.desc = "Used to build a Gygax head.";
			this.id = "gygax_head";
			this.req_tech = new ByTable().Set( "combat", 1 );
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Part_GygaxHead);
			this.category = "Gygax";
			this.materials = new ByTable().Set( "$iron", 20000 ).Set( "$glass", 10000 );
		}

	}

}