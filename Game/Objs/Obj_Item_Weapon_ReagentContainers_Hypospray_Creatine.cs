// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_ReagentContainers_Hypospray_Creatine : Obj_Item_Weapon_ReagentContainers_Hypospray {

		// Function from file: hypospray.dm
		public Obj_Item_Weapon_ReagentContainers_Hypospray_Creatine ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			((Reagents)this.reagents).add_reagent( "creatine", 30 );
			return;
		}

	}

}