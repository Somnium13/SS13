// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Spawner_Structure_Window : Obj_Effect_Spawner_Structure {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.spawn_list = new ByTable(new object [] { typeof(Obj_Structure_Grille), typeof(Obj_Structure_Window_Fulltile) });
			this.icon = "icons/obj/structures.dmi";
			this.icon_state = "window_spawner";
		}

		public Obj_Effect_Spawner_Structure_Window ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}