// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Window_Reinforced_Tinted_Fulltile : Obj_Structure_Window_Reinforced_Tinted {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.fulltile = true;
			this.smooth = 1;
			this.canSmoothWith = new ByTable(new object [] { typeof(Obj_Structure_Window_Fulltile), typeof(Obj_Structure_Window_Reinforced_Fulltile), typeof(Obj_Structure_Window_Reinforced_Tinted_Fulltile) });
			this.level = 3;
			this.icon = "icons/obj/smooth_structures/tinted_window.dmi";
			this.icon_state = "tinted_window";
			this.dir = 5;
		}

		public Obj_Structure_Window_Reinforced_Tinted_Fulltile ( dynamic Loc = null, bool? re = null ) : base( (object)(Loc), re ) {
			
		}

	}

}