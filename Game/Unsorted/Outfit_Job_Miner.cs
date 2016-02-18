// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Outfit_Job_Miner : Outfit_Job {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.name = "Shaft Miner";
			this.belt = typeof(Obj_Item_Device_Pda_Shaftminer);
			this.ears = typeof(Obj_Item_Device_Radio_Headset_HeadsetCargo);
			this.uniform = typeof(Obj_Item_Clothing_Under_Rank_Miner);
			this.l_pocket = typeof(Obj_Item_Weapon_ReagentContainers_Pill_Patch_Styptic);
			this.backpack_contents = new ByTable().Set( typeof(Obj_Item_Weapon_Crowbar), 1 ).Set( typeof(Obj_Item_Weapon_Storage_Bag_Ore), 1 ).Set( typeof(Obj_Item_Weapon_MiningVoucher), 1 );
			this.backpack = typeof(Obj_Item_Weapon_Storage_Backpack_Industrial);
			this.satchel = typeof(Obj_Item_Weapon_Storage_Backpack_SatchelEng);
			this.dufflebag = typeof(Obj_Item_Weapon_Storage_Backpack_Dufflebag_Engineering);
			this.box = typeof(Obj_Item_Weapon_Storage_Box_Engineer);
		}

	}

}