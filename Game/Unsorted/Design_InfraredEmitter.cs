// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_InfraredEmitter : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Infrared emitter";
			this.id = "infrared_emitter";
			this.build_type = 4;
			this.materials = new ByTable().Set( "$metal", 1000 ).Set( "$glass", 500 );
			this.build_path = typeof(Obj_Item_Device_Assembly_Infra);
			this.category = new ByTable(new object [] { "initial", "Misc" });
		}

	}

}