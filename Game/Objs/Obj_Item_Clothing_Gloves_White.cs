// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Gloves_White : Obj_Item_Clothing_Gloves {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "white";
			this._color = "mime";
			this.species_fit = new ByTable(new object [] { "Vox" });
			this.icon_state = "white";
		}

		public Obj_Item_Clothing_Gloves_White ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}