// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Wardrobe_ChaplainBlack : Obj_Structure_Closet_Wardrobe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_door = "black";
		}

		// Function from file: job_closets.dm
		public Obj_Structure_Closet_Wardrobe_ChaplainBlack ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.contents = new ByTable();
			new Obj_Item_Clothing_Under_Rank_Chaplain( this );
			new Obj_Item_Clothing_Shoes_Sneakers_Black( this );
			new Obj_Item_Clothing_Suit_Nun( this );
			new Obj_Item_Clothing_Head_NunHood( this );
			new Obj_Item_Clothing_Suit_Hooded_ChaplainHoodie( this );
			new Obj_Item_Clothing_Suit_Holidaypriest( this );
			new Obj_Item_Weapon_Storage_Backpack_Cultpack( this );
			new Obj_Item_Clothing_Head_Helmet_Knight_Templar( this );
			new Obj_Item_Clothing_Suit_Armor_Riot_Knight_Templar( this );
			new Obj_Item_Weapon_Storage_Fancy_CandleBox( this );
			new Obj_Item_Weapon_Storage_Fancy_CandleBox( this );
			return;
		}

	}

}