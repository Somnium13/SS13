// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_PodGunTaser : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Spacepod Equipment (Taser)";
			this.desc = "Allows for the construction of a spacepod mounted taser.";
			this.id = "podgun_taser";
			this.build_type = 32;
			this.req_tech = new ByTable().Set( "materials", 2 ).Set( "combat", 2 );
			this.build_path = typeof(Obj_Item_Device_SpacepodEquipment_Weaponry_Taser);
			this.category = "Pod_Weaponry";
			this.materials = new ByTable().Set( "$iron", 15000 );
		}

	}

}