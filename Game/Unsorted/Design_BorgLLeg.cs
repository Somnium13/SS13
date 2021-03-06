// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_BorgLLeg : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Cyborg Left Leg";
			this.id = "borg_l_leg";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_RobotParts_LLeg);
			this.materials = new ByTable().Set( "$metal", 10000 );
			this.construction_time = 200;
			this.category = new ByTable(new object [] { "Cyborg" });
		}

	}

}