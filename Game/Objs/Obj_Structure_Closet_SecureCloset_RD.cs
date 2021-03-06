// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_SecureCloset_RD : Obj_Structure_Closet_SecureCloset {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.req_access = new ByTable(new object [] { 30 });
			this.icon_state = "rd";
		}

		// Function from file: scientist.dm
		public Obj_Structure_Closet_SecureCloset_RD ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Clothing_Suit_Cloak_Rd( this );
			new Obj_Item_Clothing_Suit_BioSuit_Scientist( this );
			new Obj_Item_Clothing_Head_BioHood_Scientist( this );
			new Obj_Item_Clothing_Suit_Toggle_Labcoat( this );
			new Obj_Item_Clothing_Under_Rank_ResearchDirector( this );
			new Obj_Item_Clothing_Under_Rank_ResearchDirector_Alt( this );
			new Obj_Item_Clothing_Under_Rank_ResearchDirector_Turtleneck( this );
			new Obj_Item_Clothing_Shoes_Sneakers_Brown( this );
			new Obj_Item_Weapon_Cartridge_Rd( this );
			new Obj_Item_Clothing_Gloves_Color_Latex( this );
			new Obj_Item_Device_Radio_Headset_Heads_Rd( this );
			new Obj_Item_Weapon_Tank_Internals_Air( this );
			new Obj_Item_Clothing_Mask_Gas( this );
			new Obj_Item_Clothing_Suit_Armor_Reactive_Teleport( this );
			new Obj_Item_Device_Assembly_Flash_Handheld( this );
			new Obj_Item_Device_LaserPointer( this );
			return;
		}

	}

}