// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Weapon_Storage_Bag_Bio : Obj_Item_Weapon_Storage_Bag {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.storage_slots = 25;
			this.max_combined_w_class = 200;
			this.w_class = 1;
			this.can_hold = new ByTable(new object [] { 
				typeof(Obj_Item_SlimeExtract), 
				typeof(Obj_Item_Weapon_ReagentContainers_Syringe), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Beaker), 
				typeof(Obj_Item_Weapon_ReagentContainers_Glass_Bottle), 
				typeof(Obj_Item_Weapon_ReagentContainers_Blood), 
				typeof(Obj_Item_Weapon_ReagentContainers_Hypospray_Medipen), 
				typeof(Obj_Item_Trash_Deadmouse)
			 });
			this.burn_state = 0;
			this.icon = "icons/obj/chemical.dmi";
			this.icon_state = "biobag";
		}

		public Obj_Item_Weapon_Storage_Bag_Bio ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}