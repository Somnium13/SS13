// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Wardrobe_Orange : Obj_Structure_Closet_Wardrobe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_closed = "orange";
			this.icon_state = "orange";
		}

		// Function from file: wardrobe.dm
		public Obj_Structure_Closet_Wardrobe_Orange ( dynamic loc = null ) : base( (object)(loc) ) {
			new Obj_Item_Clothing_Under_Color_Prisoner( this );
			new Obj_Item_Clothing_Under_Color_Prisoner( this );
			new Obj_Item_Clothing_Under_Color_Prisoner( this );
			new Obj_Item_Clothing_Shoes_Orange( this );
			new Obj_Item_Clothing_Shoes_Orange( this );
			new Obj_Item_Clothing_Shoes_Orange( this );
			this.AddToProfiler();
			return;
		}

	}

}