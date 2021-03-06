// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_OdysseusRightLeg : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Right Leg (\"Odysseus\")";
			this.id = "odysseus_right_leg";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_Part_OdysseusRightLeg);
			this.materials = new ByTable().Set( "$metal", 7000 );
			this.construction_time = 130;
			this.category = new ByTable(new object [] { "Odysseus" });
		}

	}

}