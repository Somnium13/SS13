// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Box_SyndieKit_Space : Obj_Item_Weapon_Storage_Box_SyndieKit {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.can_hold = new ByTable(new object [] { typeof(Obj_Item_Clothing_Suit_Space_Syndicate), typeof(Obj_Item_Clothing_Head_Helmet_Space_Syndicate) });
			this.max_w_class = 3;
		}

		// Function from file: uplink_kits.dm
		public Obj_Item_Weapon_Storage_Box_SyndieKit_Space ( dynamic loc = null ) : base( (object)(loc) ) {
			// Warning: Super call was HERE! If anything above HERE is needed by the super call, it might break!;
			new Obj_Item_Clothing_Suit_Space_Syndicate_Black_Red( this );
			new Obj_Item_Clothing_Head_Helmet_Space_Syndicate_Black_Red( this );
			return;
		}

	}

}