// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_AmmoBox_Magazine : Obj_Item_AmmoBox {

		public Obj_Item_AmmoBox_Magazine ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

		// Function from file: ammunition.dm
		public virtual int ammo_count( bool? countempties = null ) {
			return this.stored_ammo.len;
		}

	}

}