// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Healthanalyzer : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Health Analyzer";
			this.desc = "A hand-held body scanner able to distinguish vital signs of the subject.";
			this.id = "healthanalyzer";
			this.req_tech = new ByTable().Set( "magnets", 2 ).Set( "biotech", 2 );
			this.build_type = 2;
			this.materials = new ByTable().Set( "$iron", 1000 ).Set( "$glass", 1000 );
			this.category = "Medical";
			this.build_path = typeof(Obj_Item_Device_Healthanalyzer);
		}

	}

}