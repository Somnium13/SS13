// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Wizard_Fake : Obj_Item_Clothing_Head_Wizard {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.armor = new ByTable().Set( "melee", 0 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 0 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.icon_state = "wizard-fake";
		}

		public Obj_Item_Clothing_Head_Wizard_Fake ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}