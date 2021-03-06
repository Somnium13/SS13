// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Seeds_Sweetpotatoseed : Obj_Item_Seeds {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.species = "sweetpotato";
			this.plantname = "Sweet Potato Plants";
			this.product = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Sweetpotato);
			this.lifespan = 30;
			this.endurance = 15;
			this.maturation = 10;
			this.production = 1;
			this.yield = 4;
			this.oneharvest = true;
			this.potency = 10;
			this.growthstages = 4;
			this.icon_state = "seed-sweetpotato";
		}

		public Obj_Item_Seeds_Sweetpotatoseed ( dynamic loc = null, dynamic parent = null ) : base( (object)(loc), (object)(parent) ) {
			
		}

	}

}