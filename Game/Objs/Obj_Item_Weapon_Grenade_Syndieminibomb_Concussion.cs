// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Grenade_Syndieminibomb_Concussion : Obj_Item_Weapon_Grenade_Syndieminibomb {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.origin_tech = "materials=3;magnets=4;syndicate=2";
			this.icon_state = "concussion";
		}

		public Obj_Item_Weapon_Grenade_Syndieminibomb_Concussion ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: syndieminibomb.dm
		public override void prime(  ) {
			this.update_mob();
			GlobalFuncs.explosion( this.loc, 0, 2, 3, null, null, null, 3 );
			GlobalFuncs.qdel( this );
			return;
		}

	}

}