// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Backpack_Dufflebag_Syndie_M90glbundle : Obj_Item_Weapon_Storage_Backpack_Dufflebag_Syndie {

		// Function from file: backpack.dm
		public Obj_Item_Weapon_Storage_Backpack_Dufflebag_Syndie_M90glbundle ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.contents = new ByTable();
			new Obj_Item_AmmoBox_Magazine_M556( this );
			new Obj_Item_AmmoBox_A40mm( this );
			new Obj_Item_Weapon_Gun_Projectile_Automatic_M90( this );
			new Obj_Item_Weapon_Storage_Fancy_Cigarettes_CigpackSyndicate( this );
			return;
		}

	}

}