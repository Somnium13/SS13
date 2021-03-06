// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Firstaid_Tactical : Obj_Item_Weapon_Storage_Firstaid {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.max_w_class = 3;
			this.icon_state = "bezerk";
		}

		// Function from file: firstaid.dm
		public Obj_Item_Weapon_Storage_Firstaid_Tactical ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;

			if ( this.empty ) {
				return;
			}
			new Obj_Item_Stack_Medical_Gauze( this );
			new Obj_Item_Weapon_Defibrillator_Compact_Combat_Loaded( this );
			new Obj_Item_Weapon_ReagentContainers_Hypospray_Combat( this );
			new Obj_Item_Weapon_ReagentContainers_Pill_Patch_Styptic( this );
			new Obj_Item_Weapon_ReagentContainers_Pill_Patch_SilverSulf( this );
			new Obj_Item_Weapon_ReagentContainers_Syringe_Lethal_Choral( this );
			new Obj_Item_Clothing_Glasses_Hud_Health_Night( this );
			return;
		}

	}

}