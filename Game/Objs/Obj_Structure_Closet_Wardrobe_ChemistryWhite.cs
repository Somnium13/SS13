// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Wardrobe_ChemistryWhite : Obj_Structure_Closet_Wardrobe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_door = "white";
		}

		// Function from file: job_closets.dm
		public Obj_Structure_Closet_Wardrobe_ChemistryWhite ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.contents = new ByTable();
			new Obj_Item_Clothing_Under_Rank_Chemist( this );
			new Obj_Item_Clothing_Under_Rank_Chemist( this );
			new Obj_Item_Clothing_Shoes_Sneakers_White( this );
			new Obj_Item_Clothing_Shoes_Sneakers_White( this );
			new Obj_Item_Clothing_Suit_Toggle_Labcoat_Chemist( this );
			new Obj_Item_Clothing_Suit_Toggle_Labcoat_Chemist( this );
			new Obj_Item_Weapon_Storage_Backpack_Chemistry( this );
			new Obj_Item_Weapon_Storage_Backpack_Chemistry( this );
			new Obj_Item_Weapon_Storage_Backpack_SatchelChem( this );
			new Obj_Item_Weapon_Storage_Backpack_SatchelChem( this );
			new Obj_Item_Weapon_Storage_Bag_Chemistry( this );
			new Obj_Item_Weapon_Storage_Bag_Chemistry( this );
			return;
		}

	}

}