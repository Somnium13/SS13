// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Mask_Cigarette_Cigar_Havana : Obj_Item_Clothing_Mask_Cigarette_Cigar {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_on = "cigar2on";
			this.icon_off = "cigar2off";
			this.smoketime = 7200;
			this.chem_volume = 50;
			this.icon_state = "cigar2off";
		}

		public Obj_Item_Clothing_Mask_Cigarette_Cigar_Havana ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}