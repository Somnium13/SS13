// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Structure_Closet_Thunderdome_Tdgreen : Obj_Structure_Closet_Thunderdome {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_closed = "syndicate1";
			this.icon_opened = "syndicate1open";
			this.icon_state = "syndicate1";
		}

		// Function from file: gimmick.dm
		public Obj_Structure_Closet_Thunderdome_Tdgreen ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			Task13.Sleep( 2 );
			new Obj_Item_Clothing_Suit_Armor_Tdome_Green( this );
			new Obj_Item_Clothing_Suit_Armor_Tdome_Green( this );
			new Obj_Item_Clothing_Suit_Armor_Tdome_Green( this );
			new Obj_Item_Weapon_Melee_Energy_Sword( this );
			new Obj_Item_Weapon_Melee_Energy_Sword( this );
			new Obj_Item_Weapon_Melee_Energy_Sword( this );
			new Obj_Item_Weapon_Gun_Energy_Laser( this );
			new Obj_Item_Weapon_Gun_Energy_Laser( this );
			new Obj_Item_Weapon_Gun_Energy_Laser( this );
			new Obj_Item_Weapon_Melee_Baton_Loaded( this );
			new Obj_Item_Weapon_Melee_Baton_Loaded( this );
			new Obj_Item_Weapon_Melee_Baton_Loaded( this );
			new Obj_Item_Weapon_Storage_Box_Flashbangs( this );
			new Obj_Item_Weapon_Storage_Box_Flashbangs( this );
			new Obj_Item_Weapon_Storage_Box_Flashbangs( this );
			new Obj_Item_Clothing_Head_Helmet_Thunderdome( this );
			new Obj_Item_Clothing_Head_Helmet_Thunderdome( this );
			new Obj_Item_Clothing_Head_Helmet_Thunderdome( this );
			return;
		}

	}

}