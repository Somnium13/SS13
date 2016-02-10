// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Mask_Gas_VirusclownHat : Obj_Item_Clothing_Mask_Gas {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.item_state = "clown_hat";
			this.species_fit = new ByTable(new object [] { "Vox" });
			this.icon_state = "clown";
		}

		public Obj_Item_Clothing_Mask_Gas_VirusclownHat ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: effect.dm
		public override dynamic equipped( dynamic user = null, dynamic slot = null ) {
			
			if ( slot == 4 ) {
				this.canremove = true;
			}
			base.equipped( (object)(user), (object)(slot) );
			return null;
		}

		// Function from file: effect.dm
		public override dynamic dropped( dynamic user = null ) {
			this.canremove = true;
			base.dropped( (object)(user) );
			return null;
		}

	}

}