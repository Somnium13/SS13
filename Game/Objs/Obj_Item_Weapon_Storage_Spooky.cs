// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Spooky : Obj_Item_Weapon_Storage {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon = "icons/obj/halloween_items.dmi";
			this.icon_state = "treatbag";
		}

		// Function from file: halloween.dm
		public Obj_Item_Weapon_Storage_Spooky ( dynamic loc = null ) : base( (object)(loc) ) {
			double distrobuteinbag = 0;
			dynamic type = null;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			foreach (dynamic _a in Lang13.IterateRange( 0, 5 )) {
				distrobuteinbag = _a;
				
				type = Rand13.Pick(new object [] { typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Sugarcookie_Spookyskull), typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Sugarcookie_Spookycoffin), typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_CandyCorn), typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Candy), typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Chocolatebar) });
				Lang13.Call( type, this );
			}
			return;
		}

	}

}