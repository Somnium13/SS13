// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Bombcore_Badmin : Obj_Item_Weapon_Bombcore {

		public Obj_Item_Weapon_Bombcore_Badmin ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: syndicatebomb.dm
		public override void defuse(  ) {
			Ent_Static B = null;

			B = this.loc;
			GlobalFuncs.qdel( B );
			GlobalFuncs.qdel( this );
			return;
		}

	}

}