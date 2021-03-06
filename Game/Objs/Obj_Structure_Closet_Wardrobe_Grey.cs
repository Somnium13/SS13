// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Wardrobe_Grey : Obj_Structure_Closet_Wardrobe {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_door = "grey";
		}

		// Function from file: wardrobe.dm
		public Obj_Structure_Closet_Wardrobe_Grey ( dynamic loc = null ) : base( (object)(loc) ) {
			double i = 0;
			double i2 = 0;
			double i3 = 0;

			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			this.contents = new ByTable();

			foreach (dynamic _a in Lang13.IterateRange( 1, 3 )) {
				i = _a;
				
				new Obj_Item_Clothing_Under_Color_Grey( this );
			}

			foreach (dynamic _b in Lang13.IterateRange( 1, 3 )) {
				i2 = _b;
				
				new Obj_Item_Clothing_Shoes_Sneakers_Black( this );
			}

			foreach (dynamic _c in Lang13.IterateRange( 1, 3 )) {
				i3 = _c;
				
				new Obj_Item_Clothing_Head_Soft_Grey( this );
			}

			if ( Rand13.PercentChance( 50 ) ) {
				new Obj_Item_Weapon_Storage_Backpack_Dufflebag( this );
			}

			if ( Rand13.PercentChance( 40 ) ) {
				new Obj_Item_Clothing_Mask_Bandana_Black( this );
				new Obj_Item_Clothing_Mask_Bandana_Black( this );
			}

			if ( Rand13.PercentChance( 40 ) ) {
				new Obj_Item_Clothing_Under_Assistantformal( this );
			}

			if ( Rand13.PercentChance( 40 ) ) {
				new Obj_Item_Clothing_Under_Assistantformal( this );
			}

			if ( Rand13.PercentChance( 30 ) ) {
				new Obj_Item_Clothing_Suit_Hooded_Wintercoat( this );
				new Obj_Item_Clothing_Shoes_Winterboots( this );
			}
			return;
		}

	}

}