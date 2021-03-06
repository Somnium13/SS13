// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Wardrobe_VirologyWhite : Obj_Structure_Closet_Wardrobe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_door = "white";
		}

		// Function from file: job_closets.dm
		public Obj_Structure_Closet_Wardrobe_VirologyWhite ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.contents = new ByTable();
			new Obj_Item_Clothing_Under_Rank_Virologist( this );
			new Obj_Item_Clothing_Under_Rank_Virologist( this );
			new Obj_Item_Clothing_Shoes_Sneakers_White( this );
			new Obj_Item_Clothing_Shoes_Sneakers_White( this );
			new Obj_Item_Clothing_Suit_Toggle_Labcoat_Virologist( this );
			new Obj_Item_Clothing_Suit_Toggle_Labcoat_Virologist( this );
			new Obj_Item_Clothing_Mask_Surgical( this );
			new Obj_Item_Clothing_Mask_Surgical( this );
			new Obj_Item_Weapon_Storage_Backpack_Virology( this );
			new Obj_Item_Weapon_Storage_Backpack_Virology( this );
			new Obj_Item_Weapon_Storage_Backpack_SatchelVir( this );
			new Obj_Item_Weapon_Storage_Backpack_SatchelVir( this );
			return;
		}

	}

}