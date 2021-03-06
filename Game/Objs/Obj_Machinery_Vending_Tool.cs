// FILE AUTOGENERATED BY SOMNIUM13.

using System;
using Somnium.Engine.ByImpl;

namespace Somnium.Game {
	class Obj_Machinery_Vending_Tool : Obj_Machinery_Vending {

		protected override void __FieldInit() {
			base.__FieldInit();

			this.icon_deny = "tool-deny";
			this.products = new ByTable()
				.Set( typeof(Obj_Item_Stack_CableCoil_Random), 10 )
				.Set( typeof(Obj_Item_Weapon_Crowbar), 5 )
				.Set( typeof(Obj_Item_Weapon_Weldingtool), 3 )
				.Set( typeof(Obj_Item_Weapon_Wirecutters), 5 )
				.Set( typeof(Obj_Item_Weapon_Wrench), 5 )
				.Set( typeof(Obj_Item_Device_Analyzer), 5 )
				.Set( typeof(Obj_Item_Device_TScanner), 5 )
				.Set( typeof(Obj_Item_Weapon_Screwdriver), 5 )
			;
			this.contraband = new ByTable().Set( typeof(Obj_Item_Weapon_Weldingtool_Hugetank), 2 ).Set( typeof(Obj_Item_Clothing_Gloves_Color_Fyellow), 2 );
			this.premium = new ByTable().Set( typeof(Obj_Item_Clothing_Gloves_Color_Yellow), 1 );
			this.icon_state = "tool";
		}

		public Obj_Machinery_Vending_Tool ( dynamic loc = null ) : base( (object)(loc) ) {
			
		}

	}

}