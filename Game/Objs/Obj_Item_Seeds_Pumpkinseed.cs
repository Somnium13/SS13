// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Seeds_Pumpkinseed : Obj_Item_Seeds {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.species = "pumpkin";
			this.plantname = "Pumpkin Vines";
			this.product = typeof(Obj_Item_Weapon_ReagentContainers_Food_Snacks_Grown_Pumpkin);
			this.lifespan = 50;
			this.endurance = 40;
			this.maturation = 6;
			this.production = 6;
			this.yield = 3;
			this.potency = 10;
			this.growthstages = 3;
			this.mutatelist = new ByTable(new object [] { typeof(Obj_Item_Seeds_Blumpkinseed) });
			this.icon_state = "seed-pumpkin";
		}

		public Obj_Item_Seeds_Pumpkinseed ( dynamic loc = null, dynamic parent = null ) : base( (object)(loc), (object)(parent) ) {
			
		}

	}

}