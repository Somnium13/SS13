// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Effect_Spawner_Lootdrop_Snowdin : Obj_Effect_Spawner_Lootdrop {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.lootdoubles = 0;
			this.loot = new ByTable().Set( typeof(Obj_Item_Weapon_Bikehorn), 100 );
		}

		public Obj_Effect_Spawner_Lootdrop_Snowdin ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}