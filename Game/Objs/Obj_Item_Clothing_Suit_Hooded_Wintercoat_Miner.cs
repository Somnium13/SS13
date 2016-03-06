// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Item_Clothing_Suit_Hooded_Wintercoat_Miner : Obj_Item_Clothing_Suit_Hooded_Wintercoat {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.v_allowed = new ByTable(new object [] { 
				typeof(Obj_Item_Weapon_Pickaxe), 
				typeof(Obj_Item_Device_Flashlight), 
				typeof(Obj_Item_Weapon_Tank_Internals_EmergencyOxygen), 
				typeof(Obj_Item_Toy), 
				typeof(Obj_Item_Weapon_Storage_Fancy_Cigarettes), 
				typeof(Obj_Item_Weapon_Lighter)
			 });
			this.armor = new ByTable().Set( "melee", 10 ).Set( "bullet", 0 ).Set( "laser", 0 ).Set( "energy", 0 ).Set( "bomb", 0 ).Set( "bio", 0 ).Set( "rad", 0 );
			this.hoodtype = typeof(Obj_Item_Clothing_Head_Winterhood_Miner);
			this.icon_state = "coatminer";
		}

		public Obj_Item_Clothing_Suit_Hooded_Wintercoat_Miner ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}