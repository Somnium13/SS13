// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_MechHydraulicClamp : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Engineering Equipment (Hydraulic Clamp)";
			this.id = "mech_hydraulic_clamp";
			this.build_type = 16;
			this.build_path = typeof(Obj_Item_MechaParts_MechaEquipment_HydraulicClamp);
			this.materials = new ByTable().Set( "$metal", 10000 );
			this.construction_time = 100;
			this.category = new ByTable(new object [] { "Exosuit Equipment" });
		}

	}

}