// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Seeds_Parsnipseed : Obj_Item_Seeds {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.species = "parsnip";
			this.plantname = "Parsnip";
			this.product = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Parsnip);
			this.lifespan = 25;
			this.endurance = 15;
			this.maturation = 10;
			this.production = 1;
			this.yield = 5;
			this.potency = 10;
			this.oneharvest = true;
			this.growthstages = 3;
			this.icon_state = "seed-parsnip";
		}

		public Obj_Item_Seeds_Parsnipseed ( dynamic loc = null, dynamic parent = null ) : base( (object)(loc), (object)(parent) ) {
			
		}

	}

}