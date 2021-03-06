// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_MechLaser : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Exosuit Weapon (CH-PS \"Immolator\" Laser)";
			this.desc = "Allows for the construction of CH-PS Laser.";
			this.id = "mech_laser";
			this.build_type = 16;
			this.req_tech = new ByTable().Set( "combat", 3 ).Set( "magnets", 3 );
			this.build_path = typeof(Obj_Item_MechaParts_MechaEquipment_Weapon_Energy_Laser);
			this.materials = new ByTable().Set( "$metal", 10000 );
			this.construction_time = 100;
			this.category = new ByTable(new object [] { "Exosuit Equipment" });
		}

	}

}