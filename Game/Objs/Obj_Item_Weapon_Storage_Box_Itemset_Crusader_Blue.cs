// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Box_Itemset_Crusader_Blue : Obj_Item_Weapon_Storage_Box_Itemset_Crusader {

		// Function from file: items.dm
		public Obj_Item_Weapon_Storage_Box_Itemset_Crusader_Blue ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.contents = new ByTable();
			Task13.Sleep( 1 );
			new Obj_Item_Clothing_Suit_Armor_Plate_Crusader_Blue( this );
			new Obj_Item_Clothing_Head_Helmet_Plate_Crusader_Blue( this );
			new Obj_Item_Clothing_Gloves_Plate_Blue( this );
			new Obj_Item_Clothing_Shoes_Plate_Blue( this );
			return;
		}

	}

}