// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Melee_ArmBlade_False : Obj_Item_Weapon_Melee_ArmBlade {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.force = 5;
		}

		public Obj_Item_Weapon_Melee_ArmBlade_False ( dynamic location = null, bool silent = false ) : base( (object)(location), silent ) {
			
		}

		// Function from file: tiny_prick.dm
		public override bool afterattack( dynamic target = null, dynamic user = null, bool? proximity_flag = null, string click_parameters = null ) {
			return false;
		}

	}

}