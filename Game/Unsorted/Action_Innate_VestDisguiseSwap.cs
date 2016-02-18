// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Action_Innate_VestDisguiseSwap : Action_Innate {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Switch Vest Disguise";
			this.button_icon_state = "vest_disguise";
		}

		public Action_Innate_VestDisguiseSwap ( Obj_Item_Weapon_Tank Target = null ) : base( Target ) {
			
		}

		// Function from file: camera.dm
		public override void Activate( int? forced_state = null ) {
			dynamic console = null;

			
			if ( !Lang13.Bool( this.target ) || !( this.owner is Mob_Living_Carbon ) ) {
				return;
			}
			console = this.target;
			((Obj_Machinery_Abductor_Console)console).SelectDisguise( true );
			return;
		}

	}

}