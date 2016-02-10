// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Gun_Energy_PulseRifle_M1911 : Obj_Item_Weapon_Gun_Energy_PulseRifle {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.inhand_states = new ByTable().Set( "left_hand", "icons/mob/in-hand/left/guninhands_left.dmi" ).Set( "right_hand", "icons/mob/in-hand/right/guninhands_right.dmi" );
			this.cell_type = "/obj/item/weapon/cell/infinite";
			this.icon_state = "m1911-p";
		}

		public Obj_Item_Weapon_Gun_Energy_PulseRifle_M1911 ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: pulse.dm
		public override bool isHandgun(  ) {
			return true;
		}

	}

}