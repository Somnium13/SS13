// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Under_Rank_Nursesuit : Obj_Item_Clothing_Under_Rank {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "nursesuit";
			this._color = "nursesuit";
			this.permeability_coefficient = 0.5;
			this.armor = new ByTable().Set( "melee", 0 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 0 ).Set( "bio", 10 ).Set( "rad", 0 );
			this.flags = 8448;
			this.species_fit = new ByTable(new object [] { "Vox" });
			this.icon_state = "nursesuit";
		}

		public Obj_Item_Clothing_Under_Rank_Nursesuit ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}