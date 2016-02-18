// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Outfit_Job_Rd : Outfit_Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Research Director";
			this.id = typeof(Obj_Item_Weapon_Card_Id_Silver);
			this.belt = typeof(Obj_Item_Device_Pda_Heads_Rd);
			this.ears = typeof(Obj_Item_Device_Radio_Headset_Heads_Rd);
			this.uniform = typeof(Obj_Item_Clothing_Under_Rank_ResearchDirector);
			this.shoes = typeof(Obj_Item_Clothing_Shoes_Sneakers_Brown);
			this.suit = typeof(Obj_Item_Clothing_Suit_Toggle_Labcoat);
			this.l_hand = typeof(Obj_Item_Weapon_Clipboard);
			this.l_pocket = typeof(Obj_Item_Device_LaserPointer);
			this.backpack_contents = new ByTable().Set( typeof(Obj_Item_Weapon_Melee_ClassicBaton_Telescopic), 1 );
			this.backpack = typeof(Obj_Item_Weapon_Storage_Backpack_Science);
			this.satchel = typeof(Obj_Item_Weapon_Storage_Backpack_SatchelTox);
		}

		// Function from file: science.dm
		public override void post_equip( Mob H = null, int? visualsOnly = null ) {
			visualsOnly = visualsOnly ?? GlobalVars.FALSE;

			base.post_equip( H, visualsOnly );

			if ( Lang13.Bool( visualsOnly ) ) {
				return;
			}
			this.announce_head( H, new ByTable(new object [] { "Science" }) );
			return;
		}

	}

}