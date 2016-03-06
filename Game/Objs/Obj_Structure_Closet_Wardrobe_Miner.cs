// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Wardrobe_Miner : Obj_Structure_Closet_Wardrobe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_door = "mixed";
		}

		// Function from file: mine_items.dm
		public Obj_Structure_Closet_Wardrobe_Miner ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.contents = new ByTable();
			new Obj_Item_Weapon_Storage_Backpack_Dufflebag_Engineering( this );
			new Obj_Item_Weapon_Storage_Backpack_Industrial( this );
			new Obj_Item_Weapon_Storage_Backpack_SatchelEng( this );
			new Obj_Item_Clothing_Under_Rank_Miner( this );
			new Obj_Item_Clothing_Under_Rank_Miner( this );
			new Obj_Item_Clothing_Under_Rank_Miner( this );
			new Obj_Item_Clothing_Shoes_Sneakers_Black( this );
			new Obj_Item_Clothing_Shoes_Sneakers_Black( this );
			new Obj_Item_Clothing_Shoes_Sneakers_Black( this );
			new Obj_Item_Clothing_Gloves_Fingerless( this );
			new Obj_Item_Clothing_Gloves_Fingerless( this );
			new Obj_Item_Clothing_Gloves_Fingerless( this );
			return;
		}

	}

}