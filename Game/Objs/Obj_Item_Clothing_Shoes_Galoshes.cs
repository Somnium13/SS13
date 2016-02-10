// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Shoes_Galoshes : Obj_Item_Clothing_Shoes {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.permeability_coefficient = 0.05;
			this.flags = 1024;
			this.species_fit = new ByTable(new object [] { "Vox" });
			this.heat_conductivity = 0.3;
			this.icon_state = "galoshes";
		}

		public Obj_Item_Clothing_Shoes_Galoshes ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}