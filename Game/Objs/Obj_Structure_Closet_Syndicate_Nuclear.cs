// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Syndicate_Nuclear : Obj_Structure_Closet_Syndicate {

		// Function from file: syndicate.dm
		public Obj_Structure_Closet_Syndicate_Nuclear ( dynamic loc = null ) : base( (object)(loc) ) {
			double i = 0;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.contents = new ByTable();

			foreach (dynamic _a in Lang13.IterateRange( 1, 5 )) {
				i = _a;
				
				new Obj_Item_AmmoBox_Magazine_M10mm( this );
			}
			new Obj_Item_Weapon_Storage_Box_Flashbangs( this );
			new Obj_Item_Weapon_Storage_Box_Teargas( this );
			new Obj_Item_Weapon_Storage_Backpack_Dufflebag_Syndie_Med( this );
			new Obj_Item_Device_Pda_Syndicate( this );
			return;
		}

	}

}