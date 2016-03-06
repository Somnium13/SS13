// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Head_Helmet_Space_Hardsuit_Shielded_Syndi : Obj_Item_Clothing_Head_Helmet_Space_Hardsuit_Shielded {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "syndie_helm";
			this.item_color = "syndi";
			this.armor = new ByTable().Set( "melee", 40 ).Set( "bullet", 50 ).Set( "laser", 30 ).Set( "energy", 15 ).Set( "bomb", 35 ).Set( "bio", 100 ).Set( "rad", 50 );
			this.icon_state = "hardsuit1-syndi";
		}

		public Obj_Item_Clothing_Head_Helmet_Space_Hardsuit_Shielded_Syndi ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}