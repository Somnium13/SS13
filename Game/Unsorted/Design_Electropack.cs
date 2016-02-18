// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Design_Electropack : Design {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Electropack";
			this.id = "electropack";
			this.build_type = 4;
			this.materials = new ByTable().Set( "$metal", 10000 ).Set( "$glass", 2500 );
			this.build_path = typeof(Obj_Item_Device_Electropack);
			this.category = new ByTable(new object [] { "hacked", "Tools" });
		}

	}

}