// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Tapeproj_Engineering : Obj_Item_Tapeproj {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.tape_type = typeof(Obj_Item_Holotape_Engineering);
			this.icon_base = "engineering";
			this.icon_state = "engineering_start";
		}

		public Obj_Item_Tapeproj_Engineering ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}